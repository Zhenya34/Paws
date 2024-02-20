using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour
{
    [SerializeField] private float shotDelay = 3f;
    [SerializeField] private float recoilDelay = 0.6f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bullerSpawnPoint;
    [SerializeField] private Sprite activatedCannon;
    [SerializeField] private Sprite deactivatedCannon;
    [SerializeField] private float startShotDelay = 1.5f;
    [SerializeField] private bool startWithDelay;

    private SpriteRenderer _sr;
    private bool _isReloading = false;

    private void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        SetCannonSprite(deactivatedCannon);

        if (startWithDelay)
        {
            _isReloading = true;
            StartCoroutine(StartShotDelay());
        }
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

    private IEnumerator StartShotDelay()
    {
        yield return new WaitForSeconds(startShotDelay);
        _isReloading = false;
    }
}