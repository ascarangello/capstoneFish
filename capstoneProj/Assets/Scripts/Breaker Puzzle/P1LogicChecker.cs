using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class P1LogicChecker : MonoBehaviour
{
    [SerializeField]
    public List<Toggle> onToggles;
    public List<Toggle> offToggles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
