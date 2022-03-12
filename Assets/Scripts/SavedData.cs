using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavedData : MonoBehaviour
{
    // Start is called before the first frame update
    public static SavedData Instance;
    public string username;
    public string BestScoreUsername;
    public int BestScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool isThereSavedData()
    {
        return File.Exists(Application.persistentDataPath + "/savefile.json");
    }

    [System.Serializable]
    class SaveData
    {
        public string BestScoreUsername;
        public int BestScore;
    }

    public void SaveScore(int score)
    {
        SaveData data = new SaveData();
        data.BestScoreUsername = username;
        data.BestScore = score;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestScoreUsername = data.BestScoreUsername;
            BestScore = data.BestScore;
            
        }
    }
}
