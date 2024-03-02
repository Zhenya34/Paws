using UnityEngine;

public class MainMenuSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip _musicButtonClip;
    [SerializeField] private AudioClip _pressingSoundClip;
    [SerializeField] private AudioClip _closingSoundClip;

    public AudioClip _selectedLevelClip;

    public void PlayMusicButtonClip()
    {
        _as.PlayOneShot(_musicButtonClip);
    }

    public void PlayPressingButtonSound()
    {
        _as.PlayOneShot(_pressingSoundClip);
    }

    public void PlaySelectedLevelClip()
    {
        _as.PlayOneShot(_selectedLevelClip);
    }

    public void PlayClosingSound()
    {
        _as.PlayOneShot(_closingSoundClip);
    }
}
