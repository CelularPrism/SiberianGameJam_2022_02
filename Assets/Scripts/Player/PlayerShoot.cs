using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayerShoot : MonoBehaviour, IPlayerValue
{
    [Header("Shoot Settings")]
    [SerializeField] private Vector3 _aimCenter = new Vector3(0.5f, 0.5f, 0f);
    [SerializeField] private int _shootDistance = 100;
    [SerializeField] private int _countOfShoot = 7;
    [SerializeField] private int _currentCountOfShoot = 0;
    
    private int _layerIgnore = 1 << 6;

    [Header("Camera")]
    [SerializeField] private Camera _mainCamera;

    private PlayerActions _playerActions;
    private AnimationHand _handAnimator;

    private bool _activeShoot;

    private void OnEnable()
    {
        _playerActions = new PlayerActions();

        _playerActions.Actions.Shoot.Enable();
        _playerActions.Actions.Shoot.performed += context => Shoot();

        _playerActions.Actions.Reload.Enable();
        _playerActions.Actions.Reload.performed += context => Reload();

        _handAnimator = GetComponentInChildren<AnimationHand>();
        _activeShoot = false;
    }

    private void Shoot()
    {
        if (_currentCountOfShoot < _countOfShoot 
            && _handAnimator.CanShoot)
        {
            _handAnimator.PlayAnim("StartShoot");

            RaycastHit hitInformation;

            Vector3 rayOrigin = _mainCamera.ViewportToWorldPoint(_aimCenter);

            _layerIgnore = ~_layerIgnore;

            if (Physics.Raycast(rayOrigin, _mainCamera.transform.forward, out hitInformation, _shootDistance, _layerIgnore))
            {
                ITarget target = hitInformation.transform.GetComponent<ITarget>();
                if (target != null && _activeShoot)
                    target.ApplyDamage();
            }

            _currentCountOfShoot++;
        }
    }

    private void Reload()
    {
        _handAnimator.PlayAnim("Reload");
        RuntimeAudio.PlayOneShot("event:/SFX_player_handgun/reload");
        _currentCountOfShoot = 0;
    }
    private void OnDisable()
    {
        _playerActions.Actions.Shoot.Disable();
        _playerActions.Actions.Reload.Disable();
    }

    public float GetValue()
    {
        return _countOfShoot - _currentCountOfShoot;
    }

    public void SetActiveShoot(bool value)
    {
        _activeShoot = true;
    }
}
