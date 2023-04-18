using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BTContextNode : ABTNode
{
    [SerializeField]
    private List<FloatVal> floatVals;

    [Serializable]
    private class FloatVal
    {
        public string key;
        public float val;
    }

    private ABTNode child;

    protected override void OnAwake()
    {
        foreach (FloatVal floatVal in floatVals)
        {
            ourContext.SetVal(floatVal.key, floatVal.val);
        }
        child = Util.GetComponentInChildrenNonRecursive<ABTNode>(this);
        child.SetParent(this);
    }

    protected override void OnInitialize()
    {
    }

    protected override void OnTerminate(BTResult result)
    {
        child.Terminate();
    }

    protected override BTResult OnTick()
    {
        return child.UpdateNode();
    }
}
