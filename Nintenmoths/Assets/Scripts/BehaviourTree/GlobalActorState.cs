using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GlobalActorState : MonoBehaviour
{
    [SerializeField]
    private List<FloatVal> initialFloats;
    [SerializeField]
    private List<StringVal> initialStrings;

    private Dictionary<string, float> floatVals;
    private Dictionary<string, string> stringVals;

    [Serializable]
    private class FloatVal
    {
        public string key;
        public float value;
    }

    [Serializable]
    private class StringVal
    {
        public string key;
        public string value;
    }

    private void Awake()
    {
        floatVals = new Dictionary<string, float>();
        foreach (FloatVal floatVal in initialFloats)
        {
            floatVals.Add(floatVal.key, floatVal.value);
        }
        stringVals = new Dictionary<string, string>();
        foreach (StringVal stringVal in initialStrings)
        {
            stringVals.Add(stringVal.key, stringVal.value);
        }
    }

    void Start()
    {
        BroadcastMessage("GetGlobalActorStateGetter", new Func<GlobalActorState>(() => this));
    }

    public bool TryGetVal(string key, out float value)
    {
        return floatVals.TryGetValue(key, out value);
    }

    public void SetVal(string key, float value)
    {
        if (floatVals.ContainsKey(key))
        {
            floatVals.Remove(key);
        }
        floatVals.Add(key, value);
    }

    public bool TryGetVal(string key, out string value)
    {
        return stringVals.TryGetValue(key, out value);
    }

    public void SetVal(string key, string value)
    {
        if (stringVals.ContainsKey(key))
        {
            stringVals.Remove(key);
        }
        stringVals.Add(key, value);
    }
}
