using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    public int experience;
    private TextMeshProUGUI levelText;

    private void Awake() {
        levelText = GetComponent<TextMeshProUGUI>();
    }

    private void Start() {
        experience = 0;
    }

    void Update() {
        levelText.text = "Level: " + experience.ToString();
    }


}
