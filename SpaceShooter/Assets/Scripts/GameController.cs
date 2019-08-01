﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AudioClip LoseClip;
    public AudioSource audioSource;
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    private bool gameOver;
    private bool restart;
    private int score;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());  
        MusicSource.clip = MusicClip; 
        audioSource.clip = LoseClip;
    }
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.L))
            {
                SceneManager.LoadScene("Main");
            }
        }
        if (Input.GetKey("escape"))
            Application.Quit();

    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
                {   
                    GameObject hazard = hazards [Random.Range (0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
                {
                    restartText.text = "Press 'L' for Restart";
                    restart = true;
                    break;
                    
                }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void GameOver ()
    {
        gameOverText.text = "Game Over! Game Created by Melisa";
        gameOver = true;
        audioSource.Play();
    }

    void UpdateScore()
        {
            ScoreText.text = "Points: " + score;
            if (score >= 100)
            {
                gameOverText.text = "You win! Game Created By Melisa";
                gameOver = true;
                restart = true;
                MusicSource.Play();
         
            }
        }
}