using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour
{
    public float shotDelay = 3f;
    public float recoilDelay = 0.6f;
    public GameObject bulletPrefab;
    public Transform bullerSpawnPoint;
    public Sprite activatedCannon;
    public Sprite deactivatedCannon;

    private SpriteRenderer _sr;
    private bool _isReloading = false;

    private void Start()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        SetCannonSprite(deactivatedCannon);
    }

    private void Update()
    {
        if (!_isReloading)
        {
            Shot();
            StartCoroutine(ShotDelay());            
        }
    }

    private void Shot()
    {
        _isReloading = true;
        Instantiate(bulletPrefab, bullerSpawnPoint.position, bullerSpawnPoint.rotation);
        SetCannonSprite(activatedCannon);
        StartCoroutine(Recoil());
    }

    private void SetCannonSprite(Sprite spriteRenderer)
    {
        _sr.sprite = spriteRenderer;
    }

    private IEnumerator Recoil()
    {
        yield return new WaitForSeconds(recoilDelay);
        SetCannonSprite(deactivatedCannon);
    }

    private IEnumerator ShotDelay()
    {        
        yield return new WaitForSeconds(shotDelay);
        _isReloading = false;
    }
}