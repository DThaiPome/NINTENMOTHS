using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTIncFloatByTime : ABTNode
{
    [SerializeField]
    private string contextKey;

    protected override void OnInitialize()
    {
    }

    protected override void OnTerminate(BTResult result)
    {
    }

    protected override BTResult OnTick()
    {
        if (TryFindUpperContextVal(contextKey, out float value))
        {
            value += Time.deltaTime;
            TryReplaceUpperContextVal(contextKey, value);
        }
        return BTResult.SUCCESS;
    }
}
