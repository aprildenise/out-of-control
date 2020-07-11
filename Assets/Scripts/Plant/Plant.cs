using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{

    [HideInInspector] public int maxHealth;
    public float currentHealth;
    public float healthLossCoeff;
    public bool allowRequestTools;
    public bool decreaseHealthOverTime;

    //public Image healthBar;
    private PlantStageController stageController;


    private void Awake()
    {
        stageController = GetComponent<PlantStageController>();
        currentHealth = maxHealth;
    }

    private void LateUpdate()
    {
        if (decreaseHealthOverTime) currentHealth -= Time.deltaTime * healthLossCoeff;

        if (currentHealth <= 0)
        {
            //TODO: DESTROY?
            GameManager.totalPlants--;
            Destroy(this.gameObject);
        }

        float healthPercentage = (1f - (currentHealth / maxHealth));
        stageController.currentStage.sprite.color = Color.HSVToRGB(0, healthPercentage, 1);
    }


    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void SetMaxHealth(float max)
    {
        decreaseHealthOverTime = false;
        maxHealth = (int)max;
        ResetHealth();
        decreaseHealthOverTime = true;
    }

    public void InteractWith()
    {

        Debug.Log("Player interact with:" + gameObject.name);
        GameObject playeritem = PlayerController.instance.currentlyHolding;
        if (playeritem.GetComponent<WateringCan>())
        {
            // TODO: IS THIS APPROPRIATE?
            Destroy(playeritem.gameObject);
            PlayerController.instance.currentlyHolding = null;
            ResetHealth();
        }
    }


}
