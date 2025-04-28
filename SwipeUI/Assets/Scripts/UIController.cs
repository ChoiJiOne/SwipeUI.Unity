using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _activeButton;
    [SerializeField] private Button _deactiveButton;
    [SerializeField] private GameObject _bgSelector;

    private void Awake()
    {
        _activeButton.onClick.AddListener(OnActiveButtonClicked);
        _deactiveButton.onClick.AddListener(OnDeactiveButtonClicked);
    }

    private void OnActiveButtonClicked()
    {
        _bgSelector.SetActive(true);
    }

    private void OnDeactiveButtonClicked()
    {
        _bgSelector.SetActive(false);
    }
}
