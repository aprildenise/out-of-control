using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawningStage : PlantStage
{


    public float spawnRadius;
    public float timeToFruit;
    public float timeToPropagate;
    public int mutateChance;
    private Timer spawnFruitTimer;
    private Timer propagateTimer;

    protected void Start()
    {
        spawnFruitTimer = gameObject.AddComponent<Timer>();
        propagateTimer = gameObject.AddComponent<Timer>();
        spawnFruitTimer.SetTimer(timeToFruit);
        propagateTimer.SetTimer(timeToPropagate);
        spawnFruitTimer.StartTimer();
        propagateTimer.StartTimer();
    }

    protected void LateUpdate()
    {
        if (spawnFruitTimer.GetStatus() == Timer.Status.FINISHED)
        {
            SpawnFruit();
        }

        if (propagateTimer.GetStatus() == Timer.Status.FINISHED)
        {
            Propogate();
        }
    }

    private void SpawnFruit()
    {
        Debug.Log(stageController.parentPlant.gameObject.name + ":Spawn fruit");
        spawnFruitTimer.ResetTimer();
        spawnFruitTimer.StartTimer();
        PrefabManager.instance.InitPrefab("Test Fruit", this.transform.position);
    }

    private void Propogate()
    { 
        int random = Random.Range(0, 100);
        if (random < mutateChance)
        {
            Debug.Log(stageController.parentPlant.gameObject.name + ": Propogating new type");
        }
        else
        {
            Debug.Log(stageController.parentPlant.gameObject.name + ": Propogating same type");
        }
        propagateTimer.ResetTimer();
        propagateTimer.StartTimer();
        PrefabManager.instance.InitPrefab("Test Plant", this.transform.position);
    }
}
