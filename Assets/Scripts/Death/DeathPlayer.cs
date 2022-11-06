using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayer : MonoBehaviour, IDeath
{
    [SerializeField] private GameObject panelDeath;

    private float _nowTime;
    private void Start()
    {
        _nowTime = Time.time;
        //Time.timeScale = 1;
    }

    public void Death()
    {
        RuntimeAudio.PlayOneShot("event:/SFX_dead/dead_or_lose_1");
        Time.timeScale = 0;
        panelDeath.SetActive(true);
    }
}
