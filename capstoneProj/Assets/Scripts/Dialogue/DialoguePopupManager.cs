using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePopupManager : MonoBehaviour
{
    private Text displayText;
    private Queue<DialogueInfo> GlobalDialogue;
    private DialogueInfo currentDialogue;
    private Image background;
    // Start is called before the first frame update
    void Start()
    {
        GlobalDialogue = new Queue<DialogueInfo>();
        background = GetComponent<Image>();
        if(background.IsActive())
        {
            background.enabled = false;
        }
        displayText = GetComponentInChildren<Text>();
        displayText.text = "";
    }

    public void startDialogue(DialogueInfo[] dialogue)
    {
        currentDialogue = null;
        GlobalDialogue.Clear();
        foreach (DialogueInfo currDialogue in dialogue)
        {
            GlobalDialogue.Enqueue(currDialogue);
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

    public void setText(string message)
    {
        displayText.text = message;
    }
    public void show()
    {
        background.enabled = true;
    }
    public void hide()
    {
        background.enabled = false;
        displayText.text = "";
    }
    public bool visible()
    {
        return background.enabled;
    }
}
