using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInformation : MonoBehaviour
{

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
    
}
