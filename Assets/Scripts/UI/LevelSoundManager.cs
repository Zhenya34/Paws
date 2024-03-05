using UnityEngine;
using System.Collections;

public class LevelSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip _musicButtonClip;
    [SerializeField] private AudioClip _pauseClip;
    [SerializeField] private AudioClip _soundOfDeath;
    [SerializeField] private GameObject _player;
    [SerializeField] private LevelCanvasLogic _levelCanvasLogic;

    public AudioClip _selectedLevelClip;
    public AudioClip _pressingSoundClip;

    public void PlaySelectedLevelClip()
    {
        if (_as.enabled != false)
        {
            _as.PlayOneShot(_selectedLevelClip);
        }  
    }

    public void PlayMusicButtonClip()
    {
        if (_as.enabled != false)
        {
            _as.PlayOneShot(_musicButtonClip);
        }
    }

    public void PlayPauseButtonSound()
    {
        if (_as.enabled != false)
        {
            _as.PlayOneShot(_pauseClip);
        }
    }

    public void PlayPressingButtonSound()
    {
        if (_as.enabled != false)
        {
            _as.PlayOneShot(_pressingSoundClip);
        }
    }

    public void PlaySoundOfDead()
    {
        if (_as.enabled != false)
        {
            _as.PlayOneShot(_soundOfDeath);
        }
        StartCoroutine(PlayMusicWithDelay());
    }
    
    private IEnumerator PlayMusicWithDelay()
    {
        Destroy(_player);
        yield return new WaitForSeconds(0.85f);
        _levelCanvasLogic.ReloadScene();
    }
}
