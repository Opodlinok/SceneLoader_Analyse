using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public class SceneLoader
    {
        private CoroutineProcessor _coroutineProcessor;
        private SceneUIService _sceneUIService;
        private AsyncOperation _loadingAsyncOperation;

        public SceneLoader(CoroutineProcessor coroutineProcessor, SceneUIService sceneUIService)
        => (_coroutineProcessor, _sceneUIService) = (coroutineProcessor, sceneUIService);

        public void LoadScene(int sceneIndex)
        => _coroutineProcessor.StartCoroutine(OnLoadProcess(sceneIndex));

        public void PhantomLoadScene(int sceneIndex)
        => _coroutineProcessor.StartCoroutine(OnPhantomLoadProcess(sceneIndex));

        public void WithoutLoadScreen(int sceneIndex)
        => SceneManager.LoadScene(sceneIndex);

        private IEnumerator OnPhantomLoadProcess(int sceneIndex)
        {
            float progress = default;
            _loadingAsyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
            _loadingAsyncOperation.allowSceneActivation = false;
            _sceneUIService.CallLoadingWindow();
            float time = .0f;
            float factor = Random.Range(5, 20.0f);

            while (progress < 0.9f)
            {
                time += Time.deltaTime;

                if (time > 2.5f) 
                {
                    time = .0f;
                    factor = Random.Range(4, 15.0f);
                }

                progress += Time.deltaTime / factor;
                _sceneUIService.RefreshLoadingProgressText((int)(Mathf.Clamp01(progress / 0.9f) * 100));
                yield return null;
            }

            _loadingAsyncOperation.allowSceneActivation = true;
        }

        private IEnumerator OnLoadProcess(int sceneIndex)
        {
            float progress = default;
            _loadingAsyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
            _loadingAsyncOperation.allowSceneActivation = false;
            _sceneUIService.CallLoadingWindow();

            while (progress < .9f)
            {
                progress = _loadingAsyncOperation.progress;
                _sceneUIService.RefreshLoadingProgressText((int)(Mathf.Clamp01(progress / 0.9f) * 100));
                yield return null;
            }

            _loadingAsyncOperation.allowSceneActivation = true;
        }
    }
}
