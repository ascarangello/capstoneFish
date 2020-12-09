using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePopup : MonoBehaviour
{

  
    private DialogueInfo[] dialogue;
    public DialoguePopupManager dmanager;
    private bool playerPresence;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = GetComponents<DialogueInfo>();
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
        if (other.gameObject.CompareTag("Player"))
        {
            playerPresence = true;
            dmanager.startDialogue(dialogue);
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
