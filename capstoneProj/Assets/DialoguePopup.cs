using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePopup : MonoBehaviour
{
    public string dialogueOnInteract;
    private PopupManager popup;
    private DialoguePopupManager dmanager;
    private bool playerPresence;
    public string displayText;
    // Start is called before the first frame update
    void Start()
    {
        dmanager = GameObject.FindGameObjectWithTag("DPopup").GetComponent<DialoguePopupManager>();
        popup = GameObject.FindGameObjectWithTag("Popup").GetComponent<PopupManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPresence && Input.GetButtonDown("Interact"))
        {
            if (dmanager.visible())
            {
                dmanager.hide();
            }
            else
            {
                popup.clearText();
                dmanager.setText(dialogueOnInteract);
                dmanager.show();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerPresence = true;
            popup.setText(displayText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerPresence = false;
            popup.clearText();
            if (dmanager.visible())
            {
                dmanager.hide();
            }
        }
    }
}
