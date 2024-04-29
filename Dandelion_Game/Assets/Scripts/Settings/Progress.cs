using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

/*[System.Serializable]
public class SettingsInfo
{
    public float volume;
    public float mouseSensitivity;

    public int audioToggle;
    public int postProcessingToggle;
}*/
[System.Serializable]
public class PlayerInfo
{
    public int coin;
    public bool[] maxLevelIndex = new bool[10];
    public string language;//ru|en
}  
public class Progress : MonoBehaviour
{
    //Progress.Instance.Save()
    //public SettingsInfo SettingsInfo;

    //Progress.Instance.SettingsInfo.audioToggle
    //Progress.Instance.SettingsInfo.postProcessingToggle

    public bool adShowing = false;
    public bool gameInPause = false;
    public bool playerAuthorized = false;
    public bool eventTest = false;

    /*[DllImport("__Internal")]
    private static extern void CheckAuthorization();*/

    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    public PlayerInfo PlayerInfo;
    public static Progress Instance;
    void Awake()
    {
        if(Instance == null){    
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            //LoadExtern();
            LoadDataFromPlayerPrefs();
            StartCoroutine(WaitOneSecond());
            if(eventTest) print($"Awake event in '{SceneManager.GetActiveScene().name}' scene");
        }else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (PlayerInfo.maxLevelIndex[0] == false){
            PlayerInfo.maxLevelIndex[0] = true;
            Debug.LogWarning("maxLevelIndex[0] == false");
        }
        SaveBoolSceneValue();
        if(eventTest) print($"Start event in '{SceneManager.GetActiveScene().name}' scene");
    }
    private void Update() {
        //CheckAuthorization();
    }
    private IEnumerator WaitOneSecond() {
        //CheckAuthorization();
        SaveBoolSceneValue();
        yield return new WaitForSeconds(1f);
        StartCoroutine(WaitOneSecond());
    }
    private void SaveBoolSceneValue() {
        if(SceneManager.GetActiveScene().name == "Cut-Scene_1" || SceneManager.GetActiveScene().name == "GamePlay_1"){
            PlayerInfo.maxLevelIndex[0] = true;
            Save_PlayerPrefs();
        } else if(SceneManager.GetActiveScene().name == "Cut-Scene_2" || SceneManager.GetActiveScene().name == "GamePlay_2"){
            PlayerInfo.maxLevelIndex[1] = true;
            Save_PlayerPrefs();
        }else if(SceneManager.GetActiveScene().name == "Cut-Scene_3" || SceneManager.GetActiveScene().name == "GamePlay_3"){
            PlayerInfo.maxLevelIndex[2] = true;
            Save_PlayerPrefs();
        }
        if(eventTest) print($"'SaveBoolSceneValue' event in '{SceneManager.GetActiveScene().name}' scene");
    }
    /*public void AuthorizationStatus(bool value){
        playerAuthorized = value;
    }*/
    public void Save_PlayerPrefs(){
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        PlayerPrefs.SetString("progressData", jsonString);
    }
    public void LoadDataFromPlayerPrefs(){
        if(PlayerPrefs.GetString("progressData") != ""){
            string value = PlayerPrefs.GetString("progressData");
            PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        }
    }
    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
    }public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
    }
}
