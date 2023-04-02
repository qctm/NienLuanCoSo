using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayPanel : MonoBehaviour
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
}
