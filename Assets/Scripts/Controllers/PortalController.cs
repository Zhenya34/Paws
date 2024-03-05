using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    [SerializeField] private string _levelToLoad;
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip _portalClip;
    [SerializeField] private LevelAvailability _levelAvailability;
    [SerializeField] private ItemController itemController;
    private bool _isPortalSoundCoroutineLaunched = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_isPortalSoundCoroutineLaunched)
        {
            _isPortalSoundCoroutineLaunched = true;
            if(itemController != null)
            {
                itemController.PortalVisited();
            }
            StartCoroutine(PlaySoundAndLoadLevel());
        }
    }

    private IEnumerator PlaySoundAndLoadLevel()
    {
        if (_as.enabled != false)
        {
            _as.PlayOneShot(_portalClip);
        }
        yield return new WaitForSeconds(_portalClip.length);
        SceneManager.LoadScene(_levelToLoad);
    }
}