using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Sprite pressedSprite;
    [SerializeField] private Sprite unpressedSprite;
    [SerializeField] private float raiseHeight;
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private GameObject wallDoorParent;

    [SerializeField] private bool IsFirtsButton;
    [SerializeField] private bool IsSecondButton;

    [SerializeField] private bool IsTwoButtonMode = false;

    private SpriteRenderer _sr;
    static private bool _isFirstButtonPressed = false;
    static private bool _isSecondButtonPressed = false;

    private void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        _isFirstButtonPressed = false;
        _isSecondButtonPressed = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            if (IsTwoButtonMode)
            {
                if (IsFirtsButton)
                {
                    _isFirstButtonPressed = true;
                }
                else if (IsSecondButton)
                {
                    _isSecondButtonPressed = true;
                }
                SetButtonSprite(pressedSprite);           
            }
            else
            {
                _isFirstButtonPressed = true;
                wallDoorParent.SetActive(false);
                SetButtonSprite(pressedSprite);
            }
        }

        if(_isFirstButtonPressed && _isSecondButtonPressed)
        {
            wallDoorParent.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            if (IsTwoButtonMode)
            {
                if (IsFirtsButton)
                {
                    _isFirstButtonPressed = false;
                }
                else if (IsSecondButton)
                {
                    _isSecondButtonPressed = false;
                }
                SetButtonSprite(unpressedSprite);
            }
            else
            {
                _isFirstButtonPressed = false;
                SetButtonSprite(unpressedSprite);
            }
        }
    }

    private void SetButtonSprite(Sprite spriteRenderer)
    {
        _sr.sprite = spriteRenderer;

        if (_sr.sprite == pressedSprite)
        {
            transform.Translate(raiseHeight * Vector3.down);
        }
        else
        {
            transform.position = initialPosition;
        }
    }
}