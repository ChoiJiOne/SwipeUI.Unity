using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public UnityAction<SlotController> OnDestroySlot;
    public float Width => _rectTransform.rect.width;
    
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Button _okButton;
    [SerializeField] private Image _bgImage;
    [SerializeField] private Sprite[] _bgSprites;

    private void Awake()
    {
        _okButton.onClick.AddListener(OnOkButtonClicked);

        int randomIndex = Random.Range(0, _bgSprites.Length);
        _bgImage.sprite = _bgSprites[randomIndex];
    }

    private void OnOkButtonClicked()
    {
        OnDestroySlot?.Invoke(this);
        Destroy(gameObject);
    }
}
