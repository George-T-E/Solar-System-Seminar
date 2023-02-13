using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    #region variables
    protected float inputAD, inputWS, mouseScrollWheel;
    protected float mouseSensitivity = 150;
    protected Vector3 cameraVelocity = new Vector3();
    protected Vector3 playerInput = new Vector3(0,0,0);
    
    #endregion

    public virtual void Update()
    {
        MoveObject();
        KeyboardInput();
    }
    //add the Keyboard and Mouse Inputs to create object movement
    protected abstract void MoveObject();

    //Get the keyboard input and return it to a Vector3
    protected Vector3 KeyboardInput()
    {
        if(Input.GetKey(KeyCode.W)) {
            inputWS = +1;
        }
        else if(Input.GetKey(KeyCode.S)) {
            inputWS = -1;
        }
        else if(Input.GetKey(KeyCode.A)) {
            inputAD = -1;
        }
        else if(Input.GetKey(KeyCode.D)) {
            inputAD = +1;
        }
        else {
            inputAD = 0;
            inputWS = 0;
        }
        return cameraVelocity = new Vector3(inputAD,0,inputWS);
    }

    //Get the Mouse ScrollWheel input and return it to a float
    protected float MouseInput() {
        mouseScrollWheel = mouseSensitivity * Input.GetAxis("Mouse ScrollWheel");
        mouseScrollWheel = -mouseScrollWheel;
        return mouseScrollWheel;
    }
}
