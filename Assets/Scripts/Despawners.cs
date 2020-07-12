using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawners : MonoBehaviour
{


    private void OnColliderEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("NPC")) return;
        Destroy(other.gameObject);
    }
}
