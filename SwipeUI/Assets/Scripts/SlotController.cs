using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
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
}
