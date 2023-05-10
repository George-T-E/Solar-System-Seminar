using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scriptable object it is used like a blueprint
/// to create our planet information cards for each planet
/// through the Asset Menu
/// </summary>

[CreateAssetMenu(fileName="Planet_Info", menuName ="Create Planet Info Card")]
public class PlanetSO : ScriptableObject
{
    [SerializeField]private string pName;

    public string PlanetName
    {
        get { return pName; }
    }

    [TextArea][SerializeField]private string pInfo1;

    public string PlanetInfo1
    {
        get { return pInfo1; }
    }

    [SerializeField] private string pInfo2;

    public string PlanetInfo2
    {
        get { return pInfo2; }
    }

    [SerializeField] private AudioClip pNarratorClip;

    public AudioClip PlanetNarratorClip
    {
        get { return pNarratorClip; }
    }

}
