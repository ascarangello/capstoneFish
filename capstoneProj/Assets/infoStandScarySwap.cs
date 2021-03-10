using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoStandScarySwap : MonoBehaviour
{
    private SpriteRenderer currentSprite;
    public Sprite toSwapTo;
    // Start is called before the first frame update
    void Start()
    {
        currentSprite = GetComponentInChildren<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void swapToScary()
    {
        this.currentSprite.sprite = toSwapTo;
    }
}
