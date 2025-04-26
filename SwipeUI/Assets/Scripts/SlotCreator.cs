using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public class SlotCreator : MonoBehaviour
{
    public UnityAction<SlotController> OnCreateSlot;

    [SerializeField] private SlotController _slotControllerPrefab;
    [SerializeField] private RectTransform _contentRect;

    [SerializeField] private Button _createButton;

    private List<Color> _colors;
    private int _currentIndex = 0;

    private void Awake()
    {
        _createButton.onClick.AddListener(OnCreateButtonClicked);
        _colors = new List<Color>{
            Color.red,
            Color.green,
            Color.blue,
            Color.yellow,
            Color.cyan,
            Color.magenta,
        };
    }

    private void OnCreateButtonClicked()
    {
        SlotController newSlotController = Instantiate(_slotControllerPrefab, _contentRect);
        newSlotController.BgColor = _colors[_currentIndex];
        _currentIndex = (_currentIndex + 1) % _colors.Count;

        OnCreateSlot?.Invoke(newSlotController);
    }
}