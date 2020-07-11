using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlantStage : PlantStage
{


    public float maxHealth;
    public float timeUntilNextRequest;
    private Timer requestTimer;

    private void Start()
    {
        stageController.parentPlant.SetMaxHealth(maxHealth);
        requestTimer = gameObject.AddComponent<Timer>();
        requestTimer.SetTimer(timeUntilNextRequest);
        requestTimer.StartTimer();
    }

    private void LateUpdate()
    {
        if (requestTimer.GetStatus() == Timer.Status.FINISHED)
        {
            RequestTools();
            requestTimer.ResetTimer();
        }
    }

    private void RequestTools()
    {
        Debug.Log(stageController.parentPlant.gameObject.name + ":Requesting tools");

        stageController.parentPlant.decreaseHealthOverTime = true;
    }

    public void GiveTools()
    {
        Debug.Log(stageController.parentPlant.gameObject.name + ":Tools given.");
        stageController.parentPlant.ResetHealth();
        requestTimer.ResetTimer();
        requestTimer.StartTimer();

        stageController.parentPlant.decreaseHealthOverTime = false;
    }

}
