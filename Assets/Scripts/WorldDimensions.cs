using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldDimensions : MonoBehaviour
{
    [SerializeField] public Transform[] corners;

    public static WorldDimensions instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;

    }

    public Vector3 GetRandomWorldPoint()
    {
        float x = Random.Range(corners[0].position.x, corners[1].position.x);
        float z = Random.Range(corners[0].position.z, corners[3].position.z);

        return new Vector3(x, 0, z);
    }

    public bool IsWithinWorldDimensions(Vector3 position)
    {
        return (corners[0].position.x < position.x
            && position.x < corners[1].position.x
            && corners[0].position.z < position.z
            && position.z < corners[3].position.z); 
    }
}
