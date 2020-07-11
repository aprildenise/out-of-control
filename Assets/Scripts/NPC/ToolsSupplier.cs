using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsSupplier : NPC
{
    public override void Interact()
    {
        Debug.Log("NPC Interaction:" + gameObject.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
