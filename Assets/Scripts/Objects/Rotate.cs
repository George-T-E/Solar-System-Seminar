using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject target;
    public float rotationSpeed = 15f;
    public float 
    rotateX = 0f,
    rotateY = 0f,
    rotateZ = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if(target == null)target = this.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, new Vector3(rotateX,rotateY,rotateZ), rotationSpeed * Time.deltaTime);
    }

}
