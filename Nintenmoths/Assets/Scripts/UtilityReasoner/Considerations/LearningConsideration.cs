using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LearningConsideration : ASpacialConsideration
{
    [SerializeField]
    private string learningKey;
    [SerializeField]
    private bool useSpacialReasoner = false;

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

    public override void SetLocation(Vector3 location, string name)
    {
        base.SetLocation(location, name);
        if (useSpacialReasoner)
        {
            learningKey = name;
        }
    }
}
