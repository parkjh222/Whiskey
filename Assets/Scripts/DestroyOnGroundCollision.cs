using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnGroundCollision : MonoBehaviour
{
    private float destroyTimer = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Invoke("DestroyObject", destroyTimer);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
