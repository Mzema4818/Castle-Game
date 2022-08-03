using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour
{

    public NavMeshSurface[] surfaces;
    public Transform[] objectsToRotate;
    public bool shouldUpdate;

    private void Awake()
    {
        shouldUpdate = false;
    }

    // Use this for initialization
    void Update()
    {
        /*
        for (int j = 0; j < objectsToRotate.Length; j++)
        {
            objectsToRotate[j].localRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
        }*/

        if (shouldUpdate)
        {
            for (int i = 0; i < surfaces.Length; i++)
            {
                surfaces[i].BuildNavMesh();
            }
            shouldUpdate = false;
        }
    }

}