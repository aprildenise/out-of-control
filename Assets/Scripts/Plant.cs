using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

    private PlantStageController stageController;


    private void Awake()
    {
        stageController = GetComponent<PlantStageController>();

        currentHealth = maxHealth;
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
