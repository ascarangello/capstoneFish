using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeOnTrigger : MonoBehaviour
{
    public GameObject obj;
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
        if(other.gameObject.CompareTag("Player"))
        {
            obj.SetActive(false);
        }
    }
}
