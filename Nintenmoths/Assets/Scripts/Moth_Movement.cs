using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//randomize a vector to move to a certain location and then once the two vectors are equal then rerandomize

public class Moth_Movement: MonoBehaviour
{
    public string destStateKey;
    public GlobalActorState globalState;
    public string currentPosObj = "";

    public float pos_xbound = 9;
    public float neg_xbound = -9;
    public float pos_ybound = 10;
    public float neg_ybound = 0;
    public float x_pos = 0;
    public float y_pos = 0;
    public float speed = 1;
    private Vector3 next_pos= new Vector3(0, 0, -10);

    private bool moving = false;
    // Start is called before the first frame update
    void Start()
    {
        this.x_pos = 0;
        this.y_pos = 5;
        this.next_pos = new Vector3(Random.Range(pos_xbound, neg_xbound), Random.Range(pos_ybound, neg_ybound), -10);
        moving = true;
        globalState.SetVal(destStateKey, currentPosObj);
        if (currentPosObj != "")
        {
            SetPosToObject(currentPosObj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == this.next_pos)
        {
            moving = false;
        }
        else
        {
            float step = this.speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, this.next_pos, step);
        }
        
        if (globalState.TryGetVal(destStateKey, out string statePosObj) && statePosObj != currentPosObj)
        {
            SetPosToObject(statePosObj);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FoodPellet") && moving)
        {
            Destroy(other.gameObject);
        }
    }

    private void SetPosToObject(string name)
    {
        currentPosObj = name;
        GameObject obj = GameObject.Find(currentPosObj);
        if (obj != null)
        {
            Assign_Next_Pos(obj.transform.position);
            moving = true;
        }
        else
        {
            currentPosObj = "";
            globalState.SetVal(destStateKey, "");
        }
    }

    public void Assign_Next_Pos(Vector3 next_position)
    {
        this.next_pos = next_position;
    }
}
