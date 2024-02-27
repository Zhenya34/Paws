using System.Collections;
using UnityEngine;

public class TrampolineController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Sprite activatedTrampoline;
    [SerializeField] private Sprite deactivatedTrampoline;
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private float raiseHeight = 0.1f;

    private SpriteRenderer _sr;    

    private void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        SetTrampolineSprite(deactivatedTrampoline);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            ApplyForce();
            SetTrampolineSprite(deactivatedTrampoline);
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
