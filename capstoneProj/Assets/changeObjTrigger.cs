using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeObjTrigger : MonoBehaviour
{
    private bool triggered = false;
    public string newObjective;
    public ObjectiveWindow objWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!triggered &&other.gameObject.CompareTag("Player"))
        {
            triggered = true;
            objWindow.setObj(newObjective);
        }
    }
}
