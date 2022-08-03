using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderCam : MonoBehaviour
{
    private RaycastHit hit;
    private Vector3 pos;
    private int speed = 15;
    public float num;
    public GameObject terrain;
    public GameObject builderCam;
    public Transform cameraTransform;
    private RaycastHit[] hits;
    public float offset;
    public float test;
    public GameObject objectOffset;
    float difference;

    void Start()
    {
        cameraTransform = builderCam.transform;
    }

    private void OnEnable()
    {
        pos = GameObject.Find("Player").transform.position;
        gameObject.transform.position = new Vector3(pos.x, pos.y + 35, pos.z);
    }

    void Update()
    {
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 100.0f))
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 100.0f, Color.yellow);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }

        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (hits[i].collider.gameObject.name == "Terrain")
            {
                num = hits[i].point.y - difference;
                gameObject.transform.position = new Vector3(transform.position.x, num + offset, transform.position.z);
                break;
            }
        }
        
    }
}
