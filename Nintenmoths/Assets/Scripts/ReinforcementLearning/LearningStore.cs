using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LearningStore : MonoBehaviour
{
    private static float DEFAULT_WEIGHT = 100;

    private Dictionary<string, float> learnedValues;

    [SerializeField]
    private float actionKeyCacheSize = 3;

    private Queue<string> lastActionKeys;

    private void Awake()
    {
        learnedValues = new Dictionary<string, float>();
        lastActionKeys = new Queue<string>();
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
        if (lastActionKeys.Count > 0)
        {
            return lastActionKeys.Peek();
        }
        return null;
    }

    public void SetLastActionKey(string key)
    {
        while (lastActionKeys.Count >= actionKeyCacheSize)
        {
            lastActionKeys.Dequeue();
        }
        lastActionKeys.Enqueue(key);
    }

    public void ModifyLastActionWeight(float deltaWeight)
    {
        if (lastActionKeys.Count > 0)
        {
            int i = 0;
            foreach (string key in lastActionKeys)
            {
                float adjustedDeltaWeight = deltaWeight * Mathf.Pow(.5f, lastActionKeys.Count - 1 - i);
                ModifyLearnedWeight(key, adjustedDeltaWeight);
                i++;
            }
        }
    }
}
