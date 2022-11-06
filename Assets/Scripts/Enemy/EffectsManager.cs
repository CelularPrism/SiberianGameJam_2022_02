using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace Enemies
{
    public class EffectsManager : MonoBehaviour
    {
        private ParticleSystem _particleSystem;

        private void Start()
        {
            _particleSystem = GetComponentInChildren<ParticleSystem>();
            _particleSystem.gameObject.SetActive(false);
            _particleSystem.Stop();
        }

        public void Death()
        {
            _particleSystem.gameObject.SetActive(true);
            _particleSystem.Play();
        }
    }
}