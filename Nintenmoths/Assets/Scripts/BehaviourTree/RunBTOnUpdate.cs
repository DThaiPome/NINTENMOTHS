using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBTOnUpdate : MonoBehaviour
{
    [SerializeField]
    private ABTNode rootBT;

    void Update()
    {
        rootBT.UpdateNode();
    }
}
