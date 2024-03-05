using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private float spawnRate = 1.0f;
    public List<GameObject> targets;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    
    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int scoretoAdd)
    {
        score += scoretoAdd;
        scoreText.text = "Score:" + score;
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {

        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
