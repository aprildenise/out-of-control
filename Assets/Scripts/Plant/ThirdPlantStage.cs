using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ThirdPlantStage : SpawningStage
{
    public float aggroRadius;



    private void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, aggroRadius);
        foreach(Collider hit in hits)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                Attack();
            }
        }
    }

    protected abstract void Attack();

}
