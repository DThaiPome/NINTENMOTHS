using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LearningStore : MonoBehaviour
{
    private static float DEFAULT_WEIGHT = 100;

    private Dictionary<string, float> learnedValues;

    private string lastActionKey;

    private void Awake()
    {
        learnedValues = new Dictionary<string, float>();
    }

    private void Start()
    {
        BroadcastMessage("GetLearningStoreGetter", new Func<LearningStore>(() => this));
    }

    public float GetLearnedWeight(string key)
    {
        if (learnedValues.TryGetValue(key, out float val))
        {
            return val;
        }
        return DEFAULT_WEIGHT;
    }

    public void ModifyLearnedWeight(string key, float deltaWeight)
    {
        if (learnedValues.TryGetValue(key, out float val))
        {
            val += deltaWeight;
            learnedValues.Remove(key);
            learnedValues.Add(key, val);
        }
        else
        {
            learnedValues.Add(key, DEFAULT_WEIGHT + deltaWeight);
        }
    }

    public string GetLastActionKey()
    {
        return lastActionKey;
    }

    public void SetLastActionKey(string key)
    {
        lastActionKey = key;
    }

    public void ModifyLastActionWeight(float deltaWeight)
    {
        if (lastActionKey != null)
        {
            ModifyLearnedWeight(lastActionKey, deltaWeight);
        }
    }
}
