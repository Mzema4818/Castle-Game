using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetVertices : MonoBehaviour
{
    Mesh mesh;
    public Vector3[] theOriginalVertices;
    // Start is called before the first frame update

    private void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        theOriginalVertices = mesh.vertices;

    }

    public Vector3[] getVertices()
    {
        return theOriginalVertices;
    }
}
