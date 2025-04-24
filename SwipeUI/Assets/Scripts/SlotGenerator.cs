using UnityEngine;
using UnityEngine.UI;

public class SlotGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private RectTransform _contentRect;

    [SerializeField] private Button _createButton;

    private void Awake()
    {
        _createButton.onClick.AddListener(CreateSlot);
    }

    public void CreateSlot()
    {
        _ = Instantiate(_slotPrefab, _contentRect);
    }
}