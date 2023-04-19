using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASpacialConsideration : AConsideration
{
    protected Vector3 location;

    public void SetLocation(Vector3 location)
    {
        SetLocation(location, "");
    }

    public virtual void SetLocation(Vector3 location, string name)
    {
        this.location = location;
    }
}
