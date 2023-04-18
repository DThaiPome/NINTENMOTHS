using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothLearning : MonoBehaviour
{
    [SerializeField]
    private LearningStore learningStore;
    [SerializeField]
    private MothState mothState;

    [SerializeField]
    private float weightIncreasePerFood = 2;
    [SerializeField]
    private float weightIncreaseHungerCoeff = 0.5f;
    [SerializeField]
    private float considerRadius = 7;

    [SerializeField]
    private float weightDecayRate = -.1f;
    [SerializeField]
    private float weightDecayHungerMinimum = 3;

    [SerializeField]
    private float tapWeightChange = -2;

    void Start()
    {
        SpawnFood.onFoodSpawn += OnFoodSpawn;
    }

    private void Update()
    {
        if (mothState.hunger >= weightDecayHungerMinimum)
        {
            string lastKey = learningStore.GetLastActionKey();
            if (lastKey != null && learningStore.GetLearnedWeight(lastKey) > 50)
            {
                float deltaWeight = weightDecayRate * Time.deltaTime;
                learningStore.ModifyLastActionWeight(deltaWeight);
            }
        }
    }

    private void OnDestroy()
    {
        SpawnFood.onFoodSpawn -= OnFoodSpawn;
    }

    private void OnMouseDown()
    {
        learningStore.ModifyLastActionWeight(tapWeightChange);
    }

    private void OnFoodSpawn(Vector3 position)
    {
        if (Vector3.Distance(position, transform.position) <= considerRadius)
        {
            float deltaWeight = weightIncreasePerFood * (mothState.hunger * weightIncreaseHungerCoeff);
            learningStore.ModifyLastActionWeight(deltaWeight);
        }
    }
}
