using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private GameObject doorsParent;
    [SerializeField] private bool isTwoKeyMode = false;
    [SerializeField] private bool IsFirstKey;
    [SerializeField] private bool IsSecondKey;

    static private bool _isFirstKeyCollected;
    static private bool _isSecondKeyCollected;

    private void Start()
    {
        _isFirstKeyCollected = false;
        _isSecondKeyCollected = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string collidedTag = gameObject.tag;

            if (collidedTag == "Cake")
            {
                MainMenuCanvasLogic.countOfCake += 1;
            }                          
            else if (collidedTag == "Key")
            {
                if (isTwoKeyMode)
                {
                    if (IsFirstKey)
                    {
                        _isFirstKeyCollected = true;
                    }
                    else if (IsSecondKey)
                    {
                        _isSecondKeyCollected = true;
                    }

                    if (_isFirstKeyCollected && _isSecondKeyCollected)
                    {
                        OpenDoors();
                    }
                }
                else
                {
                    OpenDoors();
                }                
            }       
            gameObject.SetActive(false);
        }
    }

    private void OpenDoors()
    {
        if (doorsParent != null)
        {
            doorsParent.SetActive(false);
        }
    }
}