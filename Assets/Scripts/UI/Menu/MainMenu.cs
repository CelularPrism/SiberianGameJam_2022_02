using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [Header("Num Game scene")]
    [SerializeField] private int numScene;

    public void PlayGame()
    {
        SceneManager.LoadScene(numScene);
    }

    public void Quit()
    {
        SceneManager.CloseGame();
    }
}
