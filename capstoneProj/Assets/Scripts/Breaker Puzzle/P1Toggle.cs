using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1Toggle : MonoBehaviour
{
    //Light that the button controls
    // [SerializeField]
    // private LightFlicker light;

    //Color of the toggle
    [SerializeField]
    private Color offColor, onColor;

    //Other toggles that this controls
    [SerializeField]
    private List<P1Toggle> sibling;
    private Toggle toggle;
    private string lastButton = "";
    private P1LogicChecker checker;



    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
        changeColor();
        // CheckFlickering();
        toggle.onValueChanged.AddListener(delegate
        {
            updateSelf(this.name);
        });

        checker = GetComponentInParent<P1LogicChecker>();
    }

    public void updateSelf(string fromName)
    {
        if (fromName != this.name)
        {
            lastButton = fromName;
            toggle.isOn = !toggle.isOn;
            //Debug.Log(checker.checkWin());
        }
        else
        {
            // Debug.Log("Told to update by: " + fromHash.ToString());
            changeColor();
            // CheckFlickering();
            
            if (lastButton == "")
            {
                foreach (P1Toggle sib in sibling)
                {
                    sib.updateSelf(this.name);
                }

            }

            checker.checkWin();
            lastButton = "";
        }
    }


    //If the toggle is on stop the flickering, otherwise turn it back on
    /*
    void CheckFlickering()
    {

        if (GetComponent<Light>() != null)
        {
            if (toggle.isOn)
            {
                GetComponent<Light>().Stop();
            }
            else
            {
                GetComponent<Light>().Restart();
            }
        }
    }
    */
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
