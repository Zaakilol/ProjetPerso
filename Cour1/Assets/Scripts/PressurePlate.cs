using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Door toOpen;
    public Animator anim;
    bool down = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.up, out hitInfo, 1f))
        {
            if (hitInfo.collider.gameObject.tag == "Boite")
            {
                down = true;
                toOpen.opening = true;
            }
            else
            {
                down = false;
                toOpen.opening = false;
            }
        }
        else
        {
            down = false;
            toOpen.opening = false;
        }
        anim.SetBool("Down", down);
    }
}
