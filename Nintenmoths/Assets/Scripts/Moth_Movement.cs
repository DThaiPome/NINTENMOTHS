using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//randomize a vector to move to a certain location and then once the two vectors are equal then rerandomize

public class Moth_Movement: MonoBehaviour
{
    public string destStateKey;
    public GlobalActorState globalState;
    public LearningStore learningStore;
    public string currentPosObj = "";
    public int hungerRecoveryFromPellets = 2;
    public float targetPositionNoise = .5f;

    public float pos_xbound = 9;
    public float neg_xbound = -9;
    public float pos_ybound = 10;
    public float neg_ybound = 0;
    public float x_pos = 0;
    public float y_pos = 0;
    public float speed = 1;
    private Vector3 next_pos= new Vector3(0, 0, -10);

    private Vector3 corePos;

    private MothState state;

    private float originalXScale;

    private bool moving = false;

    private float t;
    // Start is called before the first frame update
    void Start()
    {
        this.x_pos = 0;
        this.y_pos = 5;
        this.originalXScale = transform.localScale.x;
        this.next_pos = new Vector3(Random.Range(pos_xbound, neg_xbound), Random.Range(pos_ybound, neg_ybound), -10);
        this.corePos = transform.position;
        UpdateDirection();
        state = GetComponent<MothState>();
        moving = true;
        state.moving = true;
        globalState.SetVal(destStateKey, currentPosObj);
        if (currentPosObj != "")
        {
            SetPosToObject(currentPosObj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(corePos, next_pos) < .001f)
        {
            moving = false;
            state.moving = false;
        }
        else
        {
            float step = this.speed * Time.deltaTime;
            corePos = Vector3.MoveTowards(transform.position, this.next_pos, step);
            transform.position = RealPosition();
        }
        
        if (globalState.TryGetVal(destStateKey, out string statePosObj) && statePosObj != currentPosObj)
        {
            SetPosToObject(statePosObj);
        }
    }

    private Vector3 RealPosition()
    {
        t += Time.deltaTime;
        t %= 2 * Mathf.PI;
        Vector3 offset = Vector3.up * Mathf.Sin(t * Mathf.Rad2Deg * .5f) * .02f;
        return corePos + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FoodPellet") && moving)
        {
            Destroy(other.gameObject);
            state.hunger -= hungerRecoveryFromPellets;
            state.hunger = Mathf.Max(0, state.hunger);
            learningStore.ModifyLastActionWeight(10);
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
            state.moving = true;
        }
        else
        {
            currentPosObj = "";
            globalState.SetVal(destStateKey, "");
        }
    }

    public void Assign_Next_Pos(Vector3 next_position)
    {
        Vector3 offset = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1)) * targetPositionNoise;
        Vector3 realPos = new Vector3(next_position.x + offset.x, next_position.y + offset.y, -10);
        this.next_pos = realPos;
        UpdateDirection();
    }

    private void UpdateDirection()
    {
        if (this.next_pos.x > transform.position.x)
        {
            this.transform.localScale = new Vector3(-this.originalXScale, this.transform.localScale.y, this.transform.localScale.z);
        }
        else
        {
            this.transform.localScale = new Vector3(this.originalXScale, this.transform.localScale.y, this.transform.localScale.z);
        }
    }
}
