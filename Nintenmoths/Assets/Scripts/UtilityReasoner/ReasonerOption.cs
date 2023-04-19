using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReasonerOption : MonoBehaviour
{
    [SerializeField]
    private AReasonerAction actionComp;

    public AReasonerAction action
    {
        get
        {
            return actionComp;
        }
        private set
        {
            actionComp = value;
        }
    }

    private List<AConsideration> considerations;

    void Awake()
    {
        RefreshConsiderations();
    }

    public void RefreshConsiderations()
    {
        considerations = new List<AConsideration>(Util.GetComponentsInChildrenNonRecursive<AConsideration>(this));
    }

    public float CalculateWeight()
    {
        float addend = 0;
        float coeff = 1;
        foreach (var consideration in considerations)
        {
            consideration.Calculate();
            addend += consideration.calculatedAddend;
            coeff *= consideration.calculatedCoeff;
        }
        return addend * coeff;
    }
}
