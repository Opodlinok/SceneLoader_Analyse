using System.Collections;
using UnityEngine;

namespace Services
{
    public class LoadingAdvice
    {
        private SceneUIService _sceneUIService;
        private LoadingAdviceContainer _loadingAdviceContainer;
        private const float _refreshCooldown = 2f;

        public LoadingAdvice(SceneUIService sceneUIService, CoroutineProcessor coroutineProcessor, LoadingAdviceContainer loadingAdviceContainer)
        {
            _sceneUIService = sceneUIService;
            _loadingAdviceContainer = loadingAdviceContainer;
            coroutineProcessor.StartCoroutine(AdviceCooldown());
        }

        private IEnumerator AdviceCooldown() 
        {
            float time = _refreshCooldown;

            while (true) 
            {
                time += Time.deltaTime;

                if (time >= _refreshCooldown)
                {
                    SetupAdvice();
                    time = .0f;
                }

                yield return null;
            }
        }

        private void SetupAdvice()
        => _sceneUIService.RefreshLoadingAdvice(RandomAdvice());

        private string RandomAdvice() 
        {
            string advice = _loadingAdviceContainer.AdviceTexts[Random.Range(0, _loadingAdviceContainer.AdviceTexts.Length)];
            return advice;
        }
    }
}
