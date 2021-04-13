using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    private CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        // Vector3 mvmt = new Vector3(velocity.y, 0, velocity.x).normalized;
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);


        // rb.MovePosition(nextStep.position);
    }

}
