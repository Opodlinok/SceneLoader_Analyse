using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SceneUIService
{
    #region LoadingScreen
    private GameObject _loadingScreenUIWindow;
    private TextMeshProUGUI _loadingProgressTextField;
    #endregion

    #region MainMenu
    private Button _newGameButton;
    private Button _exitGameButton;
    #endregion

    public SceneUIService(SceneUIContainer sceneUIContainer)
    {
        // LoadingScreen
        (_loadingScreenUIWindow, _loadingProgressTextField) = (sceneUIContainer.LoadingScreenUIWindow, sceneUIContainer.LoadingProgressTextField);

        // MainMenu
        (_newGameButton, _exitGameButton) = (sceneUIContainer.NewGameButton, sceneUIContainer.ExitGameButton);
    }

    public void SetupMainMenuUIWindow(UnityAction newGameAction)
    {
        _newGameButton.onClick.AddListener(newGameAction);
        _exitGameButton.onClick.AddListener(Application.Quit);
    }

    public void RefreshLoadingProgressText(int progress)
    => _loadingProgressTextField.text = $"{progress}%";

    public void CallLoadingWindow()
    => _loadingScreenUIWindow.SetActive(true);

    public void CloseLoadingWindow() 
    => _loadingScreenUIWindow.SetActive(false);
}
