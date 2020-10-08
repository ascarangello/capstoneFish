using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1Toggle : MonoBehaviour
{
    [SerializeField]
    private Color offColor, onColor;
    [SerializeField]
    private P1Toggle sibling;
    private Toggle toggle;
    private string lastButton = "";
    private P1LogicChecker checker;
    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
        changeColor();
        toggle.onValueChanged.AddListener(delegate {
            updateSelf(this.name);
        });
        checker = GetComponentInParent<P1LogicChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void updateSelf(string fromName)
    {
        if(fromName != this.name)
        {
            lastButton = fromName;
            toggle.isOn = !toggle.isOn;
            Debug.Log(checker.checkWin());
        }
        else
        {
            // Debug.Log("Told to update by: " + fromHash.ToString());
            changeColor();
            if (lastButton == "")
            {
                sibling.updateSelf(this.name);
            }
            lastButton = "";
        }


    }

    private void changeColor()
    {
        ColorBlock newBlock = toggle.colors;
        newBlock.normalColor = toggle.isOn ? onColor : offColor;
        newBlock.highlightedColor = toggle.isOn ? onColor : offColor;
        newBlock.pressedColor = toggle.isOn ? onColor : offColor;
        newBlock.selectedColor = toggle.isOn ? onColor : offColor;
        toggle.colors = newBlock;
    }
}
