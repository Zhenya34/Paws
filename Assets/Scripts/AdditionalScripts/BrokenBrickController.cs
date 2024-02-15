using System.Collections;
using UnityEngine;

public class BrokenBrickController : MonoBehaviour
{
    public float destryDelay = 3;
    public Sprite destroyBrickSprite;
    private SpriteRenderer _sr;

    private void Start()
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
