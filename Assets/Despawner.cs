using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("trigger enter: " + col.name);

        if (col.CompareTag("Cube"))
            Destroy(col.gameObject);
    }
}
