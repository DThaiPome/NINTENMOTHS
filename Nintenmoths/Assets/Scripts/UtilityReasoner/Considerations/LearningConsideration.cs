using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LearningConsideration : AConsideration
{
    [SerializeField]
    private string learningKey;

    private Func<LearningStore> learningStoreGetter;

    public void GetLearningStoreGetter(Func<LearningStore> getter)
    {
        learningStoreGetter = getter;
    }

    public override void Calculate()
    {
        if (learningStoreGetter != null)
        {
            LearningStore store = learningStoreGetter.Invoke();
            addend = 0;
            coeff = store.GetLearnedWeight(learningKey) / 100.0f;
        }
        else
        {
            addend = 0;
            coeff = 1;
        }
    }
}
