using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCameraController : InputController
{
    public GameObject target;
    Vector3 playerInput = new Vector3(0,0,0);
    float x,y;
    float distance;
    
    // Start is called before the first frame update
    void Start()
    {
        if(target == null)Debug.LogError("Default target is missing");
        //transform.LookAt(target.transform);
        ChangeTarget(target.transform);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public void ChangeTarget(Transform target) {
        this.target = target.gameObject;
        // this.transform.position = target.position;
        transform.position = target.transform.position + (transform.position - target.transform.position).normalized * 6f;
        transform.parent = target;

    }

    /*
        target.position retrieves the position of the target object.

        Quaternion.Euler(y, x, 0) creates a rotation represented by Euler angles (y, x, 0) in degrees. y and x are the angles that control the camera's up and right rotation, respectively.

        Vector3.forward is a constant vector pointing forward along the z-axis.

        Quaternion.Euler(y, x, 0) * Vector3.forward rotates the forward vector by the specified Euler angles. The result is a vector pointing in the direction the camera should be facing.

        target.position - (Quaternion.Euler(y, x, 0) * Vector3.forward * distance) calculates the position of the camera by subtracting the rotated forward vector from the position of the target. This places the camera at a certain distance from the target in the direction specified by the rotated forward vector.

        transform.position = target.position - (Quaternion.Euler(y, x, 0) * Vector3.forward * distance) sets the position of the camera to the calculated position.

        So in essence, this line of code rotates the camera around the target object based on the angles y and x and sets the camera's position so that it is distance units away from the target in the direction specified by the rotated forward vector.

    */

    public override void MoveObject() {
        transform.LookAt(target.transform.position);


        transform.position = target.transform.position - Quaternion.Euler(y, x, 0) * Vector3.forward * 6f;


        
        if (Input.GetKey(KeyCode.W))
        {
            y += 2f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            y -= 2f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            x += 2f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            x -= 2f;
        }
        // transform.LookAt(target);
        // this.transform.position = new Vector3(0,0,GetMouseWheelInput()) * mouseSensitivity * Time.deltaTime;
        

    }
}
