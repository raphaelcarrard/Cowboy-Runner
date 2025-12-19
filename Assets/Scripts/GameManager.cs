using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField]
    public GameObject pausePanel, gameOverPanel;

    [SerializeField]
    public Button pauseButton, resumeButton, playAgainButton, gotoMenuButton;

    public Text scoreText, coinScore, bestScore, highCoinScore, gameOverBestScore,
    gameOverHighCoinScore;

    [SerializeField]
    public Text newHighScoreText, newHighCoinText;

    [SerializeField]
    public Image highScoresImage;

    public AudioSource audioSource;
    public AudioClip cheerClip;
    public Transform groundGenerator;

    private Vector3 groundStartPoint;

    public PlayerMove player;

    private Vector3 playerStartPoint;

    void Start()
    {
        groundStartPoint = groundGenerator.position;
        playerStartPoint = player.transform.position;
    }

    public void RestartGame(){
        StartCoroutine("RestartGameCoroutine");
    }

    public IEnumerator RestartGameCoroutine(){
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        player.transform.position = playerStartPoint;
        groundGenerator.position = groundStartPoint;
        player.gameObject.SetActive(true);
    }

    public void PauseGame(){
        pausePanel.SetActive(true);
        bestScore.text = "Best Score: " + PlayerPrefs.GetInt("bestScore");
        highCoinScore.text = "Best Coin Score: " + PlayerPrefs.GetInt("bestCoinScore");
        Time.timeScale = 0f;
    }

    public void ResumeGame(){
        pausePanel.SetActive(false);
        scoreText.text = "Score: " + PlayerMove.instance.scoreCount;
        Time.timeScale = 1f;
    }

    public void PlayAgain(){
        Time.timeScale = 1f;
        pauseButton.gameObject.SetActive(true);
        SceneManager.LoadScene("Game");
        gameOverPanel.SetActive(false);
    }

    public void GoToMenu(){
        SceneManager.LoadScene("Main");
    }

    public void SetCoinScore(int score){
        coinScore.text = "Coin: " + score;
    }

    public void SetScore(){
        scoreText.text = "Score: " + PlayerMove.instance.scoreCount;
    }

    public void GameOver(int score, int coins){
        coinScore.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        gameOverBestScore.text = "Your Score: " + score;
        gameOverHighCoinScore.text = "Your Coin Score: " + coins;
    }

    public void IfPlayerDiedScore(int score){
        bestScore.text = "Best Score: " + PlayerMove.instance.scoreCount;
        if(score > Scores.instance.GetHighScore()){
            Scores.instance.SetHighScore(score);
            newHighScoreText.gameObject.SetActive(true);
            highScoresImage.gameObject.SetActive(true);
            audioSource.PlayOneShot(cheerClip);
            Debug.Log("New High Score");
        }
        bestScore.text = "Best Score: " + Scores.instance.GetHighScore();
    }

    public void IfPlayerDiedCoinScore(int score){
        highCoinScore.text = "Best Coin Score: " + coinScore;
        if(score > Scores.instance.GetHighCoinScore()){
            Scores.instance.SetHighCoinScore(score);
            newHighCoinText.gameObject.SetActive(true);
            highScoresImage.gameObject.SetActive(true);
            audioSource.PlayOneShot(cheerClip);
        }
        highCoinScore.text = "Best Coin Score: " + Scores.instance.GetHighCoinScore();
    }
}
