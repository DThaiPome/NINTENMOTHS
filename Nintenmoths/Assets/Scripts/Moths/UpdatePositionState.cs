using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePositionState : MonoBehaviour
{
    [SerializeField]
    private GlobalActorState globalState;

    void Start()
    {
        UpdateState();
    }

    void Update()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        globalState.SetVal("x", transform.position.x);
        globalState.SetVal("y", transform.position.y);
        globalState.SetVal("z", transform.position.z);
    }
}
