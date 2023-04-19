using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierConsideration : AConsideration
{
    [SerializeField]
    private float a1, a2, a3;
    [SerializeField]
    private float c1, c2, c3;

    private AConsideration consideration;

    void Awake()
    {
        consideration = Util.GetComponentInChildrenNonRecursive<AConsideration>(this);
    }

    public override void Calculate()
    {
        consideration.Calculate();
        addend = (((consideration.calculatedAddend + a1) * a2) + a3);
        coeff = (((consideration.calculatedCoeff+ c1) * c2) + c3);
    }
}
