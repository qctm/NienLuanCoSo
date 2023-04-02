using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { 
    Home,
    GamePlay,
    Pause,
    GameOver
}
public class GamePlayManager : MonoBehaviour
{
  private static GamePlayManager m_Instance;
  public static GamePlayManager Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType<GamePlayManager>();
            return m_Instance;
        }
    }

   
    [SerializeField] HomePanel m_Home;
    [SerializeField] GamePlayPanel m_GamePlayPanel;
    [SerializeField] GameOverPanel m_GameOverPanel;
    [SerializeField] PausePanel m_PausePanel;

    private GameState m_GameState;
    private bool m_win;

    private void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        else if (m_Instance != this)
            Destroy(gameObject);
    }
    private void Start()
    {
        m_Home.gameObject.SetActive(false);
        m_GamePlayPanel.gameObject.SetActive(false);
        m_PausePanel.gameObject.SetActive(false);
        m_GameOverPanel.gameObject.SetActive(false);
        SetState(GameState.GamePlay);
    }
    private void SetState(GameState state)
    {
        m_GameState = state;
        m_Home.gameObject.SetActive(m_GameState == GameState.Home);
        m_GamePlayPanel.gameObject.SetActive(m_GameState == GameState.GamePlay);
        m_PausePanel.gameObject.SetActive(m_GameState == GameState.Pause);
        m_GameOverPanel.gameObject.SetActive(m_GameState == GameState.GameOver);
        if (m_GameState == GameState.Pause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public bool TsActive()
    {
        return m_GameState == GameState.GamePlay;
    }
    public void Play()
    {
        SetState(GameState.GamePlay);
    }
    public void Pause()
    {
        SetState(GameState.Pause);
    }
    public void Continue()
    {
        SetState(GameState.GamePlay);
    }
    public void GameOver(bool win)
    {
        m_win = win;
        SetState(GameState.GameOver);
        //m_GameOverPanel.DisplayResult(m_win);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
