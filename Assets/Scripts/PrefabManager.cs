﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{

    public List<GameObject> prefabs;

    public static PrefabManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public void InitPrefab(string prefabName, Vector3 position)
    {
        foreach (GameObject prefab in prefabs)
        {
            if (prefab.name.Equals(prefabName))
            {
                Instantiate(prefab, position, prefab.transform.rotation, this.gameObject.transform);
            }
        }
    }

}