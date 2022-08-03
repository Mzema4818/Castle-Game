using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBuilderCam : MonoBehaviour
{
    public GameObject builderCam;
    private Vector3 pos;
    private int speed = 15;
    public float offset;
    public bool stop;
    public float positionY;
    public float positionY2;
    public bool stop2;

    // Start is called before the first frame update
    void Start()
    {
        pos = GameObject.Find("Build Camera").transform.position;
        positionY = transform.position.y;
        positionY2 = pos.y;

        /*if (stop)
        {
            offset = (positionY - (positionY2 - 31)) / 2;
            stop = false;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        pos = GameObject.Find("Build Camera").transform.position;

        gameObject.transform.position = new Vector3(pos.x ,pos.y - 31 + offset, pos.z);;
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(new Vector3(0, speed * Time.deltaTime * 60, 0));
        }
    }
}
