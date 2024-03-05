using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private GameObject _doorsParent;
    [SerializeField] private bool _isTwoKeyMode = false;
    [SerializeField] private bool _IsFirstKey;
    [SerializeField] private bool _IsSecondKey;
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip _cakeCollectClip;
    [SerializeField] private AudioClip _keyCollectClip;

    static private bool _isFirstKeyCollected;
    static private bool _isSecondKeyCollected;

    private bool _cakeCollected;

    private void Start()
    {
        _isFirstKeyCollected = false;
        _isSecondKeyCollected = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string collidedTag = gameObject.tag;

            if (collidedTag == "Cake")
            {
                _cakeCollected = true;
                PlaySound(_cakeCollectClip);
            }
            else if (collidedTag == "Key")
            {
                PlaySound(_keyCollectClip);
                if (_isTwoKeyMode)
                {
                    if (_IsFirstKey)
                    {
                        _isFirstKeyCollected = true;
                    }
                    else if (_IsSecondKey)
                    {
                        _isSecondKeyCollected = true;
                    }

                    if (_isFirstKeyCollected && _isSecondKeyCollected)
                    {
                        OpenDoors();
                    }
                }
                else
                {
                    OpenDoors();
                }
            }       
            gameObject.SetActive(false);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (_as.enabled != false)
        {
            GameObject soundObject = new("TempSoundObject");
            AudioSource audioSource = soundObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = 0.25f;
            audioSource.Play();
            Destroy(soundObject, clip.length);
        }
    }

    private void OpenDoors()
    {
        if (_doorsParent != null)
        {
            _doorsParent.SetActive(false);
        }
    }

    private bool IsCakeCollectedOnThisLevel()
    {
        string levelName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        return PlayerPrefs.GetInt(levelName + "_CakeCollected", 0) != 0;
    }

    private void SaveCakeCollectedState()
    {
        string levelName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt(levelName + "_CakeCollected", 1);
        PlayerPrefs.Save();
    }

    public void PortalVisited()
    {
        if (_cakeCollected && !IsCakeCollectedOnThisLevel())
        {
            GameManager._countOfCake += 1;
            GameManager.SaveGameData();
            SaveCakeCollectedState();
        }
    }
}