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

    private List<StringVal> preInitStringVals;

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

    public void AddPreInitStringVal(string key, string val)
    {
        if (preInitStringVals == null)
        {
            preInitStringVals = new List<StringVal>();
        }
        StringVal stringVal = new StringVal();
        stringVal.key = key;
        stringVal.val = val;
        preInitStringVals.Add(stringVal);
    }

    protected override void OnAwake()
    {
        foreach (FloatVal floatVal in floatVals)
        {
            ourContext.SetVal(floatVal.key, floatVal.val);
        }
        if (preInitStringVals != null)
        {
            stringVals.AddRange(preInitStringVals);
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
