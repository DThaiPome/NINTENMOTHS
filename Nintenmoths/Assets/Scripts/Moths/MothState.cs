using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothState : MonoBehaviour
{
    [SerializeField]
    private float initialHunger = 0;
    [SerializeField]
    private float initialThirst = 0;
    [SerializeField]
    private float initialExhaustion = 0;

    [SerializeField]
    private GlobalActorState globalStateObj;

    [SerializeField]
    private float hungerPerSecond = .1f;
    [SerializeField]
    private float thirstPerSecond = .25f;
    [SerializeField]
    private float exhaustionPerSecond = 0f;
    [SerializeField]
    private float hungerPerSecondMoving = .3f;
    [SerializeField]
    private float thirstPerSecondMoving = .6f;
    [SerializeField]
    private float exhaustionPerSecondMoving = 1f;
    [SerializeField]
    private float maxHunger = 10;
    [SerializeField]
    private float maxThirst = 10;
    [SerializeField]
    private float maxExhaustion = 10;

    private float hungerState;
    public float hunger
    {
        get
        {
            return hungerState;
        }
        set
        {
            hungerState = value;
            globalStateObj.SetVal("hunger", value);
        }
    }
    private float thirstState;
    public float thirst
    {
        get
        {
            return thirstState;
        }
        set
        {
            thirstState = value;
            globalStateObj.SetVal("thirst", value);
        }
    }
    private float exhaustionState;
    public float exhaustion
    {
        get
        {
            return exhaustionState;
        }
        set
        {
            exhaustionState = value;
            globalStateObj.SetVal("exhaustion", value);
        }
    }

    private float movingState;
    public bool moving
    {
        get
        {
            return movingState >= 0;
        }
        set
        {
            movingState = value ? 1 : -1;
            globalStateObj.SetVal("moving", movingState);
        }
    }

    private void Start()
    {
        hunger = initialHunger;
        thirst = initialThirst;
        exhaustion = initialExhaustion;
    }

    private void Update()
    {
        if (moving)
        {
            hunger += hungerPerSecondMoving * Time.deltaTime;
            thirst += thirstPerSecondMoving * Time.deltaTime;
            exhaustion += exhaustionPerSecondMoving * Time.deltaTime;
        }
        else
        {
            hunger += hungerPerSecond * Time.deltaTime;
            thirst += thirstPerSecond * Time.deltaTime;
            exhaustion += exhaustionPerSecond * Time.deltaTime;
        }
        hunger = Mathf.Min(hunger, maxHunger);
        thirst = Mathf.Min(thirst, maxThirst);
        exhaustion = Mathf.Min(exhaustion, maxExhaustion);
    }
}
