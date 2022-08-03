using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public int numberOfHits = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfHits == 3)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    void HitByRay()
    {
        numberOfHits += 1;
    }

    void Respawned()
    {
        numberOfHits = 0;
    }
}
