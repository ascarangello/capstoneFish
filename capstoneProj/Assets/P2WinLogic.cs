using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2WinLogic : MonoBehaviour
{
    public List<P2Valve> valves;
    public GameObject enableOnWin;
    public GameObject disableOnWin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkForWin()
    {
        foreach(P2Valve valve in valves)
        {
            if(!valve.getWinState())
            {
                return;
            }
        }
        Debug.Log("Puzzle 2 completed");
        foreach (P2Valve valve in valves)
        {
            valve.puzzleDone();
        }
        disableOnWin.SetActive(false);
        enableOnWin.SetActive(true);
    }
}
