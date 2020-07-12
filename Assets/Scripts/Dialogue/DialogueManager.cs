using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public CanvasGroup dialogueBox;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public CanvasGroup options;
    public bool displayingText = false;

    public Speaker inDialogueWith;
    public string[] currentDialogue;
    public int currentDialogueIndex;
    public bool showOptions;
    private string currentName;

    public static DialogueManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        HideOptions();
        HideDialogue();
    }

    private void Update()
    {
        if (!displayingText) return;

        //TODO CHANCE INPUT ACCORDINGLY
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentDialogueIndex++;
            DisplayText();
        }
    }

    private void DisplayText()
    {
        if (currentDialogueIndex >= currentDialogue.Length)
        {
            if (showOptions)
            {
                DisplayOptions();
                // Wait for OnYes and OnNo funcs to close.
            }
            else
            {
                HideDialogue();
            }
            return;
        }
        dialogueText.SetText(currentDialogue[currentDialogueIndex]);
    }

    public void DisplayOptions()
    {
        options.alpha = 1;
        options.interactable = true;
    }

    public void HideOptions()
    {
        options.alpha = 0;
        options.interactable = false;
    }

    public void DisplayDialogue(string[] dialogue, string name, bool showOptionsAtEnd, Speaker callingObject)
    {

        PlayerController.instance.GetComponent<BoxCollider>().enabled = false;
        dialogueBox.alpha = 1;
        dialogueBox.interactable = true;
        displayingText = true;
        currentDialogue = dialogue;
        currentDialogueIndex = 0;
        nameText.SetText(name);
        inDialogueWith = callingObject;
        showOptions = showOptionsAtEnd;
        DisplayText();
    }

    public void HideDialogue()
    {
        PlayerController.instance.GetComponent<BoxCollider>().enabled = true;
        HideOptions();
        dialogueBox.alpha = 0;
        dialogueBox.interactable = false;
        displayingText = false;
        inDialogueWith = null;
    }

    public void Yes()
    {
        inDialogueWith.OnYes();
    }

    public void No()
    {
        inDialogueWith.OnNo();
    }

}
