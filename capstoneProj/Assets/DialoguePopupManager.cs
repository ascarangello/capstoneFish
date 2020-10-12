using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePopupManager : MonoBehaviour
{
    private Text displayText;
    private Image background;
    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        if(background.IsActive())
        {
            background.enabled = false;
        }
        displayText = GetComponentInChildren<Text>();
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
    public void show()
    {
        background.enabled = true;
    }
    public void hide()
    {
        background.enabled = false;
        displayText.text = "";
    }
    public bool visible()
    {
        return background.enabled;
    }
}
