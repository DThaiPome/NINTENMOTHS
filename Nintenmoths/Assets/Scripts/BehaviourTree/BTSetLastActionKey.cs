using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BTSetLastActionKey : ABTNode
{
    [SerializeField]
    private string actionKey;

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
            store.SetLastActionKey(actionKey);
        }
        return BTResult.SUCCESS;
    }
}
