using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAction : AReasonerAction
{
    [SerializeField]
    private string message;

    public override BTResult RunAction()
    {
        Debug.Log(message);
        return BTResult.SUCCESS;
    }
}
