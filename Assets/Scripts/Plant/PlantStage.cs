using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlantStage : MonoBehaviour
{

    [HideInInspector] public PlantStageController stageController;



    protected virtual void Interact()
    {

    }

}
