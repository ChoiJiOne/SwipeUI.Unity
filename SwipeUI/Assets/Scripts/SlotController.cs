using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public float Width => _rectTransform.rect.width;
    public Sprite Sprite => _image.sprite;
    
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Image _image;
}
