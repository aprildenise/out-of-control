﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float points;

    private void Update()
    {
        points += Time.unscaledDeltaTime;
    }

}