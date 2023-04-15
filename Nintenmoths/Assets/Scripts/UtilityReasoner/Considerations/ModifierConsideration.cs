using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierConsideration : AConsideration
{
    private AConsideration consideration;
    private float a1, a2, a3;
    private float c1, c2, c3;

    /// <summary>
    /// Normal consideration expression: Addend = A, Coeff = C
    /// Modified consideration expression: Addend = (((A * a1) + a2) * a3), Coeff = (((C * c1) + c2) * c3)
    /// </summary>
    public ModifierConsideration(AConsideration consideration, float a1, float a2, float a3, float c1, float c2, float c3)
    {
        this.consideration = consideration;
        this.a1 = a1;
        this.a2 = a2;
        this.a3 = a3;
        this.c1 = c1;
        this.c2 = c2;
        this.c3 = c3;
    }

    public override void Calculate()
    {
        consideration.Calculate();
        addend = (((addend + a1) * a2) + a3);
        coeff = (((coeff + c1) * c2) + c3);
    }
}
