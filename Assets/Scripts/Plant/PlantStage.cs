using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlantStage : MonoBehaviour, Interactible
{

    [HideInInspector] public PlantStageController stageController;
    public SpriteRenderer sprite;

    public void InteractWith()
    {
        stageController.parentPlant.InteractWith();
    }

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }



}
