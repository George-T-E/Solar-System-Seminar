using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlanetNamePlate : MonoBehaviour
{
    public TextMeshProUGUI namePlate;
    public GameObject lookAt;
    public Vector3 offset, pos;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        namePlate = GetComponent<TextMeshProUGUI>();
        cam = GameManager._instance.currentActiveCamera;
    }

    // Update is called once per frame
    void Update()
    {
        cam = GameManager._instance.currentActiveCamera;
        lookAt = GameManager._instance.currentSelectedPlanet;
        namePlate.text = lookAt.name;
        pos = cam.WorldToScreenPoint(lookAt.transform.position + offset);

        if(transform.position != pos) {
            transform.position = pos;
        }
    }
}
