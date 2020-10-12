using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 posCamera = Camera.main.transform.position;
        posCamera.x = target.position.x;
        Camera.main.transform.position = posCamera;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posCamera = Camera.main.transform.position;
        posCamera.x = target.position.x;
        Camera.main.transform.position = posCamera;
    }
}
