using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorChild : MonoBehaviour
{
    public Renderer rend;
    public Color originalColor;
    public bool isTouching;
    public int trail1 = 0;
    public GameObject saviorCube;
    public GameObject cube;
    public Vector3 pos;
    public bool canMove;
    public Transform parentObject;
    public bool willMove;

    public void Awake()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
        canMove = true;
        willMove = false;
        isTouching = false;
    }

    public void Start()
    {
        isTouching = false;

        /*cube = Instantiate(saviorCube, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));
        cube.SetActive(true);
        pos = cube.transform.position;
        cube.GetComponent<Renderer>().enabled = false;
        parentObject = GameObject.Find("Scrap Objects").transform;
        cube.transform.SetParent(parentObject);

        StartCoroutine(ExampleCoroutine());*/
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            transform.parent.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

        willMove = true;
    }

    public void OnEnable()
    {
        if(this.enabled)
        {
            if (willMove)
            {
                isTouching = false;

                /*cube = Instantiate(saviorCube, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));
                cube.SetActive(true);
                pos = cube.transform.position;
                cube.GetComponent<Renderer>().enabled = false;
                parentObject = GameObject.Find("Scrap Objects").transform;
                cube.transform.SetParent(parentObject);

                StartCoroutine(ExampleCoroutine()); */
        for (int i = 0; i < transform.parent.childCount; i++)
                {
                    transform.parent.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.green;
                }

                canMove = true;
            }
        }
    }


    public void Update()
    {
        if (canMove)
        {
            //cube.transform.Translate(Vector3.up * Time.deltaTime * 30, Space.World);
        }
    }

    public void OnDisable()
    {
        rend.material.color = originalColor;
        //Destroy(cube);
    }

    public void OnCollisionEnter(Collision other)
    {
        if(this.enabled)
        {
            transform.parent.GetComponent<ChangeColor>().CollisionDetected(this);

            if (other.gameObject.name != "terrain")
            {
                isTouching = true;

                for (int i = 0; i < transform.parent.childCount; i++)
                {
                    transform.parent.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.red;
                }

                //trail1 = 0;

            }
        }

        //print(other.gameObject.name);
    }

    public void OnCollisionExit(Collision other)
    {
        if (this.enabled)
        {
            transform.parent.GetComponent<ChangeColor>().CollisionDetected(this);

            if (other.gameObject.name != "terrain")
            {
                isTouching = false;

                for (int i = 0; i < transform.parent.childCount; i++)
                {
                    if (transform.parent.transform.GetChild(i).gameObject.GetComponent<ChangeColorChild>().isTouching == true)
                    {
                        trail1++;
                    }
                }

                if (trail1 == 0)
                {
                    for (int i = 0; i < transform.parent.childCount; i++)
                    {
                        transform.parent.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.green;
                    }
                }

                trail1 = 0;
            }
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        canMove = false;
        Destroy(cube);
    }
}