using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObject : MonoBehaviour
{
    public GameObject head;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = head.transform.position;
    }
}
