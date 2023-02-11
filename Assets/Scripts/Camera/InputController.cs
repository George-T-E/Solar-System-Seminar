using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    #region variables
    float xInput, zInput, mouseScrollWheel;
    protected float mouseSensitivity = 150;
    Vector3 cameraVelocity = new Vector3();
    
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
        
        if(Input.GetKey(KeyCode.W)) {
            zInput = 1;
        }
        else if(Input.GetKey(KeyCode.S)) {
            zInput = -1;
        }
        else if(Input.GetKey(KeyCode.A)) {
            xInput = -1;
        }
        else if(Input.GetKey(KeyCode.D)) {
            xInput = 1;
        }
        else {
            xInput = 0;
            zInput = 0;
        }
        cameraVelocity = new Vector3(xInput,0,zInput);
        return cameraVelocity;
    }

    //Get the Mouse ScrollWheel input and return it to a float
    public float GetMouseWheelInput() {
        mouseScrollWheel = mouseSensitivity * Input.GetAxis("Mouse ScrollWheel");
        mouseScrollWheel = -mouseScrollWheel;
        return mouseScrollWheel;
    }
}
