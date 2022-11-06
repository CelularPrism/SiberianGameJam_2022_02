using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHand : MonoBehaviour
{
    [Header("Control of shooting")]
    [SerializeField] private bool _canShoot = true;

    public bool CanShoot
    {
        get { return _canShoot; }
    }
    private Animator _handAnimator;
    private void Awake()
    {
        _handAnimator = GetComponent<Animator>();
    }
    public void PlayAnim(string anim)
    {
        _handAnimator.SetTrigger(anim);
        _canShoot = false;
    }
    public void ResetAnimations()
    {
        _canShoot = true;
    }

    public void PlayAudioShoot()
    {
        Debug.Log("Shoot");
        RuntimeAudio.PlayOneShot("event:/SFX_player_handgun/shoot");
    }
}
