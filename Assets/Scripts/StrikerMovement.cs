using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StrikerMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public EnemyManager manager;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.alertLevel == 4)
        {
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            agent.SetDestination(go.transform.position);
        }
    }
}
