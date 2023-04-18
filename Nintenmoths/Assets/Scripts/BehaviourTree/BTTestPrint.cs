using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTTestPrint : ABTNode
{
    [SerializeField]
    private string message;

    protected override void OnInitialize()
    {
    }

    protected override void OnTerminate(BTResult result)
    {
    }

    protected override BTResult OnTick()
    {
        Debug.Log(message);
        return BTResult.SUCCESS;
    }
}
