using Containers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Services
{
    public class SceneUIService
    {
        #region LoadingScreen
        private GameObject _loadingScreenUIWindow;
        private Slider _loadingProgressBarSlider;
        private TextMeshProUGUI _loadingProgressTextField;
        private TextMeshProUGUI _loadingAdviceTextField;
        #endregion

        #region MainMenu
        private GameObject _mainMenuUIWindow;
        private Button _newGameButton;
        private Button _exitGameButton;
        #endregion

        public SceneUIService(SceneUIContainer sceneUIContainer)
        {
            // LoadingScreen.
            (_loadingScreenUIWindow, _loadingProgressBarSlider, _loadingProgressTextField, _loadingAdviceTextField) = (sceneUIContainer.LoadingScreenUIWindow, sceneUIContainer.LoadingProgressBarSlider, sceneUIContainer.LoadingProgressTextField, sceneUIContainer.LoadingAdviceTextField);

            // MainMenu.
            (_mainMenuUIWindow, _newGameButton, _exitGameButton) = (sceneUIContainer.MainMenuUIWindow, sceneUIContainer.NewGameButton, sceneUIContainer.ExitGameButton);
        }

        #region LoadingScreen
        public void RefreshLoadingProgressText(float progress)
        {
            _loadingProgressBarSlider.value = progress;
            _loadingProgressTextField.text = $"{(int)(progress * 100)}%";
        }

        public void RefreshLoadingAdvice(string adviceText)
        => _loadingAdviceTextField.text = adviceText;

        public void CallLoadingWindow()
        => _loadingScreenUIWindow.SetActive(true);

        public void CloseLoadingWindow()
        => _loadingScreenUIWindow.SetActive(false);
        #endregion
    
        #region MainMenu
        public void SetupMainMenuUIWindow(UnityAction newGameAction)
        {
            _newGameButton.onClick.AddListener(newGameAction);
            _exitGameButton.onClick.AddListener(Application.Quit);
            _loadingScreenUIWindow.SetActive(false);
            _mainMenuUIWindow.SetActive(true);
        }
        #endregion
    }
}
