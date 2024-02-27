using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private GameObject doorsParent;
    [SerializeField] private bool isTwoKeyMode = false;
    [SerializeField] private bool IsFirstKey;
    [SerializeField] private bool IsSecondKey;
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip cakeCollectClip;
    [SerializeField] private AudioClip keyCollectClip;

    static private bool _isFirstKeyCollected;
    static private bool _isSecondKeyCollected;

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
                MainMenuCanvasLogic.countOfCake += 1;
                PlaySound(cakeCollectClip);
            }                          
            else if (collidedTag == "Key")
            {
                PlaySound(keyCollectClip);
                if (isTwoKeyMode)
                {
                    if (IsFirstKey)
                    {
                        _isFirstKeyCollected = true;
                    }
                    else if (IsSecondKey)
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
        GameObject soundObject = new("TempSoundObject");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = 0.35f;
        audioSource.Play();
        Destroy(soundObject, clip.length);
    }

    private void OpenDoors()
    {
        if (doorsParent != null)
        {
            doorsParent.SetActive(false);
        }
    }
}