using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GlobalActorState : MonoBehaviour
{
    [SerializeField]
    private List<FloatVal> initialFloats;

    private Dictionary<string, float> floatVals;

    [Serializable]
    private class FloatVal
    {
        public string key;
        public float value;
    }

    private void Awake()
    {
        floatVals = new Dictionary<string, float>();
        foreach (FloatVal floatVal in initialFloats)
        {
            floatVals.Add(floatVal.key, floatVal.value);
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
}
