using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    TerrainCollider terrain;
    [SerializeField]
    float rotSpeed;
    private Vector3 centerPos;
    [SerializeField]
    CharController charController;

    // Start is called before the first frame update
    void Start()
    {
        centerPos = terrain.bounds.center;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("RotationKey") != 0.0f) {
            transform.RotateAround(centerPos, Vector3.up, rotSpeed * Time.deltaTime * Input.GetAxisRaw("RotationKey"));
            charController.setMovementVectors();
        }

    }
}
