using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saviorCube : MonoBehaviour
{
    public GameObject SaviorCube;
    public GameObject cube;
    public Vector3 pos;
    public bool canMove;
    public Transform parentObject;
    public bool willMove;

    void Start()
    {
        cube = Instantiate(SaviorCube, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));
        cube.SetActive(true);
        pos = cube.transform.position;
        cube.GetComponent<Renderer>().enabled = false;
        parentObject = GameObject.Find("Scrap Objects").transform;
        cube.transform.SetParent(parentObject);
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        cube.transform.Translate(Vector3.up * Time.deltaTime * 50, Space.World);
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        canMove = false;
        Destroy(cube);
        Destroy(transform.GetComponent<saviorCube>());
    }
}
