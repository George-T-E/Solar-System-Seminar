using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
        A listener is an object that listens for events and performs some action in response to them.
        In C#, delegates are often used to implement event listeners.
        An event publisher defines an event using a delegate,
        and event subscribers can then register methods to be called when the event is triggered.
    */
    /*
        Ένας ακροατής είναι ένα αντικείμενο που ακούει για συμβάντα και εκτελεί κάποια ενέργεια ως απόκριση σε αυτά.
        Στη C#, οι εκπρόσωποι χρησιμοποιούνται συχνά για την υλοποίηση ακροατών συμβάντων.
        Ένας εκδότης συμβάντος ορίζει ένα συμβάν χρησιμοποιώντας μια αντιπροσωπεία,
        και οι συνδρομητές συμβάντων μπορούν στη συνέχεια να καταχωρίσουν μεθόδους που θα κληθούν όταν ενεργοποιηθεί το συμβάν.
    */
    #region variables
    public delegate void ObjectClickedAction(GameObject obj);
    public static event ObjectClickedAction OnObjectClicked;

    [SerializeField]private GameObject cameraSystem;
    public List<AudioClip> clickSounds = new List<AudioClip>();
    AudioSource audioSource;
    public GameObject targetedPlanet;
    public Transform mainCamStartLoc;

    [SerializeField]ICinemachineCamera activeVirtualCamera;
    Transform target;

    GameObject emptyObject;
    #endregion

    void Start()
    {
        emptyObject = new GameObject("Empty");
        activeVirtualCamera = CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera;

    }

    void Update()
    {
        EndGame();
        SwapCameraOnPlanetClick();
    }

    #region custom methods

    private void EndGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //Throw a raycast and check if it's a planet, if it's a planet camera will look at it and will play a sound
    //and the the listeners will get informed about the object and do their actions
    private void SwapCameraOnPlanetClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.CompareTag("SpaceObject"))
                {
                    targetedPlanet = hit.collider.gameObject;
                    if(OnObjectClicked != null) OnObjectClicked((GameObject)targetedPlanet);

                    target = hit.collider.gameObject.transform;

                    cameraSystem.transform.position = target.position;
                    audioSource = target.GetComponent<AudioSource>();

                    AudioClip planetAudio = targetedPlanet.GetComponent<CelestialBodyInfo>().PlanetNarrator;

                    if (planetAudio != null) PlayAudio(planetAudio);
                }
            }
            else
            {
                OnObjectClicked(emptyObject);
            }
        }
    }

    //give it id of a sound and it will play it
    public void PlayAudio(int track)
    {
        if(clickSounds[track] == null)
        {
            Debug.Log("The audio file is null");
            return;
        }
        audioSource.PlayOneShot(clickSounds[track]);
    }

    public void PlayAudio(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.Log("The audio file is null");
            return;
        }

        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
    #endregion
}
