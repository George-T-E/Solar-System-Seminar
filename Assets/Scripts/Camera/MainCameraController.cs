using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : InputController
{
    public override void Update()
    {
        base.Update();
    }
    protected override void MoveObject() {
        playerInput = (KeyboardInput() + new Vector3(0,MouseInput(),0)) * Time.deltaTime;
        transform.position += playerInput;

        if(transform.position.y < 5.5f) {
            transform.position = new Vector3(transform.position.x,5.5f,transform.position.z);
        }
        else if(transform.position.y > 30f) {
            transform.position = new Vector3(transform.position.x, 30f, transform.position.z);
        }
    }
}
