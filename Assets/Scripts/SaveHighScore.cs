using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveHighScore : MonoBehaviour
{
    public static SaveHighScore Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public float highScore;
    }

    public void SaveBestScore(float highScore)
    {
        SaveData data = new SaveData();
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savehighscore.json", json);
    }

    public float LoadBestScore()
    {
        float highScore = 0;
        string path = Application.persistentDataPath + "/savehighscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
        }

        return highScore;
    }
}
