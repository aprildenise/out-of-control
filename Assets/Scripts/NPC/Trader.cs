using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : Person, Speaker
{
    public string personName;
    public int numFruitBuying;
    public int fruitPrice;

    public override void InteractWith()
    {
        if (DialogueManager.instance.inDialogueWith != null) return;
        agent.isStopped = true;

        string[] dialogue = { "Got 'sum fruit to sell?" + fruitPrice + " for " + numFruitBuying + " fruits." };

        DialogueManager.instance.DisplayDialogue(dialogue, personName, true, GetComponent<Speaker>());
    }

    public void OnYes()
    {
        DialogueManager.instance.HideOptions();
        if (PlayerController.instance.fruit >= numFruitBuying)
        {
            PlayerController.instance.fruit -= numFruitBuying;
            PlayerController.instance.money += fruitPrice;
            string[] dialogue = { "Cool beans." };
            DialogueManager.instance.DisplayDialogue(dialogue, personName, false, GetComponent<Speaker>());
        }
        else
        {
            string[] dialogue = {"No fruit? No good."};
            DialogueManager.instance.DisplayDialogue(dialogue, personName, false, GetComponent<Speaker>());
        }

        agent.isStopped = false;


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
