using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomConsideration : AConsideration
{
    private float addendMin, addendMax, coeffMin, coeffMax;

    public RandomConsideration(float addendMin, float addendMax, float coeffMin, float coeffMax)
    {
        this.addendMin = addendMin;
        this.addendMax = addendMax;
        this.coeffMin = coeffMin;
        this.coeffMax = coeffMax;
    }

    public override void Calculate()
    {
        addend = Random.Range(addendMin, addendMax);
        coeff = Random.Range(coeffMin, coeffMax);
    }
}
