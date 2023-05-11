using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
/// <summary>
/// Attach this script on any Object and it will handle the proccess to change
/// the UI when the user clicks on a Planet by using the Event OnObjectClicked
/// that is created by the GameManager
/// </summary>
public class UIManager : MonoBehaviour
{

     
    #region Variables & Properties
    [SerializeField]private TextMeshProUGUI
    planetNameText,
    planetInfoText,
    planetInfoText2;
    [SerializeField] private GameObject planetBgUI;
    public CelestialBodyInfo planetInfo;
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

    /// <summary>
    /// When the user clicks on an planet object we call this method
    /// that takes the planet as an object and then receive's the
    /// information of the PlanetInfo class that
    /// is attached to the planet object and then we replace the UI text
    /// with the new PlanetInfo.
    /// (Assign this to OnEnable() GameManager.OnObjectClicked += ChangeTarget;)
    /// (Assign this to OnDisable() GameManager.OnObjectClicked -= ChangeTarget;)
    /// </summary>
    /// <param name="obj">This is the new planet object the user clicked.</param>
    private void ChangeTarget(GameObject obj)
    {
        if(obj != null)
        {
            if(obj.name == "Empty")
            {
                planetBgUI.SetActive(false);
            }
            else
            {
                planetInfo = obj.GetComponent<CelestialBodyInfo>();
                planetBgUI.SetActive(true);

                planetNameText.text = planetInfo.PlanetName;
                planetInfoText.text = planetInfo.PlanetInfo;
                planetInfoText2.text = planetInfo.PlanetInfo2;
            }

        }
    }
    #endregion
}
