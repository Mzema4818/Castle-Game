using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anglescript : MonoBehaviour
{
    private bool stop;
    public int touching;
    private int rotationNum;
    private int rotationNum2;
    private int rotationNum3;
    public bool ignore;
    public bool ignore2;
    public bool ignore3;

    // Start is called before the first frame update
    void Start()
    {
        rotationNum = touching - 90;

        if (rotationNum == -90)
        {
            rotationNum = 270;
        }

        rotationNum2 = touching + 180;

        if (rotationNum2 == 360)
        {
            rotationNum2 = 0;
        }
        if (rotationNum2 == 450)
        {
            rotationNum2 = 90;
        }

        rotationNum3 = touching + 90;

        if (rotationNum3 == 360)
        {
            rotationNum3 = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            gameObject.transform.parent.localScale += new Vector3(0, 0.05f, 0);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Legs" + touching) && !ignore || col.gameObject.name.Contains("Legs" + rotationNum) || col.gameObject.name.Contains("Legs" + rotationNum2) && !ignore2 || col.gameObject.name.Contains("Legs" + rotationNum3) && !ignore3)
        {
            stop = true;
            Destroy(gameObject.GetComponent<Rigidbody>());
        }
    }
}
