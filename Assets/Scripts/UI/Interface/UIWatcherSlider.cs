using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class UIWatcherSlider : MonoBehaviour
{
    [SerializeField] private GameObject healthSystem;

    private IPlayerValue _health;
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _health = healthSystem.GetComponent<IPlayerValue>();
    }

    void Update()
    {
        float health = _health.GetValue();
        _slider.value = health;
    }
}
