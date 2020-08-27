using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager Instance { get; private set; }

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

    [SerializeField] Text bestScoreText;
    [SerializeField] CanvasGroup menuPanel;
    [SerializeField] CanvasGroup loseGamePanel;
    [SerializeField] Image[] lifes;

    [Header("Music")]
    [SerializeField] Slider musicVolume;
    

    public void MenuOn()
    {
        menuPanel.gameObject.SetActive(true);
        musicVolume.value = AudioPlayer.Instance.GetMusicVolume() * musicVolume.maxValue;
        Time.timeScale = 0;
    }
    public void MenuOff()
    {
        menuPanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void ReturnToMainScene()
    {
        SceneLoader.Instance.LoadMenu();
        GetBestScore();
    }
    public void LoadGameScene()
    {
        SceneLoader.Instance.LoadNextLevel();
    }
    public void ActivateLoseGamePanel()
    {
        loseGamePanel.gameObject.SetActive(true);
    }
    public void LifeUp(int index)
    {
        lifes[index - 1].gameObject.SetActive(true);
    }
    public void LifeDown(int index)
    {
        lifes[index].gameObject.SetActive(false);
    }
    public void ResetLifes()
    {
        int lifeCount = LevelManager.Instance.ReturnLifeCunt();
        for (int i = 0; i <= lifeCount -1; i++)
        {
            lifes[i].gameObject.SetActive(true);
        }
    }
    public void SetMusicVolume()
    {
        AudioPlayer.Instance.MusicVolumeChange(musicVolume.value / musicVolume.maxValue);
    }
    private void Start()
    {
        GetBestScore();
    }
    private void GetBestScore()
    {
        int bestScoreFinal = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "BEST SCORE : " + bestScoreFinal;
    }
   
}
