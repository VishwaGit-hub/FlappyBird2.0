 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject prefabe;
    public float spawnRate = 1f;
    public float minheight = -1f;
    public float maxheight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn),spawnRate,spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes=Instantiate(prefabe,transform.position,Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minheight, maxheight);
    }
}
