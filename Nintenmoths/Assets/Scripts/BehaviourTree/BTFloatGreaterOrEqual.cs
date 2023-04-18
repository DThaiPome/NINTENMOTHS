using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTFloatGreaterOrEqual : ABTNode
{
    [SerializeField]
    private string contextKey;
    [SerializeField]
    private float value = 10;

    protected override void OnInitialize()
    {
    }

    protected override void OnTerminate(BTResult result)
    {
    }

    protected override BTResult OnTick()
    {
        if (TryFindUpperContextVal(contextKey, out float val))
        {
            return val >= value ? BTResult.SUCCESS : BTResult.FAILURE;
        }
        return BTResult.FAILURE;
    }
}
