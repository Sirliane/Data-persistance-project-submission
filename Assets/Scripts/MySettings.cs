using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MySettings : MonoBehaviour
{
    public static MySettings Instance;
    public string PlayerName;
    public string BestPlayer;
    public int BestScore;


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        BestPlayer = "";
        PlayerName = "";
        BestScore = 0;
        LoadData();
    }
    public void SaveData()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.BestPlayer = BestPlayer;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            BestPlayer = data.BestPlayer;
            BestScore = data.BestScore;
        }
    }
}


    [System.Serializable]
class SaveData
 {
    public string PlayerName;
    public string BestPlayer;
    public int BestScore;
 }
