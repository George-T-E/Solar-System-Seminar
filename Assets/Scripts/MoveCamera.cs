using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public List<AudioClip> clickSounds = new List<AudioClip>();
    AudioSource audioSource;
    Transform target;

    Vector3 playerInput = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        SelectObjectWithClick();

        playerInput = GetKeyboardInput() * Time.deltaTime * 20f;

        transform.position += playerInput;
    }

    //Check if the player pressed any keyboard Input and return the Vector3
    public Vector3 GetKeyboardInput() {
        Vector3 cameraVelocity = new Vector3();


        if(Input.GetKey(KeyCode.W)) {
            cameraVelocity = new Vector3(0,0,1);
        }
        else if(Input.GetKey(KeyCode.S)) {
            cameraVelocity = new Vector3(0,0,-1);
        }
        else if(Input.GetKey(KeyCode.A)) {
            cameraVelocity = new Vector3(-1,0,0);
        }
        else if(Input.GetKey(KeyCode.D)) {
            cameraVelocity = new Vector3(1,0,0);
        }
        else {
            cameraVelocity = new Vector3(0,0,0);
        }
        return cameraVelocity;
    }
    //Throw a raycast and check if it's a planet, if it's a planet camera will look at it and will play a short sound
    public void SelectObjectWithClick() {

        if(Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) {
                
                if(hit.collider.gameObject.CompareTag("SpaceObject")) {

                    Debug.Log($"{hit.collider.name} Space Object Selected", hit.collider.gameObject);

                    target = hit.collider.gameObject.transform;
                    transform.LookAt(target);

                    int randomRange;
                    randomRange = Random.Range(0,1);
                    audioSource.PlayOneShot(clickSounds[randomRange]);
                } else {
                    Debug.Log("The object you collided with is not a SpaceObject" + hit.collider.gameObject);
                }
                
            }
        }

    }
}
