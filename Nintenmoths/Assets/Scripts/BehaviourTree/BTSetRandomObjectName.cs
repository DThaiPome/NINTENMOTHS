using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSetRandomObjectName : ABTNode
{
    [SerializeField]
    private string contextKey;
    [SerializeField]
    private string tagToSearchFor;

    protected override void OnInitialize()
    {
    }

    protected override void OnTerminate(BTResult result)
    {
    }

    protected override BTResult OnTick()
    {
        GameObject[] destObjects = GameObject.FindGameObjectsWithTag(tagToSearchFor);
        if (destObjects.Length > 0)
        {
            int rand = Random.Range(0, destObjects.Length);
            string name = destObjects[rand].name;
            TryReplaceUpperContextVal(contextKey, name);
            return BTResult.SUCCESS;
        }
        return BTResult.FAILURE;
    }
}
