using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCameraController : InputController
{
    public GameObject target;
    Vector3 playerInput = new Vector3(0,0,0);
    
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
        this.transform.position = target.position;
        transform.parent = target;

    }

    // public void KeepDistanceWithTarget() {
    //     // float distance = Vector3.Distance(target.transform.position, this.transform.position);
    //     // if(distance < 10) {
    //     //     this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 10f);
    //     // }
    //     // else if(distance > 15) {
    //     //     this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 15);
    //     // }
    // }

    public override void MoveObject() {
        this.transform.position = new Vector3(0,0,6f) + target.transform.position;
        transform.LookAt(target.transform);            
    }
}
