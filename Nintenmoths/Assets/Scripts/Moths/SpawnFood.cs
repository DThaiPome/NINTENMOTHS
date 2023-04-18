using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnFood : MonoBehaviour
{
    [SerializeField]
    private GameObject foodPrefab;
    [SerializeField]
    private float foodCooldownSeconds = 2;
    [SerializeField]
    private string axis;

    private float cooldownSecondsRemaining;
    private bool holdingFood;
    private GameObject currentFood;

    private static int count = 0;

    public static Action<Vector3> onFoodSpawn;

    void Start()
    {
        cooldownSecondsRemaining = 0;
        holdingFood = false;
    }

    void Update()
    {
        cooldownSecondsRemaining -= Time.deltaTime;
        cooldownSecondsRemaining = Mathf.Max(cooldownSecondsRemaining, 0);
        if (cooldownSecondsRemaining <= 0 && !holdingFood && Input.GetButtonDown(axis))
        {
            holdingFood = true;
            FoodStart();
        }
        if (holdingFood)
        {
            FoodHolding();
            if (Input.GetButtonUp(axis))
            {
                holdingFood = false;
                FoodRelease();
            }
        }
        if (holdingFood && Input.GetButtonUp(axis))
        {
        }
    }

    private void FoodStart()
    {
        currentFood = Instantiate(foodPrefab);
        currentFood.name = currentFood.name + ":" + (count++);
        currentFood.transform.position = GetPositionFromMouse();
        if (onFoodSpawn != null)
        {
            onFoodSpawn.Invoke(currentFood.transform.position);
        }
    }

    private void FoodHolding()
    {
        currentFood.transform.position = GetPositionFromMouse();
    }

    private void FoodRelease()
    {
        Rigidbody rb = currentFood.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        currentFood = null;
        cooldownSecondsRemaining = foodCooldownSeconds;
    }

    private Vector3 GetPositionFromMouse()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(worldPos.x, worldPos.y, transform.position.z);
    }
}
