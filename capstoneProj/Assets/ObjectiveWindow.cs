using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjectiveWindow : MonoBehaviour
{
    private Text objectiveText;
    // Start is called before the first frame update
    void Start()
    {
        objectiveText = GetComponent<Text>();
        objectiveText.text = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setObj(string obj) {
        objectiveText.text = obj;
    }

}
