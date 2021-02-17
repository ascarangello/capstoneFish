using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePopup : MonoBehaviour
{
    public GameObject onInteract;
    public GameObject playerRef;
    private PopupManager popup;
    private bool playerPresence;
    public string displayText;
    private FirstPersonLook look;
    private FirstPersonMovement move;
    // Start is called before the first frame update
    void Start()
    {
        popup = GameObject.FindGameObjectWithTag("Popup").GetComponent<PopupManager>();
        look = playerRef.GetComponentInChildren<FirstPersonLook>();
        move = playerRef.GetComponent<FirstPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPresence && !onInteract.activeSelf && Input.GetButtonDown("Interact"))
        {
            popup.clearText();
            onInteract.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            look.enabled = false;
            move.enabled = false;
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
            if (onInteract.activeSelf)
            {
                onInteract.SetActive(false);
                Cursor.visible = false;

            }
        }
    }
}
