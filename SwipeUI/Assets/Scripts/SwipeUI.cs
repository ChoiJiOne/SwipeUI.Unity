using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;

public class SwipeUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _slotIndex;
    [SerializeField] private Button _selectButton;
    [SerializeField] private Image _bgImage;
    [SerializeField] private RectTransform _contentRect;

    [Header("Swipe")]
    [SerializeField] private List<SlotController> _slotControllers = new();
    [SerializeField] private Scrollbar _scrollBar;
    [SerializeField] private float _swipeThreshold;
    [SerializeField] private float _swipeTime;

    private float _totalWidth = 0.0f;
    private float _startPosX = 0.0f;
    private float _endPosX = 0.0f;
    private int _currentSlotIndex = 0;
    private Tween _scrollTween;

    private void Awake()
    {
        foreach (var slotController in _slotControllers)
        {
            _totalWidth += slotController.Width;
        }

        _slotIndex.text = $"{_currentSlotIndex + 1} / {_slotControllers.Count}";
        _selectButton.onClick.AddListener(OnSelectButtonClicked);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPosX = eventData.position.x;
        _scrollTween?.Kill();
    }

    public void OnDrag(PointerEventData eventData)
    {
        float dragDelta = eventData.position.x - _startPosX;
        float normalizedDelta = dragDelta / _totalWidth;

        float baseValue = (float)(_currentSlotIndex) / (_slotControllers.Count - 1);
        float newValue = Mathf.Clamp01(baseValue - normalizedDelta);

        _scrollBar.value = newValue;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _endPosX = eventData.position.x;

        float deltaX = _endPosX - _startPosX;
        if (Mathf.Abs(deltaX) > _swipeThreshold)
        {
            if (deltaX > 0.0f)
            {
                _currentSlotIndex--;
            }
            else
            {
                _currentSlotIndex++;
            }
        }

        _currentSlotIndex = Mathf.Clamp(_currentSlotIndex, 0, _slotControllers.Count - 1);
        _slotIndex.text = $"{_currentSlotIndex + 1} / {_slotControllers.Count}";

        float targetValue = (float)(_currentSlotIndex) / (_slotControllers.Count - 1);
        _scrollTween = DOTween.To(GetScrollBarValue, SetScrollBarValue, targetValue, _swipeTime).SetEase(Ease.OutQuad);
    }

    private float GetScrollBarValue() => _scrollBar.value;
    private void SetScrollBarValue(float value)
    {
        _scrollBar.value = value;
    }

    private void OnSelectButtonClicked()
    {
        _bgImage.sprite = _slotControllers[_currentSlotIndex].Sprite;
    }
}
