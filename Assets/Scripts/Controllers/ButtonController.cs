using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Sprite _pressedSprite;
    [SerializeField] private Sprite _unpressedSprite;
    [SerializeField] private float _raiseHeight;
    [SerializeField] private Vector3 _initialPosition;
    [SerializeField] private GameObject _wallDoorParent;

    [SerializeField] private bool _isFirstButton;
    [SerializeField] private bool _isSecondButton;

    [SerializeField] private bool _isTwoButtonMode = false;
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip _pressingSound;
    private SpriteRenderer _sr;

    static private int _countTriggerOnFirstButton = 0;
    static private int _countTriggerOnSecondButton = 0;

    private void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            if (_isTwoButtonMode)
            {
                if (_isFirstButton)
                {
                    if(_countTriggerOnFirstButton == 0)
                    {
                        SetButtonSprite(_pressedSprite);
                    }
                    _countTriggerOnFirstButton++;
                }
                else if (_isSecondButton)
                {
                    if(_countTriggerOnSecondButton == 0)
                    {
                        SetButtonSprite(_pressedSprite);
                    }
                    _countTriggerOnSecondButton++;
                }    
            }
            else
            {
                if (_countTriggerOnFirstButton == 0)
                {
                    _wallDoorParent.SetActive(false);
                    SetButtonSprite(_pressedSprite);
                }
                _countTriggerOnFirstButton++;
            }
        }

        if (_countTriggerOnFirstButton > 0 && _countTriggerOnSecondButton > 0)
        {
            _wallDoorParent.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            if (_isTwoButtonMode)
            {
                if (_isFirstButton)
                {
                    if (_countTriggerOnFirstButton > 0)
                    {
                        _countTriggerOnFirstButton--;
                        if (_countTriggerOnFirstButton == 0)
                        {
                            SetButtonSprite(_unpressedSprite);
                        }
                    }
                }
                else if (_isSecondButton)
                {
                    if (_countTriggerOnSecondButton > 0)
                    {
                        _countTriggerOnSecondButton--;
                        if (_countTriggerOnSecondButton == 0)
                        {
                            SetButtonSprite(_unpressedSprite);
                        }
                    }
                }
            }
            else
            {
                if (_countTriggerOnFirstButton > 0)
                {
                    _countTriggerOnFirstButton--;
                    if (_countTriggerOnFirstButton == 0)
                    {
                        SetButtonSprite(_unpressedSprite);
                    }
                }
            }
        }
    }

    private void SetButtonSprite(Sprite spriteRenderer)
    {
        _sr.sprite = spriteRenderer;

        if (_sr.sprite == _pressedSprite)
        {
            transform.Translate(_raiseHeight * Vector3.down);
            _as.PlayOneShot(_pressingSound);
        }
        else if(_sr.sprite == _unpressedSprite)
        {
            transform.position = _initialPosition;
            _as.PlayOneShot(_pressingSound);
        }
    }
}