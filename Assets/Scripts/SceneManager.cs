using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneManager
{
    public static void LoadScene(int numScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(numScene);
    }

    public static void CloseGame()
    {
        Application.Quit();
    }
}
