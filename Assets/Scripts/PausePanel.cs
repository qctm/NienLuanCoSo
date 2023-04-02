using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    private GamePlayManager m_GameManager;
    // Start is called before the first frame update
    void Start()
    {
        m_GameManager = FindObjectOfType<GamePlayManager>();
    }

    // Update is called once per frame
   public void Pause()
    {
        m_GameManager.Pause();
    }
    public void Continue()
    {
        m_GameManager.Continue();
    }
    public void Restart()
    {
        m_GameManager.Restart();
    }
    public void Home()
    {
        m_GameManager.Home();
    }
    public void Quit()
    {
        m_GameManager.Quit();
    }
}
