using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
public class UIManager : MonoBehaviour
{
    #region variables
    [SerializeField]private TextMeshProUGUI
    planetNameText,
    planetInfoText;
    public PlanetInformation planetInfo;
    public Vector3 offset;

    #endregion
    private void OnEnable()
    {
        GameManager.OnObjectClicked += ChangeTarget;
    }
    private void OnDisable()
    {
        GameManager.OnObjectClicked -= ChangeTarget;
    }
    private void Awake()
    {
        GameManager.OnObjectClicked += ChangeTarget;
    }

    #region custom methods
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
