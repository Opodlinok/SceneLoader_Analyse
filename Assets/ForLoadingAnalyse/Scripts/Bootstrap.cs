using System;
using UnityEngine;
using Services;

public class Bootstrap : MonoBehaviour, IInitializable
{
    private enum LoadingType
    {
        LoadScene, PhantomLoadScene, WithoutLoadScreen,
    }

    [SerializeField]
    private SceneUIContainer _sceneUIContainer;

    [SerializeField]
    private LoadingType _loadingType;

    private CoroutineProcessor _coroutineProcessor;
    private SceneUIService _sceneUIService;
    private SceneLoader _sceneLoader;

    public void Initialization()
    {
        _coroutineProcessor = new GameObject().AddComponent<CoroutineProcessor>();
        _sceneUIService = new(_sceneUIContainer);
        _sceneLoader = new(_coroutineProcessor, _sceneUIService);

        switch (_loadingType)
        {
            case LoadingType.LoadScene:
                _sceneUIService.SetupMainMenuUIWindow(() => _sceneLoader.LoadScene(1));
                break;

            case LoadingType.PhantomLoadScene:
                _sceneUIService.SetupMainMenuUIWindow(() => _sceneLoader.PhantomLoadScene(1));
                break;

            case LoadingType.WithoutLoadScreen:
                _sceneUIService.SetupMainMenuUIWindow(() => _sceneLoader.WithoutLoadScreen(1));
                break;
        }
    }

    private void Awake()
    {
        if (_sceneUIContainer is null)
            throw new Exception("SceneUIContainer is null");

        Initialization();
    }
}
