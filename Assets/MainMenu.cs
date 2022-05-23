using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(int sceneID)
    {
        SceneManager.LoadScene(sceneID); 
    }
    public void Option()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }
}
