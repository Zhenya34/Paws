using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private MainMenuCanvasLogic _mainMenuCanvasLogic;
    [SerializeField] private GameObject _mainMusicManager;
    [SerializeField] private AudioSource _levelSoundMamager;
    [SerializeField] private AudioSource[] _soundSources;

    [SerializeField] private CanvasGroup _controlsLeft;
    [SerializeField] private CanvasGroup _controlsRight;
    [SerializeField] private CanvasGroup _controlsUp;

    static private bool _isMusicEnabled = true;
    static private bool _isSoundEnabled = true;
    static private bool _isControlsEnabled = true;

    private void Start()
    {
        if (_isControlsEnabled)        
            ActivateGlobalControls();        
        else        
            DeactivateGlobalControls();
        
        
        if (_isMusicEnabled)        
            ActivateGlobalMusic();        
        else        
            DeactivateGlobalMusic();
       

        if (_isSoundEnabled)        
            ActivateGlobalSound();        
        else        
            DeactivateGlobalSound();
    }

    public void ActivateGlobalControls()
    {
        if (_controlsUp != null)
        {
            _controlsLeft.alpha = 1;
            _controlsRight.alpha = 1;
            _controlsUp.alpha = 1;
        }
        _isControlsEnabled = true;
    }

    public void DeactivateGlobalControls()
    {
        if(_controlsUp != null)
        {
            _controlsLeft.alpha = 0;
            _controlsRight.alpha = 0;
            _controlsUp.alpha = 0;
        }
        _isControlsEnabled = false;
    }

    public void ActivateGlobalMusic()
    {
        _mainMusicManager.SetActive(true);
        _isMusicEnabled = true;
        _mainMenuCanvasLogic.UpdateMusicButtonSprites(true);
    }

    public void DeactivateGlobalMusic()
    {
        _mainMusicManager.SetActive(false);
        _isMusicEnabled = false;
        _mainMenuCanvasLogic.UpdateMusicButtonSprites(false);
    }

    public void ActivateGlobalSound()
    {
        _levelSoundMamager.enabled = true;
        foreach (AudioSource source in _soundSources)
        {
            source.enabled = true;
        }
        _isSoundEnabled = true;
        _mainMenuCanvasLogic.UpdateSoundButtonSprites(true);
    }

    public void DeactivateGlobalSound()
    {
        _levelSoundMamager.enabled = false;
        foreach (AudioSource source in _soundSources)
        {
            source.enabled = false;
        }
        _isSoundEnabled = false;
        _mainMenuCanvasLogic.UpdateSoundButtonSprites(false);
    }
}