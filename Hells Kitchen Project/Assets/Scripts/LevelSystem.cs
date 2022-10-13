using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public int currentXP, targetXP, level;

    public static LevelSystem instance;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void AddXP(int xp) {
        currentXP += xp;

        while(currentXP >= targetXP) {
            currentXP = currentXP - targetXP;
            level++;
            targetXP += targetXP / 20;

            levelText.text = "Level: " + level.ToString();
        }
    }
}
