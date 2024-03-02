using UnityEngine;

public class MainSoundTheme : MonoBehaviour
{
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip[] _musicTracks;
    private int _currentTrackIndex = 0;

    private void Start()
    {
        PlayNextTrack();
    }

    private void Update()
    {
        if (!_as.isPlaying)
        {
            PlayNextTrack();
        }
    }

    private void PlayNextTrack()
    {
        _currentTrackIndex = (_currentTrackIndex + 1) % _musicTracks.Length;
        _as.clip = _musicTracks[_currentTrackIndex];
        _as.Play();
    }
}
