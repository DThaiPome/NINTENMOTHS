using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReasonerTester : MonoBehaviour
{
    [SerializeField]
    private UtilityReasoner reasoner;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IReasonerAction action = reasoner.ChooseAction();
            action.RunAction();
        }
    }
}
