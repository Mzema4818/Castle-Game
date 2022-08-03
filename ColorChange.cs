using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color[] rend;

    // Start is called before the first frame update
    void Awake()
    {
        rend = new Color[transform.childCount];

        transform.GetComponent<BoxCollider>().enabled = true;

        for (int i = 0; i < rend.Length; i++)
        {
            rend[i] = transform.GetChild(i).GetComponent<Renderer>().material.color;
            transform.GetChild(i).gameObject.GetComponent<MeshCollider>().convex = false;
            transform.GetChild(i).GetComponent<MeshCollider>().enabled = false;
        }

        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionStay(Collision other)
    {
        if(other.transform.name != "Terrain")
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    public void OnCollisionExit(Collision other)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Renderer>().material.color = Color.green;
        }
    }

    private void OnDestroy()
    {
        Destroy(transform.GetComponent<Rigidbody>());
        for (int i = 0; i < rend.Length; i++)
        {
            transform.GetChild(i).GetComponent<Renderer>().material.color = rend[i];
            transform.GetChild(i).gameObject.GetComponent<MeshCollider>().convex = true;
            transform.GetChild(i).GetComponent<MeshCollider>().enabled = true;
        }
        transform.GetComponent<BoxCollider>().enabled = false;
    }

    IEnumerator ExampleCoroutine()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = transform.position;
        yield return new WaitForSeconds(0);
        Destroy(cube);
    }
}
