using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1CompleteTrigger : MonoBehaviour
{
    public P1LogicChecker p1;
    public GameObject scaryFish;
    private bool puzzledone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(p1.checkWin() && collision.gameObject.CompareTag("Player") && !puzzledone)
        {
            puzzledone = true;
            scaryFish.SetActive(true);
        }
    }
}
