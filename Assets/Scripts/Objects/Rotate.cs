using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script can be attached to any 3D object
/// and it will make it rotate around the target
/// on the X Y Z axis. and if there is no target
/// it will rotate around itself.
/// </summary>
public class Rotate : MonoBehaviour
{

    
    #region Variables & Properties
    /*variables here should be [SerializeField] private instead of public
     * you can change it but you need to attach the targets to the planets
     from scratch*/
    public GameObject target;
    public float rotationSpeed = 15f;
    public float 
    rotateX = 0f,
    rotateY = 0f,
    rotateZ = 0f;
    #endregion
    #region MonoBehaviour Methods
    /* If there is no target then itself is the target
     */
    void Start()
    {
        if(target == null)target = this.gameObject;
    }
    /* We use one line of code to achieve the rotation
     */
    void Update()
    {
        transform.RotateAround(target.transform.position, new Vector3(rotateX,rotateY,rotateZ), rotationSpeed * Time.deltaTime);
    }
    #endregion
}
