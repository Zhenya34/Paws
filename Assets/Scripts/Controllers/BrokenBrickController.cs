using System.Collections;
using UnityEngine;

public class BrokenBrickController : MonoBehaviour
{
    [SerializeField] private float destryDelay = 3;
    [SerializeField] private Sprite destroyBrickSprite;
    private SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _sr.sprite = destroyBrickSprite;
        StartCoroutine(DelayBeforeDestroy());
    }

    private IEnumerator DelayBeforeDestroy()
    {
        yield return new WaitForSeconds(destryDelay);
        Destroy(gameObject);
    }
}
