using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Sprite pressedSprite;
    [SerializeField] private Sprite unpressedSprite;
    [SerializeField] private float raiseHeight;
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private GameObject wallDoorParent;

    [SerializeField] private bool IsFirstButton;
    [SerializeField] private bool IsSecondButton;

    [SerializeField] private bool IsTwoButtonMode = false;

    private SpriteRenderer _sr;
    static private int countTriggerOnFirstButton = 0;
    static private int countTriggerOnSecondButton = 0;

    private void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            if (IsTwoButtonMode)
            {
                if (IsFirstButton)
                {
                    if(countTriggerOnFirstButton == 0)
                    {
                        SetButtonSprite(pressedSprite);
                    }
                    countTriggerOnFirstButton++;
                }
                else if (IsSecondButton)
                {
                    if(countTriggerOnSecondButton == 0)
                    {
                        SetButtonSprite(pressedSprite);
                    }
                    countTriggerOnSecondButton++;
                }    
            }
            else
            {
                if (countTriggerOnFirstButton == 0)
                {
                    wallDoorParent.SetActive(false);
                    SetButtonSprite(pressedSprite);
                }
                countTriggerOnFirstButton++;
            }
        }

        if (countTriggerOnFirstButton > 0 && countTriggerOnSecondButton > 0)
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
                if (IsFirstButton)
                {
                    if (countTriggerOnFirstButton > 0)
                    {
                        countTriggerOnFirstButton--;
                        if (countTriggerOnFirstButton == 0)
                        {
                            SetButtonSprite(unpressedSprite);
                        }
                    }
                }
                else if (IsSecondButton)
                {
                    if (countTriggerOnSecondButton > 0)
                    {
                        countTriggerOnSecondButton--;
                        if (countTriggerOnSecondButton == 0)
                        {
                            SetButtonSprite(unpressedSprite);
                        }
                    }
                }
            }
            else
            {
                if (countTriggerOnFirstButton > 0)
                {
                    countTriggerOnFirstButton--;
                    if (countTriggerOnFirstButton == 0)
                    {
                        SetButtonSprite(unpressedSprite);
                    }
                }
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