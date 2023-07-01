using TMPro;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

namespace Containers
{
    public class SceneUIContainer : MonoBehaviour
    {
        #region LoadingScreen
        [SerializeField, BoxGroup("LoadingScreen")]
        private GameObject _loadingScreenUIWindow;
        [SerializeField, BoxGroup("LoadingScreen")]
        private Slider _loadingProgressBarSlider;
        [SerializeField, BoxGroup("LoadingScreen")]
        private TextMeshProUGUI _loadingProgressTextField;
        [SerializeField, BoxGroup("LoadingScreen")]
        private TextMeshProUGUI _loadingAdviceTextField;
        #endregion

        #region MainMenu
        [SerializeField, BoxGroup("MainMenu")]
        private GameObject _mainMenuUIWindow;
        [SerializeField, BoxGroup("MainMenu")]
        private Button _newGameButton;
        [SerializeField, BoxGroup("MainMenu")]
        private Button _exitGameButton;
        #endregion

        public GameObject LoadingScreenUIWindow => _loadingScreenUIWindow;
        public Slider LoadingProgressBarSlider => _loadingProgressBarSlider;
        public TextMeshProUGUI LoadingProgressTextField => _loadingProgressTextField;
        public TextMeshProUGUI LoadingAdviceTextField => _loadingAdviceTextField;
        public GameObject MainMenuUIWindow => _mainMenuUIWindow;
        public Button NewGameButton => _newGameButton;
        public Button ExitGameButton => _exitGameButton;
    }
}
