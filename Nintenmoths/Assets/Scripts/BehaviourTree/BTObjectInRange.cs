using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BTObjectInRange : ABTNode
{
    [SerializeField]
    private string tagToSearchFor;
    [SerializeField]
    private float radius;

    private Func<GlobalActorState> globalStateGetter;

    public void GetGlobalActorStateGetter(Func<GlobalActorState> getter)
    {
        globalStateGetter = getter;
    }

    protected override void OnInitialize()
    {
    }

    protected override void OnTerminate(BTResult result)
    {
    }

    protected override BTResult OnTick()
    {
        if (globalStateGetter != null)
        {
            GlobalActorState state = globalStateGetter.Invoke();
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tagToSearchFor);
            if (state.TryGetVal("x", out float x) && state.TryGetVal("y", out float y) && state.TryGetVal("z", out float z))
            {
                Vector3 pos = new Vector3(x, y, z);
                foreach (GameObject obj in objects)
                {
                    if (Vector3.Distance(obj.transform.position, pos) <= radius)
                    {
                        return BTResult.SUCCESS;
                    }
                }
                return BTResult.FAILURE;
            }
        }
        return BTResult.FAILURE;
    }
}
