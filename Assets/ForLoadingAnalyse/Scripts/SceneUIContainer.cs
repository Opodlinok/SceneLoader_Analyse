using TMPro;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class SceneUIContainer : MonoBehaviour
{
    #region LoadingScreen
    [SerializeField, BoxGroup("LoadingScreen")]
    private GameObject _loadingScreenUIWindow;
    [SerializeField, BoxGroup("LoadingScreen")]
    private TextMeshProUGUI _loadingProgressTextField;
    #endregion

    #region MainMenu
    [SerializeField, BoxGroup("MainMenu")]
    private Button _newGameButton;
    [SerializeField, BoxGroup("MainMenu")]
    private Button _exitGameButton;
    #endregion

    public GameObject LoadingScreenUIWindow => _loadingScreenUIWindow;
    public TextMeshProUGUI LoadingProgressTextField => _loadingProgressTextField;
    public Button NewGameButton => _newGameButton;
    public Button ExitGameButton => _exitGameButton;

}
