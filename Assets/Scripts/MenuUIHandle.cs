using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandle : MonoBehaviour
{
    float highScore = 0;
    [SerializeField] private TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        DisplayHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayHighScore()
    {
        highScore = SaveHighScore.Instance.LoadBestScore();
        highScoreText.text = "High Score: " + highScore;
    }

    public void StartNew()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        EditorApplication.ExitPlaymode();
    }
}
