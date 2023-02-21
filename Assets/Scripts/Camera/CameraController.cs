using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /* This script is applied on an invisible object that Virtual Camera will be following
     * and it give's to the user the ability to control it and make it move around the scene.
     */

    #region Variables & Properties
    [SerializeField]private float moveSpeed = 25;
    private float rotateDir;
    [Tooltip("Camera Boundaries")]
    [SerializeField]private float 
        minX,
        maxX,
        minY,
        maxY,
        minZ,
        maxZ;
    float distance;
    #endregion
    #region MonoBehaviour Methods
    private void Update()
    {
        CameraMovement();
        CameraRotation();
    }
    #endregion
    #region Custom Methods

    /* Here we give limits to where the camera (player) can go when traveling around */

    private void CamLimits()
    {
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x,minX,maxX),
            Mathf.Clamp(transform.position.y,minY,maxY),
            Mathf.Clamp(transform.position.z,minZ,maxZ)
        );
    }

    /* We receive the Mouse ScrollWheel input and we return it later to use it as Camera Zoom*/

    private float CameraZoom()
    {
        return -(Input.GetAxisRaw("Mouse ScrollWheel") * moveSpeed);
    }

    /* Here we apply the movement input to the object that Camera is following. */

    private void CameraMovement()
    {
        Vector3 inputDir = new Vector3(0,0,0);
        CameraZoom();
        if(Input.GetKey(KeyCode.W)) inputDir.z = +1f;
        if(Input.GetKey(KeyCode.S)) inputDir.z = -1f;
        if(Input.GetKey(KeyCode.A)) inputDir.x = -1f;
        if(Input.GetKey(KeyCode.D)) inputDir.x = +1f;
        
        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x + transform.up * CameraZoom();
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        CamLimits();
    }

    /* Here we apply rotation to the object that Camera is following. */

    private void CameraRotation()
    {
        rotateDir = 0f;

        if(Input.GetKey(KeyCode.Q)) rotateDir = +1f;
        if(Input.GetKey(KeyCode.E)) rotateDir = -1f;

        transform.eulerAngles += new Vector3(0, rotateDir * moveSpeed *2f * Time.deltaTime, 0);
    }
    #endregion
}
