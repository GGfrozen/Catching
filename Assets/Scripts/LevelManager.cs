using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    [Header("Score")]
    [SerializeField] int totalPoints = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Text finalScoreText;


    [Header("Lifes")]
    [SerializeField] int lifesCount = 3;

    private int bestScore = 0;

    public int ReturnLifeCunt()
    {
        return lifesCount;
    }
    public void ChangeScore(int points)
    {
        totalPoints += points;

        ChangeScore();
    }
    public void ChangeLifesCount()
    {
        lifesCount -= 1;
        UIManager.Instance.LifeDown(lifesCount);
        if (lifesCount <= 0)
        {
            UIManager.Instance.ActivateLoseGamePanel();
            GetFinalScore();
            ModifyBestScore(totalPoints);
            Time.timeScale = 0;
        }

    }
    public void ResetScore()
    {
        totalPoints = 0;
        lifesCount = 3;
        ChangeScore();
    }
    public void AddLife()
    {
        if (lifesCount < 3)
        {
            lifesCount++;
            UIManager.Instance.ResetLifes();
        }
    }
    public void GravityChange(float delay,float value)
    {
        StartCoroutine(ChangeGravity(delay, value));
    }
    private void ChangeScore()
    {
        scoreText.text = "SCORE : " + totalPoints;
    }
    private void GetFinalScore()
    {
        finalScoreText.text = "SCORE : " + totalPoints;
    }
    private void ModifyBestScore(int score)
    {
        if (bestScore < score)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", score);
        }

    }
    private IEnumerator ChangeGravity(float delay, float value)
    {
        float standartGravity = -9.81f;
        Physics2D.gravity = new Vector2(0, value);
        yield return new WaitForSeconds(delay);
        Physics2D.gravity = new Vector2(0, standartGravity);
    }
}
