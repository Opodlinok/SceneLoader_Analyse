using UnityEngine;

public class LoadingAdviceContainer : MonoBehaviour
{
    [SerializeField]
    private string[] _adviceTexts;

    public string[] AdviceTexts => _adviceTexts;
}
