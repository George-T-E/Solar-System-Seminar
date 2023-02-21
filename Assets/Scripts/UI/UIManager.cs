using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
public class UIManager : MonoBehaviour
{
    /* This script needs to be attached to an invisible object and it will handle
     * the UI text information when we select an object that is a planet and has the
     * PlanetInfo class on it by observing an Event of the GameManager.
     */
    #region Variables & Properties
    [SerializeField]private TextMeshProUGUI
    planetNameText,
    planetInfoText;
    public PlanetInformation planetInfo;
    public Vector3 offset;

    #endregion
    #region MonoBehaviour Methods
    /* Here we register our method to the Event and we unregister when is needed */
    private void OnEnable()
    {
        GameManager.OnObjectClicked += ChangeTarget;
    }
    private void OnDisable()
    {
        GameManager.OnObjectClicked -= ChangeTarget;
    }
    private void Start()
    {
        GameManager.OnObjectClicked += ChangeTarget;
    }
    #endregion
    #region custom methods
    /* This is the method we call when the Event is trigerred 
     * and we receive information of the PlanetInfo class that
     * is on the planet object and then we replace the UI text
     * with the info found on the planet
     */
    private void ChangeTarget(GameObject obj)
    {
        planetInfo = obj.GetComponent<PlanetInformation>();

        if(planetInfo == null)Debug.LogError("Planet info is null for some reason!");
        if(!planetNameText.gameObject.activeInHierarchy)planetNameText.gameObject.SetActive(true);
        if(!planetInfoText.gameObject.activeInHierarchy)planetInfoText.gameObject.SetActive(true);

        planetNameText.text = planetInfo.PlanetName;
        planetInfoText.text = planetInfo.PlanetInfo;
    }
    #endregion
}
