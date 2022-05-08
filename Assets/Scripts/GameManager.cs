using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Tham chiếu prefab
    [SerializeField] private GameObject waterPilePrefab;
    // Tham chiếu đoạn Text là Score
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    // Tham chiếu GameObject GameOver
    [SerializeField] private GameObject gameOver;

    // Thời gian chờ để tạo ra ống nước khi trò chơi bắt đầu
    private float startDelay = 2.0f;
    // Khoảng thời gian chờ để tạo ra các ống nước tiếp theo
    private float spawnTime = 5f;
    // Tạo ra 1 biến để kiểm tra xem trò chơi có đang chạy hay không
    public bool isPlaying;
    // Tạo ra 1 biến để chứa điểm hiện tại
    private float score = 0.0f;
    // Tạo ra 1 biến chứa high score;
    private float highScore = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
        DisplayHighScore();
        InvokeRepeating("SpawnManager", startDelay, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Tạo ra method để tạo ra các đường uống nước sau 1 khoảng thời gian nhất định
    void SpawnManager()
    {
        // Tạo ra pham vị của tọa độ y
        float rangeY = 2.0f;
        // Tọa độ x
        float posX = 14.0f;

        if (isPlaying == true)
        {
            float randomPosY = Random.Range(-rangeY, rangeY);
            Vector2 randomPos = new Vector2(posX, randomPosY);

            Instantiate(waterPilePrefab, randomPos, waterPilePrefab.transform.rotation);
        }

    }

    public void GameOver()
    {
        isPlaying = false;
        gameOver.gameObject.SetActive(true);
        AddHighScore();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void AddHighScore()
    {
        if (score > highScore)
        {
            SaveHighScore.Instance.SaveBestScore(score);
            DisplayHighScore();
        }
    }

    public void DisplayHighScore()
    {
        highScore = SaveHighScore.Instance.LoadBestScore();
        highScoreText.text = "High Score: " + highScore;
    }

}
