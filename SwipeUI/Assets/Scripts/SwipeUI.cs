using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

public class SwipeUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Scrollbar _scrollBar;
    [SerializeField] private SlotCreator _slotCreator;
    [SerializeField] private float _swipeThreshold;

    private List<SlotController> _slotControllers = new();
    private float _totalWidth = 0.0f;
    private float _startPosX = 0.0f;
    private float _endPosX = 0.0f;
    private int _currentSlotIndex = -1;
    private Tween _scrollTween;

    private void Awake()
    {
        _slotCreator.OnCreateSlot += OnCreateSlot;
    }

    private void OnDestroy()
    {
        _slotCreator.OnCreateSlot -= OnCreateSlot;
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

        float baseValue = _slotControllers.Count <= 1 ? 0f : (float)(_currentSlotIndex) / (_slotControllers.Count - 1);
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

        float targetValue = _slotControllers.Count <= 1 ? 0.0f : (float)(_currentSlotIndex) / (_slotControllers.Count - 1);
        _scrollTween = DOTween.To(
                () => _scrollBar.value,
                x => _scrollBar.value = x,
                targetValue,
                0.3f
            ).SetEase(Ease.OutQuad);
    }

    private void OnCreateSlot(SlotController newSlotController)
    {
        if (_currentSlotIndex == -1)
        {
            _currentSlotIndex = 0;
        }

        _totalWidth += newSlotController.Width;
        _slotControllers.Add(newSlotController);
    }
}
