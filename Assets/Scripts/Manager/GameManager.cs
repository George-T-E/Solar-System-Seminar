using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public List<AudioClip> clickSounds = new List<AudioClip>();
    AudioSource audioSource;
    public GameObject mainCam, planetCam, currentSelectedPlanet;
    public Transform mainCamStartLoc;

    public Camera currentActiveCamera;

    Transform target;
    private void Awake() {
        if(_instance == null) _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.gameObject;
        currentActiveCamera = mainCam.GetComponent<Camera>();
        if(planetCam == null)Debug.LogError("Planet cam is NULL!");
    }

    void Update() {
        ResetCamera();
        SwapCameraOnPlanetClick();
    }

    public void ResetCamera() {
        if(Input.GetKeyDown(KeyCode.R)) {
            mainCam.transform.position = mainCamStartLoc.position;
            planetCam.SetActive(false);
            mainCam.SetActive(true);
            currentActiveCamera = mainCam.GetComponent<Camera>();
            audioSource = mainCam.GetComponent<AudioSource>();
        }
    }

    //Throw a raycast and check if it's a planet, if it's a planet camera will look at it and will play a short sound
    public void SwapCameraOnPlanetClick() {

        if(Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) {
                
                if(hit.collider.gameObject.CompareTag("SpaceObject")) {

                    // Debug.Log($"{hit.collider.name} Space Object Selected", hit.collider.gameObject);
                    
                    target = hit.collider.gameObject.transform;
                    currentSelectedPlanet = target.gameObject;
                    planetCam.transform.LookAt(target);
                    mainCam.SetActive(false);
                    planetCam.SetActive(true);
                    PlanetCameraController pCamController = planetCam.GetComponent<PlanetCameraController>();
                    currentActiveCamera = planetCam.GetComponent<Camera>();
                    pCamController.ChangeTarget(target);
                    

                    audioSource = planetCam.GetComponent<AudioSource>();
                    int randomRange;
                    randomRange = Random.Range(0,1);
                    if(clickSounds[randomRange] != null)audioSource.PlayOneShot(clickSounds[randomRange]);
                }
                else {
                    Debug.Log("The object you collided with is not a SpaceObject" + hit.collider.gameObject);
                }         
            }
        }
    }


}
