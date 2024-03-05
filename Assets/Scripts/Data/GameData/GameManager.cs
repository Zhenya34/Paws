using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public int _countOfCake;
    static public int _countOfJumps;
    static public int _countOfDeaths;
    static private float _allTimeInGame;

    [SerializeField] private TMP_Text countOfCakeText;
    [SerializeField] private TMP_Text countOfJumpsText;
    [SerializeField] private TMP_Text countOfDeathsText;
    [SerializeField] private TMP_Text allTimeInGameText;

    private float _startTime;
    private float _lastSaveTime;
    private readonly float _saveInterval = 5f;

    private void Awake()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("NoReboot");

        if (gameObjects.Length > 1)
        {
            for (int i = 0; i < gameObjects.Length - 1; i++)
            {
                Destroy(gameObjects[i]);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadGameData();
        UpdateUIText();
        _startTime = Time.time;
    }

    private void Update()
    {
        float deltaTime = Time.time - _startTime;
        _allTimeInGame += deltaTime;
        _startTime += deltaTime;
        UpdateUIText();

        if (Time.time - _lastSaveTime >= _saveInterval)
        {
            SaveGameData();
            _lastSaveTime = Time.time;
        }
    }

    public static int CountOfDeaths
    {
        get { return _countOfDeaths; }
        set { _countOfDeaths = value; }
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }

    public static void SaveGameData()
    {
        PlayerPrefs.SetInt("CountOfCake", _countOfCake);
        PlayerPrefs.SetInt("CountOfJumps", _countOfJumps);
        PlayerPrefs.SetInt("CountOfDeaths", _countOfDeaths);
        PlayerPrefs.SetFloat("AllTimeInGame", _allTimeInGame);
        PlayerPrefs.Save();
    }

    private void LoadGameData()
    {
        _countOfCake = PlayerPrefs.GetInt("CountOfCake", 0);
        _countOfJumps = PlayerPrefs.GetInt("CountOfJumps", 0);
        _countOfDeaths = PlayerPrefs.GetInt("CountOfDeaths", 0);
        _allTimeInGame = PlayerPrefs.GetFloat("AllTimeInGame", 0f);
    }

    public void UpdateUIText()
    {
        if (countOfCakeText != null && countOfJumpsText != null && countOfDeathsText != null && allTimeInGameText != null)
        {
            countOfCakeText.text = _countOfCake.ToString();
            countOfJumpsText.text = _countOfJumps.ToString();
            countOfDeathsText.text = _countOfDeaths.ToString();
            allTimeInGameText.text = Mathf.Round(_allTimeInGame).ToString();
        }
    }
}
