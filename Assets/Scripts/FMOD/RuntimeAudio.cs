using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public static class RuntimeAudio
{
    public static void PlayOneShot(string path)
    {
        RuntimeManager.PlayOneShot(path);
    }    
}
