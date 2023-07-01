using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public class SceneLoader
    {
        public enum LoadingType
        {
            LoadScene, PhantomLoadScene, WithoutLoadScreen,
        }

        private AsyncOperation _loadingAsyncOperation;
        private CoroutineProcessor _coroutineProcessor;
        private SceneUIService _sceneUIService;
        private const float _progressFactor = 5.0f;

        public SceneLoader(CoroutineProcessor coroutineProcessor, SceneUIService sceneUIService)
        => (_coroutineProcessor, _sceneUIService) = (coroutineProcessor, sceneUIService);

        public void LoadScene(int sceneIndex, LoadingType loadingType)
        => _coroutineProcessor.StartCoroutine(OnLoad(sceneIndex, loadingType));

        private IEnumerator OnLoad(int sceneIndex, LoadingType loadingType)
        {
            if (loadingType == LoadingType.WithoutLoadScreen)
                SceneManager.LoadScene(sceneIndex);

            else
            {
                float progress = .0f;
                float phantomProgress = .0f;
                _loadingAsyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
                _loadingAsyncOperation.allowSceneActivation = false;
                _sceneUIService.CallLoadingWindow();

                while (progress < .9f)
                {
                    phantomProgress += Time.deltaTime / _progressFactor;
                    progress = loadingType == LoadingType.LoadScene ? _loadingAsyncOperation.progress : phantomProgress;
                    _sceneUIService.RefreshLoadingProgressText(Mathf.Clamp01(progress / 0.9f));
                    yield return null;
                }

                _loadingAsyncOperation.allowSceneActivation = true;
            }
        }
    }
}
