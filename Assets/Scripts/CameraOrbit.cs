using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed;
   
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, rotateSpeed * Time.deltaTime); 
    }
}
