using System.Collections.Generic;
using UnityEngine;

public class ShowCorners : MonoBehaviour
{

    private GameObject plane;
    private GameObject cube;
    private int rotationNum;
    public GameObject[] allCubes;
    public GameObject emptyobject;
    public bool isModel;
    public GameObject scaffolding;
    bool makeCubes = true;

    List<Color> CornerColors = new List<Color>() { Color.red, Color.blue, Color.yellow, Color.green }; //Different colors for different corners

    // Start is called before the first frame update
    void Start()
    {
        scaffolding = GameObject.Find("Scaffoldings");
        Vector3 sizeCalculated = GetComponent<Renderer>().bounds.size;

        emptyobject = new GameObject("parentOfScaffolding");
        emptyobject.name = gameObject.transform.name + " scaffolding";
        emptyobject.transform.parent = scaffolding.transform;

        rotationNum = 0;
        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.name = "fuckme";
        plane.transform.localPosition = gameObject.transform.localPosition;
        plane.transform.eulerAngles = gameObject.transform.eulerAngles;
        plane.transform.localScale = gameObject.transform.localScale / 10;
        plane.GetComponent<MeshRenderer>().enabled = false;
        plane.GetComponent<MeshCollider>().enabled = false;
        plane.AddComponent<FindCornerPlane>();
        allCubes = new GameObject[4];

        //Destroy(plane);
    }

    void Update()
    {
        if (makeCubes)
        {
            int b = 0;
            if (plane.GetComponent<FindCornerPlane>().VerticeList.Count > 0)
                for (int a = 0; a < plane.GetComponent<FindCornerPlane>().VerticeListToShow.Count; a++)
                {
                    GameObject parentCube = new GameObject("parentCube");
                    //parentCube.transform.parent = gameObject.transform;
                    //parentCube.transform.position = new Vector3(VerticeListToShow[a].x / 10, VerticeListToShow[a].y, VerticeListToShow[a].z / 10);

                    if (a == 0)
                    {
                        rotationNum = 90;
                    }
                    if (a == 1)
                    {
                        rotationNum = 0;
                    }
                    if (a == 2)
                    {
                        rotationNum = 180;
                    }
                    if (a == 3)
                    {
                        rotationNum = 270;
                    }

                    cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.name = "Legs" + rotationNum;
                    cube.transform.parent = parentCube.transform;
                    parentCube.transform.position = new Vector3(plane.GetComponent<FindCornerPlane>().VerticeListToShow[a].x, gameObject.transform.position.y, plane.GetComponent<FindCornerPlane>().VerticeListToShow[a].z); ;
                    cube.transform.position = new Vector3(plane.GetComponent<FindCornerPlane>().VerticeListToShow[a].x, gameObject.transform.position.y, plane.GetComponent<FindCornerPlane>().VerticeListToShow[a].z);
                    cube.transform.position += new Vector3(0, -0.5f, 0);
                    cube.transform.localEulerAngles = new Vector3(0, gameObject.transform.localEulerAngles.y, 0);

                    cube.GetComponent<Renderer>().material.color = CornerColors[b++];
                    cube.AddComponent<Rigidbody>();
                    cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ |
                                                                 RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX |
                                                                 RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;
                    cube.GetComponent<Rigidbody>().useGravity = false;
                    cube.AddComponent<Cubescript>();
                    cube.GetComponent<Cubescript>().fullParent = emptyobject;
                    cube.GetComponent<Cubescript>().initalObject = gameObject;
                    cube.transform.parent.parent = emptyobject.transform;
                    //cube.AddComponent<TestScript>();
                    allCubes[a] = cube;
                }

            var temp = allCubes[0];
            allCubes[0] = allCubes[0 + 1];
            allCubes[0 + 1] = temp;

            int num = 1;
            int num2 = 3;
            int num3 = 2;

            for (int i = 0; i < allCubes.Length; i++)
            {
                allCubes[i].GetComponent<Cubescript>().origin = allCubes[num];
                //allCubes[i].GetComponent<TestScript>().origin = allCubes[num];
                allCubes[i].GetComponent<Cubescript>().itSelf = allCubes[i];
                allCubes[i].GetComponent<Cubescript>().itSelf = allCubes[i];
                allCubes[i].GetComponent<Cubescript>().backOne = allCubes[num2];
                allCubes[i].GetComponent<Cubescript>().across = allCubes[num3];

                num++;
                num2++;
                num3++;
                if (num == 4)
                {
                    num = 0;
                }
                if (num2 == 4)
                {
                    num2 = 0;
                }
                if (num3 == 4)
                {
                    num3 = 0;
                }
            }

            makeCubes = false;
        }
    }


}