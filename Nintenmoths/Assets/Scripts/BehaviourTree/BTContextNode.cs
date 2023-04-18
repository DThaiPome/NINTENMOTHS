using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BTContextNode : ABTNode
{
    [SerializeField]
    private List<FloatVal> floatVals;
    [SerializeField]
    private List<StringVal> stringVals;

    [Serializable]
    private class FloatVal
    {
        public string key;
        public float val;
    }

    [Serializable]
    private class StringVal
    {
        public string key;
        public string val;
    }

    private ABTNode child;

    protected override void OnAwake()
    {
        foreach (FloatVal floatVal in floatVals)
        {
            ourContext.SetVal(floatVal.key, floatVal.val);
        }
        foreach (StringVal stringVal in stringVals)
        {
            ourContext.SetVal(stringVal.key, stringVal.val);
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
