using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AReasonerAction : MonoBehaviour, IReasonerAction
{
    public abstract void RunAction();
}
