using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1ToggleImproved : MonoBehaviour
{
    //Light that the button controls
    // [SerializeField]
    // private LightFlicker light;

    //Sprite for the toggle
    [SerializeField]
    private Sprite offSprite, onSprite;

    private Image switchImage;

    //Other toggles that this controls
    [SerializeField]
    private List<P1ToggleImproved> sibling;
    private Toggle toggle;
    private string lastButton = "";
    private P1LogicChecker checker;



    // Start is called before the first frame update
    void Start()
    {
        switchImage = GetComponentInChildren<Image>();
        toggle = GetComponent<Toggle>();
        swapSprite();
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
            swapSprite();
            // CheckFlickering();

            if (lastButton == "")
            {
                foreach (P1ToggleImproved sib in sibling)
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
    private void swapSprite()
    {
        if(toggle.isOn)
        {
            switchImage.sprite = onSprite;
        }
        else
        {
            switchImage.sprite = offSprite;
        }
    }
}
