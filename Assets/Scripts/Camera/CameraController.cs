using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region variables
    [SerializeField]private float moveSpeed = 25;
    private float rotateDir, mouseScroll;
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
    private void Update()
    {
        CameraMovement();
        CameraRotation();
    }

    #region custom methods


    private void CamLimits()
    {
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x,minX,maxX),
            Mathf.Clamp(transform.position.y,minY,maxY),
            Mathf.Clamp(transform.position.z,minZ,maxZ)
        );
    }
    private void CameraZoom()
    {
        mouseScroll = -(Input.GetAxisRaw("Mouse ScrollWheel") * moveSpeed);
    }
    private void CameraMovement()
    {
        Vector3 inputDir = new Vector3(0,0,0);
        CameraZoom();
        if(Input.GetKey(KeyCode.W)) inputDir.z = +1f;
        if(Input.GetKey(KeyCode.S)) inputDir.z = -1f;
        if(Input.GetKey(KeyCode.A)) inputDir.x = -1f;
        if(Input.GetKey(KeyCode.D)) inputDir.x = +1f;
        
        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x + transform.up * mouseScroll;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        CamLimits();
    }

    private void CameraRotation()
    {
        rotateDir = 0f;

        if(Input.GetKey(KeyCode.Q)) rotateDir = +1f;
        if(Input.GetKey(KeyCode.E)) rotateDir = -1f;

        transform.eulerAngles += new Vector3(0, rotateDir * moveSpeed *2f * Time.deltaTime, 0);
    }
    #endregion
}
