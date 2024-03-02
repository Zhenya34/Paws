using System.Collections;
using UnityEngine;

public class TrampolineController : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private Sprite _activatedTrampoline;
    [SerializeField] private Sprite _deactivatedTrampoline;
    [SerializeField] private Vector3 _initialPosition;
    [SerializeField] private float _raiseHeight = 0.1f;
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip _jumpSound;

    private SpriteRenderer _sr;    

    private void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        SetTrampolineSprite(_deactivatedTrampoline);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            ApplyForce();
            SetTrampolineSprite(_deactivatedTrampoline);
            SetTrampolineSprite(_activatedTrampoline);
            StartCoroutine(TrampolineDelay());
        }             
    }

    private void ApplyForce()
    {
        _playerRb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        _as.PlayOneShot(_jumpSound);
    }

    private void SetTrampolineSprite(Sprite spriteRenderer)
    {
        _sr.sprite = spriteRenderer;

        if(_sr.sprite == _activatedTrampoline)
        {
            transform.Translate(Vector3.up * _raiseHeight);
        }
        else
        {
            transform.position = _initialPosition;
        }            
    }

    private IEnumerator TrampolineDelay()
    {
        yield return new WaitForSeconds(1f);
        SetTrampolineSprite(_deactivatedTrampoline);
    }
}
