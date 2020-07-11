using System.Collections;
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

    public GameObject InitPrefab(string prefabName, Vector3 position)
    {
        foreach (GameObject prefab in prefabs)
        {
            if (prefab.name.Equals(prefabName))
            {
                if (prefab.CompareTag("Plant"))
                {
                    GameManager.totalPlants++;
                }
                return Instantiate(prefab, position, prefab.transform.rotation, this.gameObject.transform);
            }
        }
        return null;
    }

    public GameObject InitPrefab(int prefabIndex, Vector3 position)
    {
        GameObject prefab = prefabs[prefabIndex];
        if (prefab == null) return null;
        if (prefab.CompareTag("Plant"))
        {
            GameManager.totalPlants++;
        }
        return Instantiate(prefab, position, prefab.transform.rotation, this.gameObject.transform);
    }

}
