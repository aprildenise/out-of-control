using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlantStage : MonoBehaviour
{

    [HideInInspector] public PlantStageController stageController;


    // TEST ONLY.
    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Interact();
        }
    }


    protected virtual void Interact()
    {

    }

}
