using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLearningModify : MonoBehaviour
{
    [SerializeField]
    private LearningStore store;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            store.ModifyLastActionWeight(10);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            store.ModifyLastActionWeight(-10);
        }
    }
}
