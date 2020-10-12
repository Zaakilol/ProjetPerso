﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem muzzleFalsh;
    public GameObject flyingBullet;
    public Transform cannonEnd;
    public GameObject impactPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            GameObject part = Instantiate(flyingBullet, cannonEnd.position, transform.rotation);
            Destroy(part, 1);
            muzzleFalsh.Play();
            shoot();
        }
    }

    void shoot()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range, 9))
        {
            GameObject impakt = Instantiate(impactPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impakt, 0.2f);
            EnemyManager target = hitInfo.transform.GetComponent<EnemyManager>();
            if (target != null)
            {
                target.hp -= damage;
            }
        }
    }
    float lerp(float a, float b, float t)
    {

        return 0;
    }
}
