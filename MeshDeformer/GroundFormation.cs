using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFormation : MonoBehaviour
{
    public Vector3 point;
    public Mesh mesh;
    public Vector3[] vertices;
    public Color[] colors;
    public GameObject terrain;

    public Vector3[] corners;
    private BoxCollider b;
    public float offset;

    public bool moveDownwards;

    public List<int> verticesChanged = new List<int>();
    public Vector3[] originalVertices;
    public Vector3[] newChangedVertices;

    public GameObject grass;
    public Mesh grassMesh;
    public Vector3[] grassVertices;

    public GameObject whereVerticesIsSaved;

    public bool test;

    void Awake()
    {
        terrain = GameObject.Find("Terrain");
        grass = GameObject.Find("GrassTerrain");
        whereVerticesIsSaved = GameObject.Find("Actual Buidlings");

        getPoint();
        corners = new Vector3[4];
        colors = new Color[4];

        mesh = terrain.GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        originalVertices = whereVerticesIsSaved.GetComponent<GetData>().originalVertices;

        grassMesh = grass.GetComponent<MeshFilter>().mesh;
        grassVertices = mesh.vertices;

        b = transform.GetComponent<BoxCollider>(); //retrieves the Box Collider of the GameObject called obj

        getCorners();

        colors[0] = Color.red;
        colors[1] = Color.yellow;
        colors[2] = Color.green;
        colors[3] = Color.blue;

        offset = -(vertices[0].x - vertices[1].x) * 2;
        moveDownwards = true;
    }
    void Start()
    {
        terrain = GameObject.Find("Terrain");
        grass = GameObject.Find("GrassTerrain");

        getPoint();
        corners = new Vector3[4];
        colors = new Color[4];

        mesh = terrain.GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        originalVertices = whereVerticesIsSaved.GetComponent<GetData>().originalVertices;

        grassMesh = grass.GetComponent<MeshFilter>().mesh;
        grassVertices = mesh.vertices;

        b = transform.GetComponent<BoxCollider>(); //retrieves the Box Collider of the GameObject called obj

        colors[0] = Color.red;
        colors[1] = Color.yellow;
        colors[2] = Color.green;
        colors[3] = Color.blue;

        getCorners();

        offset = -(vertices[0].x - vertices[1].x) * 2;
        moveDownwards = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            changeVertices(false);
            test = false;
        }

        if (moveDownwards)
        {
            if (!getDistance())
            {
                transform.Translate(Vector3.down * Time.deltaTime * 5);
            }
        }
    }

    public void getPoint()
    {
        Vector3 direction;
        direction = Vector3.down;

        Vector3 forward = transform.TransformDirection(direction) * 10;
        Ray inputRay1 = new Ray(corners[0], forward);
        Ray inputRay2 = new Ray(corners[1], forward);
        Ray inputRay3 = new Ray(corners[2], forward);
        Ray inputRay4 = new Ray(corners[3], forward);
        RaycastHit hit;

        Vector3[] points = new Vector3[4];


        if (Physics.Raycast(inputRay1, out hit))
        {
            Debug.DrawRay(corners[0], transform.TransformDirection(direction) * hit.distance, Color.red);
            points[0] = hit.point;
        }

        if (Physics.Raycast(inputRay2, out hit))
        {
            Debug.DrawRay(corners[1], transform.TransformDirection(direction) * hit.distance, Color.red);
            points[1] = hit.point;
        }

        if (Physics.Raycast(inputRay3, out hit))
        {
            Debug.DrawRay(corners[2], transform.TransformDirection(direction) * hit.distance, Color.red);
            points[2] = hit.point;
        }

        if (Physics.Raycast(inputRay4, out hit))
        {
            Debug.DrawRay(corners[3], transform.TransformDirection(direction) * hit.distance, Color.red);
            points[3] = hit.point;
        }

        Vector3 minVector = Vector3.positiveInfinity;
        for (int i = 0; i < points.Length; i++)
        {
            minVector = (points[i].magnitude < minVector.magnitude) ? points[i] : minVector;
        }

        point = minVector;
    }

    public bool getDistance()
    {
        Vector3 direction;
        direction = Vector3.down;
        bool dist = false;

        Vector3 forward = transform.TransformDirection(direction) * 10;
        Ray inputRay = new Ray(transform.position, forward);
        RaycastHit hit;

        if (Physics.Raycast(inputRay, out hit))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(direction) * hit.distance, Color.red);

            if (hit.distance < 0.5f)
            {
                dist = true;
                moveDownwards = false;
            }
        }

        return dist;

    }

    void OnDrawGizmos()
    {
        mesh = terrain.GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        // Draw a yellow sphere at the transform's position
        for (int i = 0; i < corners.Length; i++)
        {
            Gizmos.color = colors[i];
            Gizmos.DrawSphere(corners[i], 0.1f);
        }

        /*foreach (Vector3 vertex in vertices)
        {
            Gizmos.color = Color.red;
            Vector3 worldPos = terrain.transform.TransformPoint(vertex);
            Gizmos.DrawCube(worldPos, Vector3.one * 1f);
        }*/

        for (int i = 0; i < verticesChanged.Count; i++)
        {
            Gizmos.color = Color.blue;
            Vector3 worldPos = terrain.transform.TransformPoint(vertices[verticesChanged[i]]);
            Gizmos.DrawCube(worldPos, Vector3.one * 1f);
        }
    }

    void getCorners()
    {
        corners[0] = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f);
        corners[1] = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f);
        corners[2] = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f);
        corners[3] = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f);
    }

    void updateCollider()
    {
        MeshCollider mc = terrain.GetComponent<MeshCollider>();
        if (mc == null)
            mc = (MeshCollider)terrain.AddComponent(typeof(MeshCollider));
        else
        {
            mc.sharedMesh = null;
            mc.sharedMesh = mesh;
        }
    }

    public void updateVertices(Vector3[] newVertices)
    {
        mesh.vertices = newVertices;
        mesh.RecalculateBounds();

        grassMesh.vertices = newVertices;
        grassMesh.RecalculateBounds();

        updateCollider();
    }

    public void revertVertices()
    {
        newChangedVertices = mesh.vertices;

        for (var i = 0; i < verticesChanged.Count; i++)
        {
            newChangedVertices[verticesChanged[i]] = originalVertices[verticesChanged[i]];
        }

        updateVertices(newChangedVertices);
    }

    public void changeVertices(bool changeHeight)
    {
        moveDownwards = true;
        getPoint();
        mesh = terrain.GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        getCorners();
        verticesChanged.Clear();

        float y = (corners[0].y - terrain.transform.position.y) * transform.localScale.y;
        for (var i = 0; i < vertices.Length; i++)
        {
            float positionX = terrain.transform.TransformPoint(vertices[i]).x;
            float positionZ = terrain.transform.TransformPoint(vertices[i]).z;

            //positionX + offset >= corners[0].x && positionX - offset <= corners[2].x
            //positionZ + offset >= corners[0].z && positionZ - offset <= corners[2].z
            bool leftRight = positionX + offset >= corners[0].x && positionX - offset <= corners[2].x;
            bool upDown = positionZ + offset >= corners[0].z && positionZ - offset <= corners[2].z;

            if (leftRight && upDown)
            {
                vertices[i].y = point.y * transform.localScale.y;
                verticesChanged.Add(i);
            }

            //transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }

        //transform.position = new Vector3(transform.position.x, y, transform.position.z);

        updateVertices(vertices);
    }
    public void changeVerticesWithOutPoint()
    {
        moveDownwards = true;
        mesh = terrain.GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        getCorners();
        verticesChanged.Clear();

        float y = (corners[0].y - terrain.transform.position.y) * transform.localScale.y;
        for (var i = 0; i < vertices.Length; i++)
        {
            float positionX = terrain.transform.TransformPoint(vertices[i]).x;
            float positionZ = terrain.transform.TransformPoint(vertices[i]).z;

            //positionX + offset >= corners[0].x && positionX - offset <= corners[2].x
            //positionZ + offset >= corners[0].z && positionZ - offset <= corners[2].z
            bool leftRight = positionX + offset >= corners[0].x && positionX - offset <= corners[2].x;
            bool upDown = positionZ + offset >= corners[0].z && positionZ - offset <= corners[2].z;

            if (leftRight && upDown)
            {
                vertices[i].y = point.y * transform.localScale.y;
                verticesChanged.Add(i);
            }

            //transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }

        //transform.position = new Vector3(transform.position.x, y, transform.position.z);

        updateVertices(vertices);
    }

    public void changeVertices(bool changeHeight, Vector3 autoPoint)
    {
        print("2");
        point = autoPoint;
        mesh = terrain.GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        getCorners();
        vertices = mesh.vertices;
        verticesChanged.Clear();

        float y = (corners[0].y - terrain.transform.position.y) * transform.localScale.y;
        for (var i = 0; i < vertices.Length; i++)
        {
            float positionX = terrain.transform.TransformPoint(vertices[i]).x;
            float positionZ = terrain.transform.TransformPoint(vertices[i]).z;

            //positionX + offset >= corners[0].x && positionX - offset <= corners[2].x
            //positionZ + offset >= corners[0].z && positionZ - offset <= corners[2].z
            bool leftRight = positionX + offset >= corners[0].x && positionX - offset <= corners[2].x;
            bool upDown = positionZ + offset >= corners[0].z && positionZ - offset <= corners[2].z;

            if (leftRight && upDown)
            {
                if (changeHeight)
                {
                    vertices[i].y = y - 2;
                }
                else
                {
                    vertices[i].y = y;
                }
                verticesChanged.Add(i);
            }
        }

        //transform.position = new Vector3(transform.position.x, y, transform.position.z);

        updateVertices(vertices);
    }

    public float lowest(float[] m_Distance)
    {
        var min = Mathf.Infinity;

        for (int i = 0; i < m_Distance.Length; i++)
        {
            if (m_Distance[i] < min)
                min = m_Distance[i];
        }

        return min;
    }
}
