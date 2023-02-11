using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : InputController
{

    Vector3 playerInput = new Vector3(0,0,0);

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void MoveObject() {
        playerInput = (GetKeyboardInput() + new Vector3(0,GetMouseWheelInput(),0)) * Time.deltaTime * 20f;
        transform.position += playerInput;

        if(transform.position.y < 5.5f) {
            transform.position = new Vector3(transform.position.x,5.5f,transform.position.z);
        }
        else if(transform.position.y > 30f) {
            transform.position = new Vector3(transform.position.x, 30f, transform.position.z);
        }
    }
}
