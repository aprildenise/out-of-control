using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplier: Person, Speaker
{

    [SerializeField]
    public string personName;
    public GameObject toolSuppling;
    public int toolPrice;

    public override void InteractWith()
    {
        if (DialogueManager.instance.inDialogueWith != null) return;
        agent.isStopped = true;

        string[] dialogue = { "Need some " + toolSuppling.name + "? You can have it for " + toolPrice + "."};

        DialogueManager.instance.DisplayDialogue(dialogue, personName, true, GetComponent<Speaker>());

    }


    public void OnYes()
    {
        DialogueManager.instance.HideOptions();
        if (toolSuppling == null) return;

        if (PlayerController.instance.currentlyHolding != null)
        {
            string[] dialogue = {"Those hands look full."};
            DialogueManager.instance.DisplayDialogue(dialogue, personName, false, GetComponent<Speaker>());
            return;
        }
        if (PlayerController.instance.money < toolPrice)
        {
            string[] dialogue = { "You're broke!" };
            DialogueManager.instance.DisplayDialogue(dialogue, personName, false, GetComponent<Speaker>());
            return;
        }

        Debug.Log("NPC Interaction:" + gameObject.name);
        GameObject tool = Instantiate(toolSuppling,
            PlayerController.instance.overHeadPosition.position,
            toolSuppling.transform.rotation,
            PlayerController.instance.transform);
        tool.transform.localScale = new Vector3(1, 1, 1);
        PlayerController.instance.currentlyHolding = tool;
        PlayerController.instance.money -= toolPrice;


        DialogueManager.instance.HideOptions();
        DialogueManager.instance.HideDialogue();

        agent.isStopped = false;
    }

    public void OnNo()
    {
        DialogueManager.instance.HideOptions();
        DialogueManager.instance.HideDialogue();

        agent.isStopped = false;
    }


}
