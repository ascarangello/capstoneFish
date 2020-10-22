﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePopup : MonoBehaviour
{
    public string dialogueOnInteract;
    private DialoguePopupManager dmanager;
    private bool playerPresence;
    public string displayText;
    // Start is called before the first frame update
    void Start()
    {
        dmanager = GameObject.FindGameObjectWithTag("DPopup").GetComponent<DialoguePopupManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPresence && Input.GetButtonDown("Interact") && dmanager.visible())
        {
            dmanager.hide();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerPresence = true;
            dmanager.setText(dialogueOnInteract);
            dmanager.show();
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
