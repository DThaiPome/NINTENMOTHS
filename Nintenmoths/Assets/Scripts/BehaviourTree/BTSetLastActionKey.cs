using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BTSetLastActionKey : ABTNode
{
    [SerializeField]
    private string actionKey;
    [SerializeField]
    private bool useContext = false;
    [SerializeField]
    private string contextKey = "";

    private Func<LearningStore> learningStoreGetter;

    public void GetLearningStoreGetter(Func<LearningStore> getter)
    {
        learningStoreGetter = getter;
    }

    protected override void OnInitialize()
    {
    }

    protected override void OnTerminate(BTResult result)
    {
    }

    protected override BTResult OnTick()
    {
        if (learningStoreGetter != null)
        {
            LearningStore store = learningStoreGetter.Invoke();
            if (useContext && TryFindUpperContextVal(contextKey, out string val))
            {
                store.SetLastActionKey(val);
            }
            else
            {
                store.SetLastActionKey(actionKey);
            }
        }
        return BTResult.SUCCESS;
    }
}
