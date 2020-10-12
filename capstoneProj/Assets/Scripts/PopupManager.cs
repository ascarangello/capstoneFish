using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    private Text displayText;

    // Start is called before the first frame update
    void Start()
    {
        displayText = GetComponent<Text>();
        displayText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText(string message)
    {
        displayText.text = message;
    }

    public void clearText()
    {
        displayText.text = "";
    }
}
