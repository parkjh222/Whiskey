using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabToSpawn;
    [SerializeField]
    private float spawnInterval = 2.0f;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0.0f;
        }
    }

    private void SpawnObject()
    {
        GameObject newObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
}
