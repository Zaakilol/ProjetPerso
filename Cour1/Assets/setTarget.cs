using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class setTarget : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
        GetComponent<Animator>().SetInteger("moving", 1);
    }
}
