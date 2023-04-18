using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTWaitForSeconds : ABTNode
{
    [SerializeField]
    private float seconds = 2;
    [SerializeField]
    private bool useContext = false;
    [SerializeField]
    private string contextKey = "waitSeconds";

    private Coroutine waitCoroutine;

    protected override void OnInitialize()
    {
        StartWait();
    }

    protected override void OnTerminate(BTResult result)
    {
        if (waitCoroutine != null)
        {
            StopCoroutine(waitCoroutine);
            waitCoroutine = null;
        }
    }

    protected override BTResult OnTick()
    {
        BTResult result = waitCoroutine != null ? BTResult.RUNNING : BTResult.SUCCESS;
        return result;
    }

    private void StartWait()
    {
        waitCoroutine = StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(GetWaitSeconds());
        waitCoroutine = null;
    }

    private float GetWaitSeconds()
    {
        if (useContext && TryFindUpperContextVal(contextKey, out float value))
        {
            return value;
        }
        else
        {
            return seconds;
        }
    }
}
