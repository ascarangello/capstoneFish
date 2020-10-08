using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class XButton : MonoBehaviour
{
    public GameObject toBeClosed;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(closeWindow);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void closeWindow()
    {
        if(toBeClosed.activeSelf)
        {
            toBeClosed.SetActive(false);
        }
    }
}
