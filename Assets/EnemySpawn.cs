using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform EnemyPos;
    private float repeatRate = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnterEnter ( Collider other)
    {
        InvokeRepeating("EnemySpawner", 0.5f, repeatRate);
        Destroy(gameObject, 11);
        gameObject.GetComponent<BoxCollider>().enabled = false;

    }

    void EnemySpawner()
    {
        Instantiate(enemyPrefab, EnemyPos.position, EnemyPos.rotation);
    }

    void OnDrawGizmos()
    {
     Gizmos.color = Color.red;

        foreach (Collider col in GetComponents<Collider>())
        {
            Gizmos.matrix = col.transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }

    }
}
