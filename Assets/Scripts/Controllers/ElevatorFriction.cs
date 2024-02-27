using UnityEngine;

public class PlatformFriction : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            collision2D.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            collision2D.transform.SetParent(null);
        }
    }
}