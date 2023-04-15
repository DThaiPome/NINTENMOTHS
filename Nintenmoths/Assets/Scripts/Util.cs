using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static T[] GetComponentsInChildrenNonRecursive<T>(GameObject obj) where T : MonoBehaviour
    {
        return _GetComponentsInChildrenNonRecursive<T>(obj);
    }

    public static T[] GetComponentsInChildrenNonRecursive<T>(MonoBehaviour behaviour) where T : MonoBehaviour
    {
        return _GetComponentsInChildrenNonRecursive<T>(behaviour.gameObject);
    }

    public static T GetComponentInChildrenNonRecursive<T>(GameObject obj) where T : MonoBehaviour
    {
        return _GetComponentInChildrenNonRecursive<T>(obj);
    }

    public static T GetComponentInChildrenNonRecursive<T>(MonoBehaviour behaviour) where T : MonoBehaviour
    {
        return _GetComponentInChildrenNonRecursive<T>(behaviour.gameObject);
    }

    private static T _GetComponentInChildrenNonRecursive<T>(GameObject obj) where T : MonoBehaviour
    {
        T[] comps = _GetComponentsInChildrenNonRecursive<T>(obj);
        if (comps.Length > 0)
        {
            return comps[0];
        }
        return null;
    }

    private static T[] _GetComponentsInChildrenNonRecursive<T>(GameObject obj) where T : MonoBehaviour
    {
        List<T> result = new List<T>();
        foreach (Transform child in obj.transform)
        {
            T comp = child.gameObject.GetComponent<T>();
            if (comp != null)
            {
                result.Add(comp);
            }
        }
        return result.ToArray();
    }
}
