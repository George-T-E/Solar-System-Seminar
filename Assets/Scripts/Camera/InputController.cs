using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    #region variables
    float xSensitivity, ySensivity, mouseScrollWheel;
    float mouseSensitivity = 150;

    
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        MoveObject();
    }
    //add the Keyboard and Mouse Inputs to create object movement
    public abstract void MoveObject();

    //Get the keyboard input and return it to a Vector3
    public Vector3 GetKeyboardInput() {
        Vector3 cameraVelocity = new Vector3();


        if(Input.GetKey(KeyCode.W)) {
            cameraVelocity = new Vector3(0,0,1);
        }
        else if(Input.GetKey(KeyCode.S)) {
            cameraVelocity = new Vector3(0,0,-1);
        }
        else if(Input.GetKey(KeyCode.A)) {
            cameraVelocity = new Vector3(-1,0,0);
        }
        else if(Input.GetKey(KeyCode.D)) {
            cameraVelocity = new Vector3(1,0,0);
        }
        else {
            cameraVelocity = new Vector3(0,0,0);
        }
        return cameraVelocity;
    }

    //Get the Mouse ScrollWheel input and return it to a float
    public float GetMouseWheelInput() {
        mouseScrollWheel = mouseSensitivity * Input.GetAxis("Mouse ScrollWheel");
        mouseScrollWheel = -mouseScrollWheel;
        return mouseScrollWheel;
    }
}
