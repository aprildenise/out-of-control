using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

    public Image healthBar;
    private PlantStageController stageController;


    private void Awake()
    {
        stageController = GetComponent<PlantStageController>();

        currentHealth = maxHealth;
    }

    private void LateUpdate()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }


    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void SetMaxHealth(float max)
    {
        currentHealth = maxHealth;
        ResetHealth();
    }



}
