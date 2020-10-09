using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class P1LogicChecker : MonoBehaviour
{
    [SerializeField]
    public List<Toggle> onToggles;
    public List<Toggle> offToggles;
    
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
        return true;
    }
}
