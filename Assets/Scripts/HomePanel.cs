using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePanel : MonoBehaviour
{
    private GamePlayManager m_GameManager;
    // Start is called before the first frame update
    void Start()
    {
        m_GameManager = FindObjectOfType<GamePlayManager>();   
    }

   public void btn_Play()
    {
        m_GameManager.Play();
    }
}
