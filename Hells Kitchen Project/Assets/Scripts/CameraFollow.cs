using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed;
    private float rotateDir;

    private void Update()
    {
        rotateDir = Input.GetAxisRaw("Rotate") * rotationSpeed;

        Debug.Log(rotateDir);
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, rotateDir) * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
