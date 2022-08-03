using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public int speed;
    public GameObject terrain;
    public bool shouldMove;
    public bool shouldRotate;
    public bool shouldSpawn;
    public Vector3 pos;
    public Vector3 originalPos;
    public bool shouldDestroy;
    public float originalY;
    public float originalY2;

    public float time;

    public Vector3 newPos;
    public Vector3 residentWalk;
    public bool returnHome;
    public bool getPoint;

    public bool shouldPickUp;
    public bool pickedUp;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        shouldMove = true;
        shouldRotate = false;
        shouldSpawn = false;
        shouldDestroy = false;
        returnHome = false;
        getPoint = false;
        shouldPickUp = false;

        Vector3 pos = new Vector3(0, 0, 0);
        transform.LookAt(pos);
        transform.localRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        originalY = transform.rotation.eulerAngles.y;
        originalY2 = transform.rotation.eulerAngles.y - 180;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            if (!shouldDestroy)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }

            if (shouldDestroy)
            {
                transform.position = Vector3.MoveTowards(transform.position, originalPos, speed * Time.deltaTime);
            }
        }

        if (shouldSpawn && !shouldPickUp)
        {
            foreach (Transform transform in gameObject.transform)
            {
                if (transform.name == "resident")
                {
                    transform.position = pos + new Vector3(0, 0, 0);
                }
            }

            StartCoroutine(ExampleCoroutine());
        }

        if (pickedUp)
        {
            shouldRotate = true;
            shouldDestroy = true;
        }

        if (shouldRotate)
        {
            if (!shouldDestroy)
            {
                transform.Rotate(Vector3.down * 30 * Time.deltaTime);
            }

            if (shouldDestroy)
            {
                transform.LookAt(originalPos);
                shouldRotate = false;
                shouldMove = true;
            }
        }

        if (shouldDestroy)
        {
            if(Vector3.Distance(transform.position, originalPos) <= 5)
            {
                Destroy(gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        RaycastHit hit2;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if(hit.distance <= 2 && hit.transform.name == "Terrain")
            {
                if (!shouldPickUp)
                {
                    shouldMove = false;
                    shouldRotate = true;
                    pos = hit.point;
                }
                else
                {
                    shouldMove = false;
                }
            }

            if(getPoint && hit.transform.name == "Terrain")
            {
                residentWalk = hit.point;
                getPoint = false;
            }
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit2, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit2.distance, Color.yellow);
            if (hit2.distance <= 2 && hit2.transform.name == "Terrain" && !shouldPickUp)
            {
                if (!shouldDestroy)
                {
                    shouldRotate = false;
                    shouldSpawn = true;
                }
            }
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);

        if (!shouldDestroy)
        {
            foreach (Transform transform in gameObject.transform)
            {
                if (transform.name == "resident")
                {
                    transform.transform.SetParent(transform.GetComponent<Resident>().realResidents.transform);
                    transform.GetComponent<Resident>().realResidents.transform.parent.GetComponent<SmallHouse>().Residents += 1;
                    transform.GetComponent<Resident>().landed = true;
                }
            }

            shouldRotate = true;
            shouldDestroy = true;
            //time *= 2;
        }
    }
}
