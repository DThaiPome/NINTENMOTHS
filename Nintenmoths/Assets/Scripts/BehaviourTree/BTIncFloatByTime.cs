using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTIncFloatByTime : ABTNode
{
    [SerializeField]
    private string contextKey;

    private float secondsSinceLastUpdate = 0;

    private void Update()
    {
        secondsSinceLastUpdate += Time.deltaTime;
    }

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
            value += secondsSinceLastUpdate;
            secondsSinceLastUpdate = 0;
            TryReplaceUpperContextVal(contextKey, value);
        }
        return BTResult.SUCCESS;
    }
}
