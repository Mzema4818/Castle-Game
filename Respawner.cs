using UnityEngine;
using System.Collections;

public class Respawner : MonoBehaviour
{
    public GameObject respawn;

    void Start()
    {
        StartCoroutine(ExampleCoroutine());

    }

    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            if (respawn.activeSelf == false)
            {
                yield return new WaitForSeconds(5);
                respawn.SetActive(true);
                respawn.SendMessage("Respawned");

            }
            yield return null;
        }
    }
}