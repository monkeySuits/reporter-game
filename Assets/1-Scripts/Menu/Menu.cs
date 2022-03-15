using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int gameSceneIndex;
    
    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
