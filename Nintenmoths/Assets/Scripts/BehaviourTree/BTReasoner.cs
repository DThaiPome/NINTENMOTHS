using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTReasoner : ABTNode
{
    UtilityReasoner reasoner;
    IReasonerAction currentAction;

    private void Awake()
    {
        reasoner = GetComponent<UtilityReasoner>();
    }

    protected override void OnInitialize()
    {
        currentAction = reasoner.ChooseAction();
        if (currentAction is ABTNode)
        {
            ((ABTNode)currentAction).SetParent(this);
        }
    }

    protected override void OnTerminate(BTResult result)
    {
        if (currentAction != null && currentAction is ABTNode)
        {
            ((ABTNode)currentAction).Terminate();
        }
        currentAction = null;
    }

    protected override BTResult OnTick()
    {
        if (currentAction != null)
        {
            return currentAction.RunAction();
        }
        return BTResult.FAILURE;
    }
}
