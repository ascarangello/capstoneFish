using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePopup : MonoBehaviour
{
    public GameObject onInteract;
    private PopupManager popup;
    private bool playerPresence;
    public string displayText;
    // Start is called before the first frame update
    void Start()
    {
        popup = GameObject.FindGameObjectWithTag("Popup").GetComponent<PopupManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPresence && !onInteract.activeSelf && Input.GetButtonDown("Interact"))
        {
            popup.clearText();
            onInteract.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerPresence = true;
            popup.setText(displayText);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerPresence = false;
            popup.clearText();
            if(onInteract.activeSelf)
            {
                onInteract.SetActive(false);
            }
        }
    }
}
