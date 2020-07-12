using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlantStage : MonoBehaviour, Interactible
{

    [HideInInspector] public PlantStageController stageController;
    [HideInInspector] public SpriteRenderer sprite;

    public void InteractWith()
    {


        OnInteractWith();

    }

    public virtual void OnInteractWith()
    {
        return;
    }

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }



}
