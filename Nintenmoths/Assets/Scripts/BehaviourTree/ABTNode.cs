using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABTNode : AReasonerAction
{
    private ABTNode parentNode;
    private bool isRunning;

    protected BTContext ourContext;

    private void Awake()
    {
        ourContext = new BTContext();
        isRunning = false;
        OnAwake();
    }

    protected virtual void OnAwake()
    {

    }

    public void SetParent(ABTNode parent)
    {
        parentNode = parent;
    }

    public BTResult UpdateNode()
    {
        if (!isRunning)
        {
            // Debug.Log(gameObject.name);
            OnInitialize();
            isRunning = true;
        }
        BTResult result = OnTick();
        if (result != BTResult.RUNNING)
        {
            OnTerminate(result);
            isRunning = false;
        }
        return result;
    }

    public override BTResult RunAction()
    {
        return UpdateNode();
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    public void Terminate()
    {
        if (isRunning)
        {
            OnTerminate(BTResult.RUNNING);
            isRunning = false;
        }
    }

    protected abstract void OnInitialize();
    protected abstract void OnTerminate(BTResult result);
    protected abstract BTResult OnTick();



    // Context Accessors (don't know how to do this effectively with generics lol)
    protected bool TryFindUpperContextVal(string key, out string value)
    {
        value = "";
        return parentNode && (parentNode.ourContext.TryGetVal(key, out value) || parentNode.TryFindUpperContextVal(key, out value));
    }

    protected bool TryReplaceUpperContextVal(string key, string value)
    {
        return parentNode && (parentNode.ourContext.TryReplaceVal(key, value) || parentNode.TryReplaceUpperContextVal(key, value));
    }

    protected bool TryFindUpperContextVal(string key, out int value)
    {
        value = 0;
        return parentNode && (parentNode.ourContext.TryGetVal(key, out value) || parentNode.TryFindUpperContextVal(key, out value));
    }

    protected bool TryReplaceUpperContextVal(string key, int value)
    {
        return parentNode && (parentNode.ourContext.TryReplaceVal(key, value) || parentNode.TryReplaceUpperContextVal(key, value));
    }

    protected bool TryFindUpperContextVal(string key, out float value)
    {
        value = 0;
        return parentNode && (parentNode.ourContext.TryGetVal(key, out value) || parentNode.TryFindUpperContextVal(key, out value));
    }

    protected bool TryReplaceUpperContextVal(string key, float value)
    {
        return parentNode && (parentNode.ourContext.TryReplaceVal(key, value) || parentNode.TryReplaceUpperContextVal(key, value));
    }

    protected bool TryFindUpperContextVal(string key, out GameObject value)
    {
        value = null;
        return parentNode && (parentNode.ourContext.TryGetVal(key, out value) || parentNode.TryFindUpperContextVal(key, out value));
    }

    protected bool TryReplaceUpperContextVal(string key, GameObject value)
    {
        return parentNode && (parentNode.ourContext.TryReplaceVal(key, value) || parentNode.TryReplaceUpperContextVal(key, value));
    }
}
