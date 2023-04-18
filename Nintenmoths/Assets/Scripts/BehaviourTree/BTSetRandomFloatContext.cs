using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSetRandomFloatContext : ABTNode
{
    [SerializeField]
    private string contextKey;
    [SerializeField]
    private float min;
    [SerializeField]
    private float max;

    protected override void OnInitialize()
    {

    }

    protected override void OnTerminate(BTResult result)
    {

    }

    protected override BTResult OnTick()
    {
        float val = Random.Range(min, max);
        TryReplaceUpperContextVal(contextKey, val);
        return BTResult.SUCCESS;
    }
}
