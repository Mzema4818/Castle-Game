using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateVertices : MonoBehaviour
{
    Mesh mesh;
    public Vector3[] vertices;
    private MeshCollider meshCollider;
    public GameObject grass;

    public void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        meshCollider = GetComponent<MeshCollider>();
        grass = GameObject.Find("GrassTerrain");

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        updateCollider();

        Destroy(transform.GetComponent<updateVertices>());
    }

    void updateCollider()
    {
        Destroy(meshCollider);
        meshCollider = GetComponent<MeshCollider>();
        gameObject.AddComponent<MeshCollider>();
    }
}
