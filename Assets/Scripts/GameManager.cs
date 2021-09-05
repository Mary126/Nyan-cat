using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Instances instances;
    private bool pause = false;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        instances = GetComponent<Instances>();
        instances.generator.GeneratePlatforms();
        instances.generator.GeneratePlatforms();
    }
    public void RenewScore(int points)
    {
        instances.score += (long)points;
        instances.scoreText.text = "Score: " + instances.score.ToString();
    }
    private void GameOver()
    {
        Debug.Log("Game over");
        Time.timeScale = 0;
        instances.gameOverScreen.SetActive(true);
    }
    private void Pause()
    {
        Time.timeScale = 0;
        instances.pauseScreen.SetActive(true);
    }
    private void Unpause()
    {
        Time.timeScale = 1;
        instances.pauseScreen.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (instances.PlayerRT.anchoredPosition.y <= 0)
        {
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                Pause();
                pause = true;
            }
            else
            {
                Unpause();
                pause = false;
            }
        }
    }
}
