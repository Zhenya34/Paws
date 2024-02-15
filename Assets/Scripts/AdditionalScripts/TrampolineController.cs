using System.Collections;
using UnityEngine;

public class TrampolineController : MonoBehaviour
{
    public float jumpForce;
    public Rigidbody2D playerRb;    
    public Sprite activatedTrampoline;
    public Sprite deactivatedTrampoline;
    public Vector3 initialPosition;
    public float raiseHeight = 0.1f;

    private SpriteRenderer _sr;    

    private void Start()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        SetTrampolineSprite(deactivatedTrampoline);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ApplyForce();
            SetTrampolineSprite(activatedTrampoline);
            StartCoroutine(TrampolineDelay());
        }             
    }

    private void ApplyForce()
    {
        playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    private void SetTrampolineSprite(Sprite spriteRenderer)
    {
        _sr.sprite = spriteRenderer;

        if(_sr.sprite == activatedTrampoline)
        {
            transform.Translate(Vector3.up * raiseHeight);
        }
        else
        {
            transform.position = initialPosition;
        }            
    }

    private IEnumerator TrampolineDelay()
    {
        yield return new WaitForSeconds(1f);
        SetTrampolineSprite(deactivatedTrampoline);
    }
}
