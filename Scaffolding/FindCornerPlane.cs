using System.Collections.Generic;
using UnityEngine;

public class FindCornerPlane : MonoBehaviour
{

    public List<Vector3> VerticeList = new List<Vector3>(); //List of global vertices on the plane
    public List<Vector3> VerticeListToShow = new List<Vector3>();
    public int sphereSize = 1;

    List<Color> CornerColors = new List<Color>() { Color.red, Color.blue, Color.yellow, Color.green }; //Different colors for different corners



    // Start is called before the first frame update
    void Start()
    {
        VerticeList = new List<Vector3>(GetComponent<MeshFilter>().sharedMesh.vertices); //get vertice points from the mesh of the object

        SetCornerPoints();
    }

    void Update()
    {
        SetCornerPoints();
    }

    public void SetCornerPoints()
    {
        VerticeListToShow.Clear(); //incase of transform changes corner points are reset

        VerticeListToShow.Add(transform.TransformPoint(VerticeList[0])); //corner points are added to show  on the editor
        VerticeListToShow.Add(transform.TransformPoint(VerticeList[10]));
        VerticeListToShow.Add(transform.TransformPoint(VerticeList[110]));
        VerticeListToShow.Add(transform.TransformPoint(VerticeList[120]));
    }

}