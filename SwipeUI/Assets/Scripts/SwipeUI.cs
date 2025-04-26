using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class SwipeUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Scrollbar _scrollBar;
    [SerializeField] private SlotCreator _slotCreator;

    private List<SlotController> _slotControllers = new();
    private float _startPosX = 0.0f;
    private float _endPosX = 0.0f;
    private int _currentSlotIndex = -1;

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
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _endPosX = eventData.position.x;
    }

    private void OnCreateSlot(SlotController newSlotController)
    {
        _slotControllers.Add(newSlotController);
    }
}
