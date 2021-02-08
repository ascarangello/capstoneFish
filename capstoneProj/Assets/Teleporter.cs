using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform thisExitTransform;
    public GameObject otherTP;
    private Transform exitSpot;
    // Start is called before the first frame update
    void Start()
    {
        exitSpot = otherTP.GetComponent<Teleporter>().thisExitTransform;
        thisExitTransform.gameObject.GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            FirstPersonMovement playerController = player.GetComponent<FirstPersonMovement>();
            playerController.enabled = false;
            player.transform.position = exitSpot.position;
            StartCoroutine(movementEnable(playerController));
        }
    }
    IEnumerator movementEnable(FirstPersonMovement controller)
    {
        yield return new WaitForEndOfFrame(); 
        controller.enabled = true; 

    }


}
