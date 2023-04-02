using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void QuayveMain()
    {
        SceneManager.LoadScene(0);
    }
}
