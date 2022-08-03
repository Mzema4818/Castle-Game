using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeedGeneration : MonoBehaviour
{
    private MapGenerator mapGenerator;
    public GameObject terrain;
    public Material grassMaterial;
    public Transform newParent;
    public NoiseData noiseData;
    public GameObject trees;
    public GameObject rocks;
    public GameObject player;
    public GameObject forestGenerator;
    public GameObject cycle;
    public GameObject navBaker;

    public Vector3 newPos;
    public bool canMove;

    public GameObject grass;
    public Mesh grassMesh;
    public Mesh mesh;
    public Vector3[] vertices;

    void Awake()
    {
        canMove = false;
        mapGenerator = (MapGenerator)FindObjectOfType(typeof(MapGenerator));
    }

    public void generateSeed()
    {
        //Destroy(GameObject.Find("GrassTerrain"));

        noiseData.setSeed();

        //Destroy(terrain.GetComponent<MeshCollider>());
        mapGenerator.DrawMapInEditor();
        //terrain.AddComponent<MeshCollider>();
        updateVertices();

        //GameObject grass;
        //grass = Instantiate(terrain);
        //grass.GetComponent<Renderer>().material = grassMaterial;
        //Destroy(grass.GetComponent<MeshCollider>());
        //Destroy(grass.GetComponent<NavigationBaker>());
        //Destroy(grass.GetComponent<NavMeshSurface>());
        //grass.transform.position = terrain.transform.position;
        //grass.name = "GrassTerrain";
        //cycle.GetComponent<DayNightCycle>().grassObject = grass;
        //grass.transform.SetParent(newParent);

        foreach (Transform child in trees.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in rocks.transform)
        {
            Destroy(child.gameObject);
        }

        forestGenerator.GetComponent<ForestGenerator>().canTurnOnObjectSpawning();
        terrain.AddComponent<GetVertices>();
        //navBaker.GetComponent<NavigationBaker>().shouldUpdate = true;
    }

    public void generateSeed2()
    {
        //Destroy(GameObject.Find("GrassTerrain"));

        //Destroy(terrain.GetComponent<MeshCollider>());
        mapGenerator.DrawMapInEditor();
        updateVertices();
        //GameObject grass;
       // grass = Instantiate(terrain);
       //grass.GetComponent<Renderer>().material = grassMaterial;
        //Destroy(grass.GetComponent<MeshCollider>());
        //grass.transform.position = terrain.transform.position;
        //grass.name = "GrassTerrain";
        //cycle.GetComponent<DayNightCycle>().grassObject = grass;
        //grass.transform.SetParent(newParent);
        //Destroy(grass.GetComponent<MeshCollider>());
        //Destroy(grass.GetComponent<NavigationBaker>());
        //Destroy(grass.GetComponent<NavMeshSurface>());
        //navBaker.GetComponent<NavigationBaker>().shouldUpdate = true;
        //terrain.AddComponent<MeshCollider>();
    }

    public void destroyObjects()
    {
        foreach (Transform child in trees.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in rocks.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void updateVertices()
    {
        mesh = terrain.GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;

        MeshCollider mc = terrain.GetComponent<MeshCollider>();
        if (mc == null)
            mc = (MeshCollider)terrain.AddComponent(typeof(MeshCollider));
        else
        {
            mc.sharedMesh = null;
            mc.sharedMesh = mesh;
        }

        grass.GetComponent<MeshFilter>();
        grassMesh = grass.GetComponent<MeshFilter>().mesh;
        grassMesh.vertices = terrain.GetComponent<MeshFilter>().mesh.vertices;
        grassMesh.RecalculateBounds();
    }
}