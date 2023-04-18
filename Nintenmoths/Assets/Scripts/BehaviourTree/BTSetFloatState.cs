using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BTSetFloatState : ABTNode
{
    [SerializeField]
    private float value;
    [SerializeField]
    private string destStateKey;

    private Func<GlobalActorState> globalStateGetter;

    public void GetGlobalActorStateGetter(Func<GlobalActorState> getter)
    {
        globalStateGetter = getter;
    }

    protected override void OnInitialize()
    {
    }

    protected override void OnTerminate(BTResult result)
    {
    }

    protected override BTResult OnTick()
    {
        if (globalStateGetter != null)
        {
            GlobalActorState state = globalStateGetter.Invoke();
            state.SetVal(destStateKey, value);
        }
        return BTResult.SUCCESS;
    }
}
