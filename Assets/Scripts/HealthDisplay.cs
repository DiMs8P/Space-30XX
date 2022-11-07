using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    TextMeshProUGUI _healthText;
    PlayerHealth _playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        _healthText = GetComponent<TextMeshProUGUI>();
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        _healthText.text = _playerHealth.GetHealth().ToString();
    }
}
