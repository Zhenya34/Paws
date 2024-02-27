using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    [SerializeField] private string levelToLoad;
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip portalClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PlaySoundAndLoadLevel());
        }
    }

    private System.Collections.IEnumerator PlaySoundAndLoadLevel()
    {
        _as.PlayOneShot(portalClip);
        yield return new WaitForSeconds(portalClip.length);
        SceneManager.LoadScene(levelToLoad);
    }
}