using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    [SerializeField] private string _levelToLoad;
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip _portalClip;
    [SerializeField] private LevelAvailability _levelAvailability;
    private bool _isPortalSoundCoroutineLaunched = false;
    private bool _isNewLevelUnlocked = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_isPortalSoundCoroutineLaunched)
        {
/*            if (!_isNewLevelUnlocked)
            {
                _isNewLevelUnlocked = true;
                _levelAvailability.UnlockNextLevel();
            }*/
            _isPortalSoundCoroutineLaunched = true;
            StartCoroutine(PlaySoundAndLoadLevel());
        }
    }

    private IEnumerator PlaySoundAndLoadLevel()
    {
        _as.PlayOneShot(_portalClip);
        yield return new WaitForSeconds(_portalClip.length);
        SceneManager.LoadScene(_levelToLoad);
    }
}