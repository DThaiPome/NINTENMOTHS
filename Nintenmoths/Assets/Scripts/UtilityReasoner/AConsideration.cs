using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AConsideration : MonoBehaviour
{
    public abstract void Calculate();

    protected float addend = 0f;
    public float calculatedAddend
    {
        get
        {
            return addend;
        }
        private set
        {
            addend = value;
        }
    }

    protected float coeff = 1f;
    public float calculatedCoeff
    {
        get
        {
            return coeff;
        }
        private set
        {
            coeff = value;
        }
    }
}
