using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject bugPrefab;
    public float distance = 25f;
    public int count = 0;

    void Start()
    {
        StartCoroutine(SpawnBug());
    }

    IEnumerator SpawnBug()
    {
        if (count < 20)
        {
            Vector3 pos = Random.onUnitSphere * distance;
            Instantiate(bugPrefab, pos, Quaternion.identity);
            count += 1;
        }
        yield return new WaitForSeconds(1f);

        StartCoroutine(SpawnBug());
       
    }
}
