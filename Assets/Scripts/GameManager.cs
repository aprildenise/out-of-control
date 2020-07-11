using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float points;
    public static int totalPlants = 1;

    public static GameManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;

    }

    private void Update()
    {

        if (totalPlants <= 0)
        {
            // TODO: Gameover??
            Debug.Log("No more plants :(");
        }

        points += Time.unscaledDeltaTime;
    }

}
