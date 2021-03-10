using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class P1LogicChecker : MonoBehaviour
{
    [SerializeField]
    public GameObject enableOnWin;
    public GameObject disableOnWin;
    public List<Toggle> onToggles;
    public List<Toggle> offToggles;
    public AudioManager tockSound;

    public bool checkWin()
    {
        foreach (Toggle toggle in onToggles)
        {
            if(!toggle.isOn)
            {
                return false;
            }
        }
        foreach (Toggle toggle in offToggles)
        {
            if (toggle.isOn)
            {
                return false;
            }
        }

        foreach (Toggle toggle in onToggles)
        {
            toggle.interactable = false;
        }
        foreach (Toggle toggle in offToggles)
        {
            toggle.interactable = false;
        }
        enableOnWin.SetActive(true);
        disableOnWin.SetActive(false);

        // tockSound.StopSounds();
        return true;
    }
}
