using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
    public GameObject playerRef;
    public PopupManager popup;
    private bool playerPresence;
    public string displayText;
    public FirstPersonLook flashlightEnabler;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPresence && Input.GetButtonDown("Interact"))
        {
            popup.clearText();
            flashlightEnabler.enableFlashlight();
            foreach(GameObject info in GameObject.FindGameObjectsWithTag("Info"))
            {
                info.GetComponent<infoStandScarySwap>().swapToScary();
            }
            this.gameObject.SetActive(false);
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
        }
    }
}
