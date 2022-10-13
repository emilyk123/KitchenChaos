using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    Player player;

    private void Start() {
        HealthBar = GetComponent<Image>();
        player = FindObjectOfType<Player>();
    }

    private void Update() {
        CurrentHealth = player.Health;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
