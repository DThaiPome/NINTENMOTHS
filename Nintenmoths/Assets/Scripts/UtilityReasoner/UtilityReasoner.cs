using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityReasoner : MonoBehaviour
{
    List<ReasonerOption> options;
    ReasonerOption chosenOption;

    private void Awake()
    {
        OnAwake();
    }

    protected virtual void OnAwake()
    {
        options = new List<ReasonerOption>(Util.GetComponentsInChildrenNonRecursive<ReasonerOption>(this));
    }

    public IReasonerAction ChooseAction()
    {
        ReasonerOption maxOption = null;
        float maxWeight = float.NegativeInfinity;
        foreach (var option in options)
        {
            float weight = option.CalculateWeight();
            if (weight > maxWeight)
            {
                maxWeight = weight;
                maxOption = option;
            }
        }
        return (chosenOption = maxOption).action;
    }

    public IReasonerAction GetChosenAction()
    {
        return chosenOption.action;
    }
}
