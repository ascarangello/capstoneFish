using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class XButton : MonoBehaviour
{
    public GameObject toBeClosed;
    private Button button;
    public GameObject playerRef;
    private FirstPersonLook look;
    private FirstPersonMovement move;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(closeWindow);
        look = playerRef.GetComponentInChildren<FirstPersonLook>();
        move = playerRef.GetComponent<FirstPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void closeWindow()
    {
        if(toBeClosed.activeSelf)
        {
            toBeClosed.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            look.enabled = true;
            move.enabled = true;
        }
    }
}
