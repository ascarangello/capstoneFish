using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapEnabledOnTrigger : MonoBehaviour
{
    public List<GameObject> swapped;
    public bool once;
    private bool trigger;
    // Start is called before the first frame update
    void Start()
    {
        trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && (!once || !trigger))
        {
            foreach (GameObject obj in swapped)
            {
                obj.SetActive(!obj.activeSelf);
            }
            trigger = true;
        }
    }
}
