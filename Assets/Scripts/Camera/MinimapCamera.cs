using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    /*This script is used for the Minimap Camera
     * and it changes the focus of the Camera
     */
    #region Variables & Properties
    private GameObject currentTarget;
    private PlanetInformation planetInfo;
    #endregion
    #region MonoBehaviour Methods
    /* We register and unregister our ChangeFocus method to
     * the Event OnObjectClicked
     */
    private void OnEnable()
    {
        GameManager.OnObjectClicked += ChangeFocus;
    }
    private void OnDisable()
    {
        GameManager.OnObjectClicked -= ChangeFocus;
    }
    private void Awake()
    {
        GameManager.OnObjectClicked += ChangeFocus;
    }

    void Update()
    {
        MiniMapCameraPosition();
    }
    #endregion
    #region custom methods
    /* It checks the name of the planet and
     * changes accordingly the Z Axis of the Minimap Camera
     */
    private void MiniMapCameraPosition()
    {
        if (currentTarget != null)
        {
            transform.LookAt(currentTarget.transform);
            if (planetInfo == null) return;
            switch (planetInfo.PlanetName)
            {
                case "Ήλιος":
                    transform.position = currentTarget.transform.position - new Vector3(0, 0, -6);
                    break;
                case "Δίας":
                    transform.position = currentTarget.transform.position - new Vector3(0, 0, -3);
                    break;
                case "Κρόνος":
                    transform.position = currentTarget.transform.position - new Vector3(0, 0, -3);
                    break;
                case "Ουρανός":
                    transform.position = currentTarget.transform.position - new Vector3(0, 0, -3);
                    break;
                case "Ποσειδώνας":
                    transform.position = currentTarget.transform.position - new Vector3(0, 0, -3);
                    break;
                case "Σελίνη":
                    transform.position = currentTarget.transform.position - new Vector3(0, 0, -0.7f);
                    break;
                case "Πλούτωνας":
                    transform.position = currentTarget.transform.position - new Vector3(0, 0, -2);
                    break;
                default:
                    transform.position = currentTarget.transform.position - new Vector3(0, 0, -1);
                    break;
            }
        }
    }
    /* This script is Changing the focus of
     * the Minimap Camera
     */
    private void ChangeFocus(GameObject target)
    {
        currentTarget = target;
        transform.position = new Vector3(0,0,-1);
        transform.parent = currentTarget.transform;
        transform.LookAt(currentTarget.transform);
        planetInfo = currentTarget.GetComponent<PlanetInformation>();
    }

    #endregion
}
