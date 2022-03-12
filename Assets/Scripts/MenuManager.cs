using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI Username;
    [SerializeField] private TextMeshProUGUI BestScore;
    // Start is called before the first frame update
    void Start()
    {
        if (SavedData.Instance.isThereSavedData())
        {
            SavedData.Instance.LoadScore();
            BestScore.text = SavedData.Instance.BestScoreUsername + ": " + SavedData.Instance.BestScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetLeaderboard()
    {
        if (SavedData.Instance.isThereSavedData())
        {
            File.Delete(Application.persistentDataPath + "/savefile.json");
            BestScore.text = "Best Score: 0";
        }
    }
    public void StartNew()
    {
        SavedData.Instance.username = Username.text;
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        
    }
}
