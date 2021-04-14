using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    private CharacterController controller;
    private bool quit;
    public bool stop;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            quit = true;
        }
    }
    void FixedUpdate()
    {
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        // Vector3 mvmt = new Vector3(velocity.y, 0, velocity.x).normalized;
        Vector3 move = (transform.right * x + transform.forward * z).normalized;
        if(!stop)
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        if (quit)
        {
            Application.Quit();
        }


        // rb.MovePosition(nextStep.position);
    }

}
