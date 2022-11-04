using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIWatcherText : MonoBehaviour
{
    [SerializeField] private GameObject playerAmmo;

    private IPlayerValue _ammo;
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _ammo = playerAmmo.GetComponent<IPlayerValue>();
    }

    void Update()
    {
        float value = _ammo.GetValue();
        _text.text = value.ToString();
    }
}
