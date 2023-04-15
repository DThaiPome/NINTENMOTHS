using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityReasoner<T> where T : IReasonerAction
{
    private T actionState;
    private List<AConsideration> considerations;

    public UtilityReasoner(T action, List<AConsideration> considerations)
    {
        this.actionState = action;
        this.considerations = new List<AConsideration>(considerations);
    }

    public T action
    {
        get {
            return actionState;
        }
        private set
        {
            actionState = value;
        }
    }

    float CalculateWeight()
    {
        float addend = 0;
        float coeff = 1;
        foreach(var consideration in considerations) {
            consideration.Calculate();
            addend += consideration.calculatedAddend;
            coeff *= consideration.calculatedCoeff;
        }
        return addend * coeff;
    }
}
