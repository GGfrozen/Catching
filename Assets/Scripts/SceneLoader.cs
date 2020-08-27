using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    #region Singleton
    public static SceneLoader Instance { get; private set; }

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

    [SerializeField] CanvasGroup mainCanvas;
    [SerializeField] CanvasGroup gameCanvas;
    public void LoadNextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
        mainCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(true);
        LevelManager.Instance.ResetScore();
        UIManager.Instance.ResetLifes();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        mainCanvas.gameObject.SetActive(true);
        gameCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void LoadCurrentLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
        LevelManager.Instance.ResetScore();
        Time.timeScale = 1;
        UIManager.Instance.ResetLifes();
    }
}
