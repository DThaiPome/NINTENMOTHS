using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTRandomSelector : ABTNode
{
    private List<ABTNode> children;

    List<int> indices;
    private int currentIndex;
    private int currentShuffleIndex;

    protected override void OnAwake()
    {
        children = new List<ABTNode>(Util.GetComponentsInChildrenNonRecursive<ABTNode>(this));
        currentIndex = -1;
        indices = new List<int>();
        for(int i = 0; i < children.Count; i++)
        {
            indices.Add(i);
        }
    }

    protected override void OnInitialize()
    {
        indices.Sort(Comparer<int>.Create((a, b) => (int)(Random.value * 100 - 50)));
        currentShuffleIndex = 0;
        currentIndex = indices[currentShuffleIndex];
    }

    protected override void OnTerminate(BTResult result)
    {
        if (currentIndex != -1)
        {
            children[currentIndex].Terminate();
        }
    }

    protected override BTResult OnTick()
    {
        if (currentIndex != -1)
        {
            BTResult result = children[currentIndex].UpdateNode();
            if (result == BTResult.FAILURE && ++currentShuffleIndex < indices.Count)
            {
                currentIndex = indices[currentShuffleIndex];
                return BTResult.RUNNING;
            }
            return result;
        }
        return BTResult.FAILURE;
    }
}
