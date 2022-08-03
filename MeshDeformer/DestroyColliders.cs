using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyColliders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshCollider[] colliders = FindObjectsOfType<MeshCollider>();
        int len = colliders.Length;
        for (int i = 0; i < len; i++) GameObject.Destroy(colliders[i]);

        Destroy(transform.GetComponent<DestroyColliders>());
    }
}
