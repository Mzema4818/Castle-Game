using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[ExecuteInEditMode]
public class GeometryGrassPainter : MonoBehaviour
{

    private Mesh mesh;
    MeshFilter filter;

    public Color AdjustedColor;
    public GameObject terrain;

    [Range(1, 600000)]
    public int grassLimit = 50000;

    private Vector3 lastPosition = Vector3.zero;

    public int toolbarInt = 0;

    [SerializeField]
    List<Vector3> positions = new List<Vector3>();
    [SerializeField]
    List<Color> colors = new List<Color>();
    [SerializeField]
    List<int> indicies = new List<int>();
    [SerializeField]
    List<Vector3> normals = new List<Vector3>();
    [SerializeField]
    List<Vector2> length = new List<Vector2>();

    public bool painting;
    public bool removing;
    public bool editing;

    public int i = 0;

    public float sizeWidth = 1f;
    public float sizeLength = 1f;
    public float density = 1f;


    public float normalLimit = 1;

    public float rangeR, rangeG, rangeB;
    public LayerMask hitMask = 1;
    public LayerMask paintMask = 1;
    public float brushSize;

    Vector3 mousePos;

    [HideInInspector]
    public Vector3 hitPosGizmo;

    Vector3 hitPos;

    [HideInInspector]
    public Vector3 hitNormal;

    int[] indi;

    public void ClearMesh()
    {
        i = 0;
        positions = new List<Vector3>();
        indicies = new List<int>();
        colors = new List<Color>();
        normals = new List<Vector3>();
        length = new List<Vector2>();
    }

    private void OnEnable()
    {
        filter = terrain.GetComponent<MeshFilter>();
    }

    void Start()
    {
        // place based on density


            // brushrange
            float t = 2f * Mathf.PI * Random.Range(0f, 1000);
            float u = Random.Range(0f, 1000) + Random.Range(0f, 1000);
            float r = (u > 1 ? 2 - u : u);
            Vector3 origin = Vector3.zero;

            // place random in radius, except for first one
     
                origin.x += r * Mathf.Cos(t);
                origin.y += r * Mathf.Sin(t);
            


   
                var grassPosition = hitPos;// + Vector3.Cross(origin, hitNormal);
                grassPosition -= this.transform.position;

                positions.Add((grassPosition));
                indicies.Add(i);
                length.Add(new Vector2(1000, 1000));
                // add random color variations                          
                colors.Add(new Color(AdjustedColor.r + (Random.Range(0, 1.0f) * rangeR), AdjustedColor.g + (Random.Range(0, 1.0f) * rangeG), AdjustedColor.b + (Random.Range(0, 1.0f) * rangeB), 1));

                //colors.Add(temp);
                i++;
            
        
        mesh = new Mesh();
        mesh.SetVertices(positions);
        indi = indicies.ToArray();
        mesh.SetIndices(indi, MeshTopology.Points, 0);
        mesh.SetUVs(0, length);
        mesh.SetColors(colors);
        mesh.SetNormals(normals);
        filter.mesh = mesh;
    }
}