using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;
/// <summary>
/// This script is attached on a 3D object (Planet)
/// and is used to store the name of the Planet
/// and some information about planet.
/// Then the UI Manager will try to get that information
/// and show it to the user
/// </summary>
public class PlanetInformation : MonoBehaviour
{

    
    #region Variables & Properties
    /*We are encapsulating our information and we use
     * get and set to access it
     */
    [SerializeField]private string planetName;
    public string PlanetName
    {
        get { return planetName; }
        set { planetName = value; }
    }

    [TextArea]
    [SerializeField]private string planetInfo;
    public string PlanetInfo
    {
        get { return planetInfo; }
        set { planetInfo = value; }
    }
    #endregion
}
