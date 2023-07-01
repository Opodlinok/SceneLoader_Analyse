using System;
using UnityEngine;
using Services;
using Containers;
using LoadingType = Services.SceneLoader.LoadingType;

public class Bootstrap : MonoBehaviour, IInitializable
{
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
        _sceneUIService.SetupMainMenuUIWindow(() => _sceneLoader.LoadScene(sceneIndex: 1, _loadingType));
    }

    private void Awake()
    {
        if (_sceneUIContainer is null)
            throw new Exception("SceneUIContainer is null;");

        Initialization();
    }
}
