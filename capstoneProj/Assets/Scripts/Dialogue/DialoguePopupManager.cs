using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePopupManager : MonoBehaviour
{
    public Text displayText;
    public Text nameText;
    public GameObject playerRef;
    private Queue<DialogueInfo> GlobalDialogue;
    public Image nameWindow;
    private DialogueInfo currentDialogue;
    private Image background;
    private FirstPersonMovement movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = playerRef.GetComponent<FirstPersonMovement>();
        GlobalDialogue = new Queue<DialogueInfo>();
        background = GetComponent<Image>();
        if(background.IsActive())
        {
            background.enabled = false;
            nameWindow.enabled = false;
        }
        displayText.text = "";
        nameText.text = "";
    }

    public void startDialogue(DialogueInfo[] dialogue, bool lockPlayer)
    {
        currentDialogue = null;
        GlobalDialogue.Clear();
        foreach (DialogueInfo currDialogue in dialogue)
        {
            GlobalDialogue.Enqueue(currDialogue);
        }
        if(lockPlayer)
        {
            movement.stop = true;
        }
        nextDialogue();

    }

    public void nextDialogue()
    {
        if(GlobalDialogue.Count == 0)
        {
            hide();
        }
        else
        {
            currentDialogue = GlobalDialogue.Dequeue();
            currentDialogue.resetInfo();
            setName(currentDialogue.talking);
            displayDialogue();
        }
    }

    public void displayDialogue()
    {
        if(currentDialogue.sentenceQueue.Count == 0)
        {
            nextDialogue();
        }
        else
        {
            string toDisplay = currentDialogue.sentenceQueue.Dequeue();
            setText(toDisplay);
            if (!visible())
            {
                show();
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setName(string name)
    {
        nameText.text = name;
    }

    public void setText(string message)
    {
        displayText.text = message;
    }
    public void show()
    {
        background.enabled = true;
        nameWindow.enabled = true;
    }
    public void hide()
    {
        if(movement.stop)
        {
            movement.stop = false;
        }
        background.enabled = false;
        nameWindow.enabled = false;
        displayText.text = "";
        nameText.text = "";
    }
    public bool visible()
    {
        return background.enabled;
    }
}
