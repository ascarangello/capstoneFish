using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWaterEvent : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private float timeToFill;
    private float timeSoFar = 0f;
    private PopupManager popupText;
    private Transform player;
    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        popupText = GameObject.FindGameObjectWithTag("Popup").GetComponent<PopupManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeSoFar < timeToFill)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + (Time.deltaTime * speed), transform.localScale.z);
            timeSoFar += Time.deltaTime;
        }
        else if(!gameOver)
        {
            gameOver = true;
            deathEvent();
        }
    }

    void deathEvent()
    {
        popupText.setText("You have died, game over");
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        player.GetComponent<FirstPersonMovement>().enabled = false;
    }
}
