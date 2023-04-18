using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSetFloatValue : ABTNode
{
    [SerializeField]
    private string contextKey;
    [SerializeField]
    private float value;

    protected override void OnInitialize()
    {
    }

    protected override void OnTerminate(BTResult result)
    {
    }

    protected override BTResult OnTick()
    {
        TryReplaceUpperContextVal(contextKey, value);
        return BTResult.SUCCESS;
    }
}
