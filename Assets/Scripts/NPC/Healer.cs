using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Person, Speaker
{

    public string personName;
    public float timeToHeal;
    private Timer healCooldown;

    private void Start()
    {
        healCooldown = gameObject.AddComponent<Timer>();
        healCooldown.SetTimer(timeToHeal, Timer.Status.FINISHED);
    }

    public override void InteractWith()
    {
        if (DialogueManager.instance.inDialogueWith != null) return;
        agent.isStopped = true;
        if (healCooldown.GetStatus() == Timer.Status.FINISHED)
        {
            string[] dialogue = {"Want me to patch you up?"};
            DialogueManager.instance.DisplayDialogue(dialogue, personName, true, GetComponent<Speaker>());
        }
        else
        {
            string[] dialogue = { "Come back later for healing." };
            DialogueManager.instance.DisplayDialogue(dialogue, personName, false, GetComponent<Speaker>());
        }
    }

    public void OnYes()
    {
        DialogueManager.instance.HideOptions();
        DialogueManager.instance.HideDialogue();
        PlayerController.instance.ResetHealth();
        healCooldown.ResetTimer();
        healCooldown.StartTimer();
        agent.isStopped = false;
    }

    public void OnNo()
    {
        DialogueManager.instance.HideOptions();
        DialogueManager.instance.HideDialogue();

        agent.isStopped = false;
    }
}
