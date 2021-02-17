using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DynamicPipe : MonoBehaviour
{
    public Color correctColor;
    public Color wrongColor;
    public Image sprite;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setColor(bool correct)
    {
        if(correct)
        {
            sprite.color = correctColor;
        }
        else
        {
            sprite.color = wrongColor;
        }

    }
}
