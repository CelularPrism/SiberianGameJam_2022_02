using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject endGame;
    [SerializeField] private int playerMask;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerMask)
        {
            endGame.gameObject.SetActive(true);
            Time.timeScale = 0;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
