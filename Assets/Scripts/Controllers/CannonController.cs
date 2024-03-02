using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour
{
    [SerializeField] private float _shotDelay = 3f;
    [SerializeField] private float _recoilDelay = 0.6f;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private Sprite _activatedCannon;
    [SerializeField] private Sprite _deactivatedCannon;
    [SerializeField] private float _startShotDelay = 1.5f;
    [SerializeField] private bool _startWithDelay;
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip _shotClip;

    private SpriteRenderer _sr;
    private bool _isReloading = false;

    private void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        SetCannonSprite(_deactivatedCannon);

        if (_startWithDelay)
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
        Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
        _as.PlayOneShot(_shotClip);
        SetCannonSprite(_activatedCannon);
        StartCoroutine(Recoil());
    }

    private void SetCannonSprite(Sprite spriteRenderer)
    {
        _sr.sprite = spriteRenderer;
    }

    private IEnumerator Recoil()
    {
        yield return new WaitForSeconds(_recoilDelay);
        SetCannonSprite(_deactivatedCannon);
    }

    private IEnumerator ShotDelay()
    {        
        yield return new WaitForSeconds(_shotDelay);
        _isReloading = false;
    }

    private IEnumerator StartShotDelay()
    {
        yield return new WaitForSeconds(_startShotDelay);
        _isReloading = false;
    }
}