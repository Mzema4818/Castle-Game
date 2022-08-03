using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBakerObjects : MonoBehaviour
{
    public NavMeshSurface[] surfaces;
    public Transform[] objectsToRotate;
    public bool shouldUpdate;

    private void Start()
    {
        surfaces = new NavMeshSurface[1];
        surfaces[0] = gameObject.GetComponent<NavMeshSurface>();
    }

    // Use this for initialization
    private void Update()
    {
        if (shouldUpdate)
        {
            for (int i = 0; i < surfaces.Length; i++)
            {
                surfaces[i].BuildNavMesh();
            }
        }
    }

}
