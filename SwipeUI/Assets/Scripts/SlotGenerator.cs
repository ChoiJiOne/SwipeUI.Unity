using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Pool;

public class SlotGenerator : MonoBehaviour
{
    [SerializeField] private SlotController _slotControllerPrefab;
    [SerializeField] private RectTransform _contentRect;

    [SerializeField] private Button _createButton;

    private void Awake()
    {
        _createButton.onClick.AddListener(CreateSlot);
    }

    public void CreateSlot()
    {
        _ = Instantiate(_slotControllerPrefab, _contentRect);
    }
}