using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(BoxCollider))]
    public class Attack : MonoBehaviour
    {
        [SerializeField] private float timeReload;
        [SerializeField] private int playerMask;
        [SerializeField] private float damage;

        HealthSystem _healthSystem;
        private Enemy _enemy;

        bool _attack;
        float _timeAttack;

        void Start()
        {
            _timeAttack = Time.time;
            _enemy =  transform.parent.GetComponent<Enemy>();
        }

        private void Update()
        {
            if (_attack)
            {
                if (Time.time >= _timeAttack + timeReload)
                {
                    _timeAttack = Time.time;
                    _healthSystem.Damage(damage);
                }
            }
        }

        public void PlayAudioAttack()
        {
            RuntimeAudio.PlayOneShot("event:/SFX_enemy_castet/castet_punch");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == playerMask && _enemy.GetActive())
            {
                _healthSystem = other.transform.GetComponentInChildren<HealthSystem>();
                _attack = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == playerMask)
            {
                _healthSystem = null;
                _attack = false;
            }
        }
    }
}