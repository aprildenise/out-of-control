using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplier: Person
{

    [SerializeField]
    public GameObject toolSuppling;

    public override void InteractWith()
    {
        try
        {
            if (toolSuppling == null) return;
            if (PlayerController.instance.currentlyHolding != null) return;
            agent.isStopped = true;
            Debug.Log("NPC Interaction:" + gameObject.name);
            GameObject tool = Instantiate(toolSuppling,
                PlayerController.instance.overHeadPosition.position,
                toolSuppling.transform.rotation,
                PlayerController.instance.transform);
            tool.transform.localScale = new Vector3(1, 1, 1);
            PlayerController.instance.currentlyHolding = tool;
            agent.isStopped = false;
        } catch (System.Exception)
        {

        }

    }


}
