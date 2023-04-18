using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTAlwaysSucceed : ABTNode
{
    private ABTNode child;

    protected override void OnAwake()
    {
        child = Util.GetComponentInChildrenNonRecursive<ABTNode>(this);
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
        return child.UpdateNode() == BTResult.RUNNING ? BTResult.RUNNING : BTResult.SUCCESS;
    }
}
