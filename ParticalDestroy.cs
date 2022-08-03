using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalDestroy : MonoBehaviour
{
    private ParticleSystem ps;
    private ParticleSystem.MainModule main;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        main = ps.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (main.duration == ps.time)
        {
            Destroy(this);
        }
    }
}
