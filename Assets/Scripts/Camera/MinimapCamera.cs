using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    #region variables
    private GameObject currentTarget;
    private PlanetInformation planetInfo;
    #endregion
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

    // Update is called once per frame
    void Update()
    {
        if(currentTarget != null)
        {
            transform.LookAt(currentTarget.transform);
            if(planetInfo == null)return;
            switch (planetInfo.PlanetName)
            {
                case "Ήλιος": 
                    transform.position = currentTarget.transform.position - new Vector3(0,0,-6);
                    break;
                case "Δίας":
                    transform.position = currentTarget.transform.position - new Vector3(0,0,-3);
                    break;
                case "Κρόνος":
                    transform.position = currentTarget.transform.position - new Vector3(0,0,-3);
                    break;
                case "Ουρανός":
                    transform.position = currentTarget.transform.position - new Vector3(0,0,-3);
                    break;
                case "Ποσειδώνας":
                    transform.position = currentTarget.transform.position - new Vector3(0,0,-3);
                    break;
                case "Σελίνη":
                    transform.position = currentTarget.transform.position - new Vector3(0,0,-0.7f);
                    break;
                default:
                    transform.position = currentTarget.transform.position - new Vector3(0,0,-1);
                    break;
            }
            
            
        }
    }
    #region custom methods
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
