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

        private HealthSystem _healthSystem;
        private Enemy _enemy;
        private BoxCollider _enemyBoxCollider;

        bool _attack;
        float _timeAttack;

        void Start()
        {
            //_timeAttack = Time.time;
            _enemy =  transform.parent.GetComponent<Enemy>();
            _enemyBoxCollider = GetComponent<BoxCollider>();
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
                _timeAttack = Time.time;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == playerMask)
            {
                _attack = false;
                _healthSystem = null;
            }
        }

        public void Death()
        {
            _enemyBoxCollider.enabled = false;
            _attack = false;
        }
    }
}