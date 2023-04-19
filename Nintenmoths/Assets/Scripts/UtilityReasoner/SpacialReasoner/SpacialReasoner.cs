using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacialReasoner : UtilityReasoner
{
    [SerializeField]
    private GameObject optionPrefab;
    [SerializeField]
    private List<string> tagMask;
    
    protected override void OnAwake()
    {
        List<AConsideration> considerations = new List<AConsideration>(Util.GetComponentsInChildrenNonRecursive<AConsideration>(this));

        List<GameObject> objs = new List<GameObject>();
        foreach(string tag in tagMask)
        {
            GameObject[] arr = GameObject.FindGameObjectsWithTag(tag);
            objs.AddRange(arr);
        }

        List<GameObject> considerationObjs = new List<GameObject>();
        foreach(AConsideration consideration in considerations)
        {
            considerationObjs.Add(consideration.gameObject);
        }

        foreach(GameObject obj in objs)
        {
            GameObject option = Instantiate(optionPrefab, transform);
            option.transform.SetParent(transform);
            Vector3 objPos = obj.transform.position;
            foreach (GameObject considerationObj in considerationObjs)
            {
                GameObject clone = Instantiate(considerationObj, option.transform);
                AConsideration consideration = clone.GetComponent<AConsideration>();
                if (consideration is ASpacialConsideration)
                {
                    ((ASpacialConsideration)consideration).SetLocation(objPos, obj.name);
                }
            }
            ReasonerOption optionComp = option.GetComponent<ReasonerOption>();
            optionComp.RefreshConsiderations();
            ABTNode rootNode = option.GetComponent<ABTNode>();
            rootNode.SetVal("locationObjName", obj.name);
        }

        base.OnAwake();
    }
}
