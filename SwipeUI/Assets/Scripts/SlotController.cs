using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public UnityAction<SlotController> OnDestroySlot;
    public float Width => _rectTransform.rect.width;

    public Color BgColor
    {
        get => _bgImage.color;
        set
        {
            _bgImage.color = value;
        }
    }

    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Image _bgImage;
    [SerializeField] private Button _okButton;

    private void Awake()
    {
        _okButton.onClick.AddListener(OnOkButtonClicked);
    }

    private void OnOkButtonClicked()
    {
        OnDestroySlot?.Invoke(this);
        Destroy(gameObject);
    }
}
