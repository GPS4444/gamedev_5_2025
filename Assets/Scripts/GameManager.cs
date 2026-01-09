using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> targets;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverText;

    private int score = 0;
    [SerializeField] float spawnRate;
    public bool isGameActive;

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }

    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    void Update()
    {
        
    }
}
