using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSequencer : ABTNode
{
    private List<ABTNode> children;
    private int currentChildIndex;

    protected override void OnAwake()
    {
        children = new List<ABTNode>(Util.GetComponentsInChildrenNonRecursive<ABTNode>(this));
        foreach (ABTNode child in children)
        {
            child.SetParent(this);
        }
        currentChildIndex = -1;
    }

    protected override void OnInitialize()
    {
        currentChildIndex = 0;
    }

    protected override void OnTerminate(BTResult result)
    {
        if (currentChildIndex > 0 && currentChildIndex < children.Count)
        {
            children[currentChildIndex].Terminate();
        }
    }

    protected override BTResult OnTick()
    {
        ABTNode child = children[currentChildIndex];
        BTResult result = child.UpdateNode();
        if (result == BTResult.SUCCESS && ++currentChildIndex < children.Count)
        {
            return BTResult.RUNNING;
        }
        return result;
    }
}
