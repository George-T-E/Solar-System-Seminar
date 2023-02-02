using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        if(target==null)Debug.LogError("Look at target is null!");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
