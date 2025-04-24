using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public Color BgColor
    {
        get => _bgImage.color;
        set
        {
            _bgImage.color = value;
        }
    }

    [SerializeField] private Image _bgImage;
}
