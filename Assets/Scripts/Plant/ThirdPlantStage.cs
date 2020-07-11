using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ThirdPlantStage : SpawningStage
{
    public float aggroRadius;
    public float attackCooldown;

    private Timer attackCooldownTimer;


    protected override void OnStart()
    {
        attackCooldownTimer = gameObject.AddComponent<Timer>();
        attackCooldownTimer.SetTimer(attackCooldown);
        attackCooldownTimer.StartTimer();
    }

    protected void Update()
    {
        if (attackCooldownTimer.GetStatus() == Timer.Status.FINISHED)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, aggroRadius);
            foreach (Collider hit in hits)
            {
                if (hit.gameObject.CompareTag("Player"))
                {
                    Attack();
                }
            }
        }
    }

    protected abstract void Attack();

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, aggroRadius);
    }

}
