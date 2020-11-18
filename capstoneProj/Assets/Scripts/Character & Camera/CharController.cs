using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Adapted from https://www.youtube.com/watch?v=XhliRnzJe5g
public class CharController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;
    private bool dead = false;
    private GameObject inContactWith;

    private Vector3 forward, right, prevPos;

    [Header("SFX Audio")]
    public AudioSource SFXSource;

    // Start is called before the first frame update
    void Start()
    {
        prevPos = transform.position;
        setMovementVectors();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead && Input.GetAxisRaw("HorizontalKey") != 0.0f || Input.GetAxisRaw("VerticalKey") != 0.0f)
        {
            Move();
            prevPos = transform.position;
        }
        else
        {
            SFXSource.Stop();
        }

        if (Input.GetKey("escape"))
        {
            Debug.Log("Escape hit, quitting");
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.R) && dead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void killed()
    {
        dead = true;
        moveSpeed = 0;
    }

    public bool checkAlive()
    {
        return dead;
    }

    public void setMovementVectors()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    private void Move()
    {
        float hor = Input.GetAxis("HorizontalKey");
        float ver = Input.GetAxis("VerticalKey");
        Vector3 rightMov = right * moveSpeed * Time.deltaTime * hor;
        Vector3 forwardMov = forward * moveSpeed * Time.deltaTime * ver;

        Vector3 heading = Vector3.Normalize(rightMov + forwardMov);
        transform.forward = heading;
        transform.position += rightMov;
        transform.position += forwardMov;
        Camera.main.transform.position += transform.position - prevPos;

        //footsteps
        if (!SFXSource.isPlaying)
            SFXSource.Play();
    }
}
