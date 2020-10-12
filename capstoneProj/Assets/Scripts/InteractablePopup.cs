using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePopup : MonoBehaviour
{
    private PopupManager popup;
    public string displayText;
    // Start is called before the first frame update
    void Start()
    {
        popup = GameObject.FindGameObjectWithTag("Popup").GetComponent<PopupManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        popup.setText(displayText);
    }

    private void OnCollisionExit(Collision collision)
    {
        popup.clearText();
    }
}
