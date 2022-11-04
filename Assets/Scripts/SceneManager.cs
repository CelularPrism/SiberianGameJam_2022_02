using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void Restart()
    {
        int nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        LoadScene(nowScene);
    }

    public static void LoadScene(int numScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(numScene);
    }

    public static void CloseGame()
    {
        Application.Quit();
    }
}
