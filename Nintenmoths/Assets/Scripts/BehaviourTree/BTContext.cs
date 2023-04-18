using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTContext
{
    private Dictionary<string, string> stringMap;
    private Dictionary<string, int> intMap;
    private Dictionary<string, float> floatMap;
    private Dictionary<string, GameObject> gameObjectMap;

    public BTContext()
    {
        stringMap = new Dictionary<string, string>();
        intMap = new Dictionary<string, int>();
        floatMap = new Dictionary<string, float>();
        gameObjectMap = new Dictionary<string, GameObject>();
    }

    public bool TryGetVal(string key, out string value)
    {
        return stringMap.TryGetValue(key, out value);
    }

    public bool TryGetVal(string key, out int value)
    {
        return intMap.TryGetValue(key, out value);
    }

    public bool TryGetVal(string key, out float value)
    {
        return floatMap.TryGetValue(key, out value);
    }

    public bool TryGetVal(string key, out GameObject value)
    {
        return gameObjectMap.TryGetValue(key, out value);
    }

    public void SetVal(string key, string value)
    {
        if (stringMap.ContainsKey(key))
        {
            stringMap.Remove(key);
        }
        stringMap.Add(key, value);
    }

    public void SetVal(string key, int value)
    {
        if (intMap.ContainsKey(key))
        {
            intMap.Remove(key);
        }
        intMap.Add(key, value);
    }

    public void SetVal(string key, float value)
    {
        if (floatMap.ContainsKey(key))
        {
            floatMap.Remove(key);
        }
        floatMap.Add(key, value);
    }

    public void SetVal(string key, GameObject value)
    {
        if (gameObjectMap.ContainsKey(key))
        {
            gameObjectMap.Remove(key);
        }
        gameObjectMap.Add(key, value);
    }

    public bool TryReplaceVal(string key, string value)
    {
        if (stringMap.ContainsKey(key))
        {
            stringMap.Remove(key);
            stringMap.Add(key, value);
            return true;
        }
        return false;
    }

    public bool TryReplaceVal(string key, int value)
    {
        if (intMap.ContainsKey(key))
        {
            intMap.Remove(key);
            intMap.Add(key, value);
            return true;
        }
        return false;
    }

    public bool TryReplaceVal(string key, float value)
    {
        if (floatMap.ContainsKey(key))
        {
            floatMap.Remove(key);
            floatMap.Add(key, value);
            return true;
        }
        return false;
    }

    public bool TryReplaceVal(string key, GameObject value)
    {
        if (gameObjectMap.ContainsKey(key))
        {
            gameObjectMap.Remove(key);
            gameObjectMap.Add(key, value);
            return true;
        }
        return false;
    }
}
