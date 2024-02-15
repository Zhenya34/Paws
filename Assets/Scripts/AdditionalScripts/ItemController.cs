using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject doorsParent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            string collidedTag = collision.otherCollider.tag;

            if (collidedTag == "Cake")
            {
                MainMenuCanvasLogic.countOfCake += 1;
            }                          
            else if (collidedTag == "Key")
            {
                OpenDoors();
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