using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePopup : MonoBehaviour
{
    public DialogueInfo[] dialogue;
    public DialoguePopupManager dmanager;
    public bool lockPlayer;
    public bool occurOnce;
    private bool playerPresence;
    private bool dialogueDone = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    

    // Update is called once per frame
    void Update()
    {
        if (playerPresence && Input.GetButtonDown("Interact") && dmanager.visible())
        {
            dmanager.displayDialogue();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((!occurOnce || (occurOnce && !dialogueDone)) && other.gameObject.CompareTag("Player"))
        {
            playerPresence = true;
            dmanager.startDialogue(dialogue, lockPlayer);
            if(occurOnce && !dialogueDone)
            {
                dialogueDone = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerPresence = false;
            if (dmanager.visible())
            {
                dmanager.hide();
            }
        }
    }
}
