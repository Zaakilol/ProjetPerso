using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;
    public bool opening;
    // Start is called before the first frame update
    void Start()
    {
        opening = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            anim.SetBool("Found", opening);
    }
}
