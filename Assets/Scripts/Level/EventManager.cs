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
        _as.PlayOneShot(_jumpSound);
    }

    public void PlayBubbleClip()
    {
        _as.PlayOneShot(_bubbleSound);
    }

    public void PlayRunningClip()
    {
        _as.PlayOneShot(_runningSound);
    }

    public void StopAudioSource()
    {
        _as.Stop();
    }
}
