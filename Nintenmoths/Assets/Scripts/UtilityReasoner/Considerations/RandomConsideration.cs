using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomConsideration : AConsideration
{
    [SerializeField]
    private float addendMin, addendMax, coeffMin, coeffMax;

    public override void Calculate()
    {
        addend = Random.Range(addendMin, addendMax);
        coeff = Random.Range(coeffMin, coeffMax);
    }
}
