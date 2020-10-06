using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotSpeed;
    [SerializeField]
    CharController charController;
    Transform charTrans;


    // Start is called before the first frame update
    void Start()
    {
        charTrans = charController.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxisRaw("RotationKey") != 0.0f) {
            transform.RotateAround(charTrans.transform.position, Vector3.up, rotSpeed * Time.deltaTime * Input.GetAxisRaw("RotationKey"));
            charController.setMovementVectors();
        }
    }
}
