using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubescript : MonoBehaviour
{
    private bool stop;
    private GameObject plane1;
    private GameObject plane2;
    private float distance1;
    private float distance2;
    private float offset;
    private int rotationNum;
    private Vector3[] inwardValuesTop;
    private Vector3[] outwardValuesTop;
    private Vector3[] inwardValuesBottom;
    private Vector3[] outwardValuesBottom;
    public Vector3[] centerValues;
    private float[] centerValuesAngle;
    private float[] centerValuesDistance;
    public GameObject origin;
    public GameObject[] canStart;
    public GameObject fullParent;
    public bool didFinish;
    public bool pleaseStop;
    private bool pleaseStop2;
    private bool displayOnce;
    public bool changeAngle;
    private bool spawnOnce;
    public GameObject itSelf;
    public GameObject backOne;
    public GameObject across;
    public GameObject initalObject;

    List<Vector3> VerticeList = new List<Vector3>(); //List of global vertices on the plane
    List<Vector3> VerticeListToShow = new List<Vector3>();

    List<Color> CornerColors = new List<Color>() { Color.red, Color.blue, Color.yellow, Color.green }; //Different colors for different corners

    private void Start()
    {
        spawnOnce = false;
        changeAngle = false;
        displayOnce = false;
        pleaseStop = false;
        pleaseStop2 = true;
        canStart = initalObject.GetComponent<ShowCorners>().allCubes;
        didFinish = false;
        inwardValuesTop = new Vector3[2];
        outwardValuesTop = new Vector3[2];
        inwardValuesBottom = new Vector3[2];
        outwardValuesBottom = new Vector3[2];
        centerValues = new Vector3[4];
        centerValuesAngle = new float[3];
        centerValuesDistance = new float[2];

        rotationNum = int.Parse(gameObject.name.Substring(4));
        distance1 = gameObject.transform.parent.localScale.y;
        stop = false;

        plane1 = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane1.transform.position = gameObject.transform.position;
        plane1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        plane1.transform.position = gameObject.transform.position;
        plane1.transform.position += new Vector3(0, 0.5f, 0);
        plane1.transform.eulerAngles = new Vector3(
                            plane1.transform.eulerAngles.x,
                            plane1.transform.eulerAngles.y + rotationNum,
                            plane1.transform.eulerAngles.z
                        );
        plane1.GetComponent<MeshRenderer>().enabled = false;
        plane1.GetComponent<MeshCollider>().enabled = false;

        VerticeList = new List<Vector3>(plane1.GetComponent<MeshFilter>().sharedMesh.vertices); //get vertice points from the mesh of the object

        SetCornerPoints(1);

        inwardValuesTop[0] = VerticeListToShow[2];
        inwardValuesTop[1] = VerticeListToShow[3];

        outwardValuesTop[0] = VerticeListToShow[0];
        outwardValuesTop[1] = VerticeListToShow[2];

        //red (0)
        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.transform.position = CenterOfVectors(inwardValuesTop);
        centerValues[0] = CenterOfVectors(inwardValuesTop);
        //cube.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        //cube.GetComponent<Renderer>().material.color = Color.red;

        //blue (1)
        //GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube2.transform.position = CenterOfVectors(outwardValuesTop);
        centerValues[1] = CenterOfVectors(outwardValuesTop);
        itSelf.transform.parent.position += new Vector3(0, 0.1f, 0);
        //cube2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        //cube2.GetComponent<Renderer>().material.color = Color.blue;
    }

    private void Update()
    {
        if (!stop)
        {
            gameObject.transform.parent.localScale += new Vector3(0, 0.05f, 0);
            displayOnce = true;
        }

        if (stop && displayOnce)
        {
            if (itSelf.transform.parent.localScale.y <= origin.transform.parent.localScale.y)
            {
                changeAngle = true;
                displayOnce = false;

            }
        }

        if (!pleaseStop && canStart[0].GetComponent<Cubescript>().didFinish && canStart[1].GetComponent<Cubescript>().didFinish && canStart[2].GetComponent<Cubescript>().didFinish && canStart[3].GetComponent<Cubescript>().didFinish)
        {
            float[] arr = { itSelf.transform.parent.localScale.y, origin.transform.parent.localScale.y, backOne.transform.parent.localScale.y, across.transform.parent.localScale.y };

            //print2Smallest(arr);

            distance2 = gameObject.transform.parent.localScale.y;
            offset = (distance1 - distance2) / 2;
            plane2 = GameObject.CreatePrimitive(PrimitiveType.Plane);
            plane2.transform.position = gameObject.transform.position;
            plane2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            plane2.transform.position = gameObject.transform.position;
            plane2.transform.position += new Vector3(0, offset - 0.5f, 0);
            plane2.transform.eulerAngles = new Vector3(
                    plane2.transform.eulerAngles.x,
                    plane2.transform.eulerAngles.y + rotationNum,
                    plane2.transform.eulerAngles.z
                );

            plane2.GetComponent<MeshRenderer>().enabled = false;
            plane2.GetComponent<MeshCollider>().enabled = false;

            VerticeList = new List<Vector3>(plane1.GetComponent<MeshFilter>().sharedMesh.vertices); //get vertice points from the mesh of the object

            SetCornerPoints(2);

            inwardValuesBottom[0] = VerticeListToShow[2];
            inwardValuesBottom[1] = VerticeListToShow[3];

            outwardValuesBottom[0] = VerticeListToShow[0];
            outwardValuesBottom[1] = VerticeListToShow[2];

            //green (2)
            //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //cube.transform.position = CenterOfVectors(inwardValuesBottom);
            centerValues[2] = CenterOfVectors(inwardValuesBottom);
            //cube.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            //cube.GetComponent<Renderer>().material.color = Color.green;

            //yellow (3)
            //GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //cube2.transform.position = CenterOfVectors(outwardValuesBottom);
            centerValues[3] = CenterOfVectors(outwardValuesBottom);
            //cube2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            //cube2.GetComponent<Renderer>().material.color = Color.yellow;

            //getting angles
            Vector3 adjustedA1 = new Vector3(backOne.GetComponent<Cubescript>().centerValues[3].x, backOne.GetComponent<Cubescript>().centerValues[3].y, centerValues[2].z) - centerValues[2];
            Vector3 adjustedB1 = backOne.GetComponent<Cubescript>().centerValues[3] - centerValues[2];
            float angle1 = Vector3.Angle(adjustedA1, adjustedB1);

            Vector3 adjustedA2 = centerValues[0] - origin.GetComponent<Cubescript>().centerValues[1];
            Vector3 adjustedB2 = centerValues[2] - origin.GetComponent<Cubescript>().centerValues[1];
            float angle2 = Vector3.Angle(adjustedA2, adjustedB2);

            centerValuesAngle[0] = angle2 + 90;
            centerValuesAngle[1] = angle2 + 90;
            centerValuesAngle[2] = angle1 + 90;

            Destroy(plane1);
            Destroy(plane2);

            pleaseStop = true;
        }
    }

    private void LateUpdate()
    {
        if (pleaseStop2 && canStart[0].GetComponent<Cubescript>().pleaseStop && canStart[1].GetComponent<Cubescript>().pleaseStop && canStart[2].GetComponent<Cubescript>().pleaseStop && canStart[3].GetComponent<Cubescript>().pleaseStop)
        {
            Vector3 adjustedA1 = new Vector3(centerValues[3].x, origin.GetComponent<Cubescript>().centerValues[2].y, centerValues[3].z) - origin.GetComponent<Cubescript>().centerValues[2];
            Vector3 adjustedB1 = centerValues[3] - origin.GetComponent<Cubescript>().centerValues[2];
            float angle1 = Vector3.Angle(adjustedA1, adjustedB1);

            Vector3 adjustedA2 = new Vector3(centerValues[1].x, origin.GetComponent<Cubescript>().centerValues[2].y, centerValues[1].z) - origin.GetComponent<Cubescript>().centerValues[0];
            Vector3 adjustedB2 = centerValues[1] - origin.GetComponent<Cubescript>().centerValues[0];
            float angle2 = Vector3.Angle(adjustedA2, adjustedB2);

            Vector3 adjustedA3 = centerValues[3] - origin.GetComponent<Cubescript>().centerValues[0];
            Vector3 adjustedB3 = centerValues[1] - origin.GetComponent<Cubescript>().centerValues[0];
            float angle3 = Vector3.Angle(adjustedA3, adjustedB3);

            Vector3 adjustedA4 = centerValues[3] - origin.GetComponent<Cubescript>().centerValues[0];
            Vector3 adjustedB4 = centerValues[1] - origin.GetComponent<Cubescript>().centerValues[0];
            float angle4 = Vector3.Angle(adjustedA4, adjustedB4);

            Vector3 adjustedA5 = origin.GetComponent<Cubescript>().centerValues[0] - itSelf.GetComponent<Cubescript>().centerValues[1];
            Vector3 adjustedB5 = origin.GetComponent<Cubescript>().centerValues[2] - itSelf.GetComponent<Cubescript>().centerValues[1];
            float angle5 = Vector3.Angle(adjustedA5, adjustedB5);

            makeLine("Top " + itSelf.transform.name, 90, centerValues[0], 0, 0, new Vector3(0, 0.1f, 0), false, true, true);

            if (itSelf.transform.parent.localScale.y >= origin.transform.parent.localScale.y && itSelf.transform.parent.localScale.y >= backOne.transform.parent.localScale.y && !spawnOnce)
            {
                //print(itSelf + ": condition 1");
                makeLine("Diagonal " + itSelf.transform.name, 90, new Vector3(backOne.GetComponent<Cubescript>().centerValues[3].x, backOne.GetComponent<Cubescript>().centerValues[3].y, backOne.GetComponent<Cubescript>().centerValues[3].z), 180, 0, new Vector3(0, 0, 0), true, false, false);
                makeLine("Bottom " + itSelf.transform.name, angle1 + 90, centerValues[3], -90, 0, new Vector3(0, 0, 0), false, false, true);

                makeLine("Across1 " + itSelf.transform.name, angle2 + 90, new Vector3(centerValues[1].x, origin.GetComponent<Cubescript>().centerValues[2].y, centerValues[1].z), -90, 0, new Vector3(0, 0, 0), false, false, true);
                makeLine("Across2 " + itSelf.transform.name, angle2 + 90, origin.GetComponent<Cubescript>().centerValues[2], 90, 0, new Vector3(0, 0, 0), false, true, false);
                spawnOnce = true;
            }

            if (itSelf.transform.parent.localScale.y <= origin.transform.parent.localScale.y && itSelf.transform.parent.localScale.y <= backOne.transform.parent.localScale.y && !spawnOnce)
            {
                //print(itSelf + ": condition 2");
                makeLine("fuck you3" + itSelf.transform.name, 90, new Vector3(backOne.GetComponent<Cubescript>().centerValues[3].x, itSelf.GetComponent<Cubescript>().centerValues[3].y, backOne.GetComponent<Cubescript>().centerValues[3].z), 180, 0, new Vector3(0, 0, 0), true, false, false);
                makeLine("fuck you3" + itSelf.transform.name, angle1 + 90, centerValues[3], 90, 180, new Vector3(0, 0, 0), false, false, true);

                makeLine("sidebitch4" + itSelf.transform.name, angle3 + 90, centerValues[3], -90, 0, new Vector3(0, 0, 0), false, false, true);
                makeLine("sidebitch3" + itSelf.transform.name, angle3 + 90, new Vector3(origin.GetComponent<Cubescript>().centerValues[0].x, itSelf.GetComponent<Cubescript>().centerValues[2].y, origin.GetComponent<Cubescript>().centerValues[0].z), 90, 0, new Vector3(0, 0, 0), false, true, false);
                spawnOnce = true;
            }

            if (itSelf.transform.parent.localScale.y <= origin.transform.parent.localScale.y && itSelf.transform.parent.localScale.y >= backOne.transform.parent.localScale.y && !spawnOnce)
            {
                //print(itSelf + ": condition 3");
                makeLine("fuck you3" + itSelf.transform.name, 90, new Vector3(backOne.GetComponent<Cubescript>().centerValues[3].x, backOne.GetComponent<Cubescript>().centerValues[3].y, backOne.GetComponent<Cubescript>().centerValues[3].z), 180, 0, new Vector3(0, 0, 0), true, false, false);
                makeLine("fuck you3" + itSelf.transform.name, angle1 + 90, centerValues[3], 90, -180, new Vector3(0, 0, 0), false, false, true);

                makeLine("sidebitch5" + itSelf.transform.name, angle4 + 90, new Vector3(origin.GetComponent<Cubescript>().centerValues[2].x, itSelf.GetComponent<Cubescript>().centerValues[2].y, origin.GetComponent<Cubescript>().centerValues[2].z), 90, 0, new Vector3(0, 0, 0), false, true, false);
                makeLine("sidebitch6" + itSelf.transform.name, angle4 + 90, itSelf.GetComponent<Cubescript>().centerValues[3], -90, 0, new Vector3(0, 0, 0), false, false, true);

                spawnOnce = true;
            }

            if (itSelf.transform.parent.localScale.y >= origin.transform.parent.localScale.y && itSelf.transform.parent.localScale.y <= backOne.transform.parent.localScale.y && !spawnOnce)
            {
                //print(itSelf + ": condition 4");
                makeLine("fuck you3" + itSelf.transform.name, 90, new Vector3(backOne.GetComponent<Cubescript>().centerValues[3].x, itSelf.GetComponent<Cubescript>().centerValues[3].y, backOne.GetComponent<Cubescript>().centerValues[3].z), 180, 0, new Vector3(0, 0, 0), true, false, false);
                makeLine("fuck you3" + itSelf.transform.name, angle1 + 90, centerValues[3], -90, 0, new Vector3(0, 0, 0), false, false, true);

                makeLine("sidebitch7" + itSelf.transform.name, angle5 + 90, origin.GetComponent<Cubescript>().centerValues[2], 90, 0, new Vector3(0, 0, 0), false, true, false);
                makeLine("sidebitch8" + itSelf.transform.name, angle5 + 90, new Vector3(itSelf.GetComponent<Cubescript>().centerValues[1].x, origin.GetComponent<Cubescript>().centerValues[2].y, itSelf.GetComponent<Cubescript>().centerValues[1].z), -90, 0, new Vector3(0, 0, 0), true, false, true);
                spawnOnce = true;
            }

            pleaseStop2 = false;
            Destroy(gameObject.GetComponent<Rigidbody>());
            Destroy(itSelf.GetComponent<Rigidbody>());
        }
    }

    private void makeLine(string name, float rotation, Vector3 position, int offset1, int offset2, Vector3 positionOffset, bool ignore, bool ignore2, bool ignore3)
    {
        GameObject parentCube2 = new GameObject(name);
        parentCube2.transform.position = position;
        if (rotationNum == 0)
        {
            parentCube2.transform.position += new Vector3(-positionOffset.x, -positionOffset.y, positionOffset.z);
        }
        if (rotationNum == 90)
        {
            parentCube2.transform.position += new Vector3(positionOffset.x, -positionOffset.y, positionOffset.z);
        }
        if (rotationNum == 180)
        {
            parentCube2.transform.position += new Vector3(positionOffset.x, -positionOffset.y, positionOffset.z);
        }
        if (rotationNum == 270)
        {
            parentCube2.transform.position += new Vector3(positionOffset.x, -positionOffset.y, -positionOffset.z);
        }

        GameObject cube4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube4.transform.parent = parentCube2.transform;
        //cube4.transform.rotation = parentCube2.transform.rotation;
        cube4.transform.position = parentCube2.transform.position;
        cube4.transform.position += new Vector3(0, 0.5f, 0);
        parentCube2.transform.eulerAngles = new Vector3(
        parentCube2.transform.eulerAngles.x + rotation + 180,
        parentCube2.transform.eulerAngles.y + rotationNum + offset1 + initalObject.transform.eulerAngles.y,
        parentCube2.transform.eulerAngles.z + offset2);
        cube4.AddComponent<Rigidbody>();
        cube4.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ |
                                                     RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX |
                                                     RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;
        cube4.GetComponent<Rigidbody>().useGravity = false;
        cube4.AddComponent<Anglescript>();
        //cube4.GetComponent<Anglescript>().canStart = transform.parent.parent.parent.GetComponent<ShowCorners>().allCubes;
        cube4.GetComponent<Anglescript>().touching = rotationNum - 90;
        if (cube4.GetComponent<Anglescript>().touching == -90)
        {
            cube4.GetComponent<Anglescript>().touching = 270;
        }

        if (ignore)
        {
            cube4.GetComponent<Anglescript>().ignore = true;
        }
        else
        {
            cube4.GetComponent<Anglescript>().ignore = false;
        }

        if (ignore2)
        {
            cube4.GetComponent<Anglescript>().ignore2 = true;
        }
        else
        {
            cube4.GetComponent<Anglescript>().ignore2 = false;
        }

        if (ignore3)
        {
            cube4.GetComponent<Anglescript>().ignore3 = true;
        }
        else
        {
            cube4.GetComponent<Anglescript>().ignore3 = false;
        }

        parentCube2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        parentCube2.transform.parent = fullParent.transform;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Terrain")
        {
            stop = true;
            didFinish = true;
        }
    }

    public void SetCornerPoints(int num)
    {
        if (num == 1)
        {
            VerticeListToShow.Clear(); //incase of transform changes corner points are reset

            VerticeListToShow.Add(plane1.transform.TransformPoint(VerticeList[0])); //corner points are added to show  on the editor
            VerticeListToShow.Add(plane1.transform.TransformPoint(VerticeList[10]));
            VerticeListToShow.Add(plane1.transform.TransformPoint(VerticeList[110]));
            VerticeListToShow.Add(plane1.transform.TransformPoint(VerticeList[120]));
        }

        if (num == 2)
        {
            VerticeListToShow.Clear(); //incase of transform changes corner points are reset

            VerticeListToShow.Add(plane2.transform.TransformPoint(VerticeList[0])); //corner points are added to show  on the editor
            VerticeListToShow.Add(plane2.transform.TransformPoint(VerticeList[10]));
            VerticeListToShow.Add(plane2.transform.TransformPoint(VerticeList[110]));
            VerticeListToShow.Add(plane2.transform.TransformPoint(VerticeList[120]));
        }
    }

    public Vector3 CenterOfVectors(Vector3[] vectors)
    {
        Vector3 sum = Vector3.zero;
        if (vectors == null || vectors.Length == 0)
        {
            return sum;
        }

        foreach (Vector3 vec in vectors)
        {
            sum += vec;
        }
        return sum / vectors.Length;
    }
}
