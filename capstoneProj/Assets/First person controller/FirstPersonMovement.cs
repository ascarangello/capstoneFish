using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    Vector2 velocity;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 mvmt = new Vector3(velocity.y, 0, velocity.x).normalized;
        Transform nextStep = this.transform;
        nextStep.Translate(velocity.x, 0, velocity.y);
        rb.MovePosition(nextStep.position);
    }
}
