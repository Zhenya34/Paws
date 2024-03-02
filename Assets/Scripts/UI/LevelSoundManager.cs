using UnityEngine;
using System.Collections;

public class LevelSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip _pauseClip;
    [SerializeField] private AudioClip _soundOfDeath;
    [SerializeField] private GameObject _player;
    [SerializeField] private LevelCanvasLogic _levelCanvasLogic;
    
    public AudioClip pressingSoundClip;

    public void PlayPauseButtonSound()
    {
        _as.PlayOneShot(_pauseClip);
    }

    public void PlayPressingButtonSound()
    {
        _as.PlayOneShot(pressingSoundClip);
    }

    public void PlaySoundOfDead()
    {
        _as.PlayOneShot(_soundOfDeath);
        StartCoroutine(PlayMusicWithDelay());
    }
    
    private IEnumerator PlayMusicWithDelay()
    {
        Destroy(_player);
        yield return new WaitForSeconds(0.85f);
        _levelCanvasLogic.ReloadScene();
    }
}
