using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public bool canStart;
    public GameObject screen;
    public Vector3 pos;
    public Quaternion rot;

    // Update is called once per frame
    void Awake()
    {
        pos = gameObject.transform.position;
        rot = gameObject.transform.rotation;
    }

    private void Start()
    {
        canStart = false;
    }
    void Update()
    {
        if (canStart)
        {
            offset = new Vector3(0, 0, 0);
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothPosition;
        }
    }

    public void startGame()
    {
        canStart = true;
        screen.SetActive(false);
    }
    public void stopGame()
    {
        canStart = false;
        screen.SetActive(true);
        transform.position = pos;
        transform.rotation = rot;
    }
}
