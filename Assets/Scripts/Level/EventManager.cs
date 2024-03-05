using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    [SerializeField] private string _levelToLoad;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _bubbleSound;
    [SerializeField] private AudioClip _runningSound;
    [SerializeField] private AudioSource _as;

    public void TriggerEvent()
    {
        SceneManager.LoadScene(_levelToLoad);
    }

    public void PlayJumpClip()
    {
        if(_as.enabled != false)
        {
            _as.PlayOneShot(_jumpSound);
        }
    }

    public void PlayBubbleClip()
    {
        if (_as.enabled != false)
        {
            _as.PlayOneShot(_bubbleSound);
        }
    }

    public void PlayRunningClip()
    {
        if (_as.enabled != false)
        {
            _as.PlayOneShot(_runningSound);
        }
    }

    public void StopAudioSource()
    {
        if (_as.enabled != false)
        {
            _as.Stop();
        }
    }
}
