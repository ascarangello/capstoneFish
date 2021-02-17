using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class P2Valve : MonoBehaviour
{
    public enum ValveState {LOOSE, MID, TIGHT};

    public ValveState currentState;
    public List<P2Valve> valvesUpstream;
    public List<P2Valve> valvesDownstream;

    public ValveState desiredState;
    private Button button;
    public List<DynamicPipe> affectedPipes;
    private bool correctState;
    public P2WinLogic logicChecker;

    // Start is called before the first frame update
    void Start()
    {
        this.button = GetComponent<Button>();
        button.onClick.AddListener(changeState);
        switch (currentState)
        {
            case ValveState.LOOSE:
                break;
            case ValveState.MID:
                transform.Rotate(new Vector3(0.0f, 0.0f, 120));
                break;
            case ValveState.TIGHT:
                transform.Rotate(new Vector3(0.0f, 0.0f, 240));
                break;
        }
        if (currentState == desiredState && checkUpstream())
        {
            correctState = true;
        }
        else
        {
            correctState = false;
        }
        foreach (DynamicPipe pipe in affectedPipes)
        {
            pipe.setColor(correctState);
        }
        foreach (P2Valve valve in valvesDownstream)
        {
            valve.refresh();

        }
        logicChecker.checkForWin();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeState()
    {
        switch (currentState) {
            case ValveState.LOOSE:
                currentState = ValveState.MID;
                transform.Rotate(new Vector3(0.0f, 0.0f, 120));
                break;
            case ValveState.MID:
                currentState = ValveState.TIGHT;
                transform.Rotate(new Vector3(0.0f, 0.0f, 120));
                break;
            case ValveState.TIGHT:
                transform.Rotate(new Vector3(0.0f, 0.0f, -240));
                currentState = ValveState.LOOSE;
                break;
        }
        if(currentState == desiredState && checkUpstream())
        {
            correctState = true;
        }
        else
        {
            correctState = false;
        }
        foreach (DynamicPipe pipe in affectedPipes)
        {
            pipe.setColor(correctState);
        }
        foreach (P2Valve valve in valvesDownstream)
        {
            valve.refresh();

        }
        logicChecker.checkForWin();
    }

    public void refresh()
    {
        if (currentState == desiredState && checkUpstream())
        {
            correctState = true;
        }
        else
        {
            correctState = false;
        }
        foreach (DynamicPipe pipe in affectedPipes)
        {
            pipe.setColor(correctState);
        }
        foreach (P2Valve valve in valvesUpstream)
        {
            valve.refresh();
        }
        logicChecker.checkForWin();
    }

    public bool getWinState()
    {
        return correctState;
    }


    private bool checkUpstream()
    {
        foreach (P2Valve valve in valvesUpstream)
        {
            if(!valve.getWinState())
            {
                return false;
            }
        }
        return true;
    }

    public void puzzleDone()
    {
        this.button.interactable = false;
    }
}
