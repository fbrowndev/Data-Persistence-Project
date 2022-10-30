using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


/// <summary>
/// Handling all high score details
/// </summary>
public class HighScore : MonoBehaviour
{
    #region HighScore Variables
    public string PlayerName;
    public int Score;
    public string bestPlayer;
    public int bestScore;

    #endregion

    public static HighScore Instance;


    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance);
        } else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #region Saved Data

    [System.Serializable]
    class SaveData
    {
        public string savePlayer;
        public int saveScore;
    }

    public void HighScoreData(string bestPlayer, int bestScore)
    {
        SaveData data = new SaveData();
        data.savePlayer = bestPlayer;
        data.saveScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayer = data.savePlayer;
            bestScore = data.saveScore;
        }
    }

    #endregion
}
