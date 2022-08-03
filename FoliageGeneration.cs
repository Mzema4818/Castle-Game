using UnityEngine;
using System.Collections;

public class FoliageGeneration : MonoBehaviour
{
    public Material grassMaterial;
    public Material dirtMaterial;

    public GameObject[] grassObject;
    public GameObject[] flowerObject;
    public GameObject[] treeObject;

    public bool spawnOnDirt = false;

    [Range(0, 100)]
    public double grassChance;
    [Range(0, 100)]
    public double flowerChance;
    [Range(0, 100)]
    public double treeChance;
    [Range(0, 100)]
    public double blankChance;

    double totalChance;

    Mesh cell;
    int[] triangleIndex;
    Vector3[] verticeIndex;

    RaycastHit hit;

    void Start()
    {
        cell = gameObject.GetComponent<MeshFilter>().mesh;

        triangleIndex = cell.triangles;
        verticeIndex = cell.vertices;

        for (int i = 0; i >= triangleIndex.Length; i++)
        {
            Vector3 a = verticeIndex[triangleIndex[hit.triangleIndex + 0]];
            Vector3 b = verticeIndex[triangleIndex[hit.triangleIndex + 1]];
            Vector3 c = verticeIndex[triangleIndex[hit.triangleIndex + 2]];

            Vector3 target = a + b + c / 3;
            target.z += 1;

            Ray ray = new Ray(target, target);

            Material targetMaterial = hit.collider.GetComponent<Material>();

            if (targetMaterial == grassMaterial)
            {
                CalculateChances();
            }
            else if (spawnOnDirt == true)
            {
                if (targetMaterial == dirtMaterial)
                {
                    CalculateChances();
                }
            }
        }
    }

    public void CalculateChances()
    {
        totalChance = grassChance + flowerChance + treeChance;
        totalChance /= 300;
        totalChance /= 3;

        var spawnChance = Random.Range(0, 100);
        if (spawnChance < blankChance)
        {
            spawnChance = Random.Range(0, 300);
            if (spawnChance >= totalChance)
            {
                SpawnGrass();
            }
            if (spawnChance < totalChance && spawnChance >= (totalChance * 2))
            {
                SpawnFlowers();
            }
            if (spawnChance < (totalChance * 2) && spawnChance >= (totalChance * 3))
            {
                SpawnTrees();
            }
        }
    }

    public void SpawnGrass()
    {
        var objectToSpawn = Random.Range(0, grassObject.Length);

        GameObject grass = GameObject.Instantiate(grassObject[objectToSpawn]);
        grass.transform.parent = transform;
        grass.name = grassObject[objectToSpawn].name;
    }

    public void SpawnFlowers()
    {
        var objectToSpawn = Random.Range(0, flowerObject.Length);

        GameObject flower = GameObject.Instantiate(flowerObject[objectToSpawn]);
        flower.transform.parent = transform;
        flower.name = flowerObject[objectToSpawn].name;
    }

    public void SpawnTrees()
    {
        var objectToSpawn = Random.Range(0, treeObject.Length);

        GameObject tree = GameObject.Instantiate(treeObject[objectToSpawn]);
        tree.transform.parent = transform;
        tree.name = treeObject[objectToSpawn].name;
    }
}
