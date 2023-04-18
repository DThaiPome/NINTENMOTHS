using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GlobalStateConsideration : AConsideration
{
    [SerializeField]
    private string stateKey;

    private Func<GlobalActorState> globalStateGetter;

    public void GetGlobalActorStateGetter(Func<GlobalActorState> getter)
    {
        globalStateGetter = getter;
    }
    public override void Calculate()
    {
        addend = 0;
        if (globalStateGetter != null)
        {
            GlobalActorState state = globalStateGetter.Invoke();
            if (state.TryGetVal(stateKey, out float value))
            {
                addend = value;
            }
        }
        coeff = 1;
    }
}
