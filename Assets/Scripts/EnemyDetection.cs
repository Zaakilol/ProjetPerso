using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ennemy")
        {
            RaycastHit hitInfo;
            Vector3 dir = (other.gameObject.transform.position - transform.position).normalized;
            if (Physics.Raycast(transform.position, dir, out hitInfo, 16, 9))
            {
                if (hitInfo.collider.gameObject == other.gameObject)
                {
                    Debug.Log(other.gameObject.name);
                    EnemyManager managerTarget = other.gameObject.GetComponent<EnemyManager>();
                    managerTarget.inFlashLight();
                }
            }
        }
    }
}
