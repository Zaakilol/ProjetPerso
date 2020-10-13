using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem muzzleFalsh;
    public GameObject flyingBullet;
    public Transform cannonEnd;
    public GameObject impactPrefab;
    public int maxAmmo = 100;
    public Text ammoText;
    public float attackSpeed = 0.047f;
    public Animator anim;
    float baseAttackSPeed;
    int currentAmmo;
    // Start is called before the first frame update
    void Start()
    {
        baseAttackSPeed = attackSpeed;
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = currentAmmo + "/" + maxAmmo;
        baseAttackSPeed -= Time.deltaTime;
        if (Input.GetButton("Fire1") && currentAmmo > 0 && baseAttackSPeed <= 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("Reload"))
        {
            GameObject part = Instantiate(flyingBullet, cannonEnd.position, transform.rotation);
            Destroy(part, 1);
            muzzleFalsh.Play();
            shoot();
            currentAmmo--;
            baseAttackSPeed = attackSpeed;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetBool("Reloading", true);
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Reload") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            currentAmmo = maxAmmo;
            anim.SetBool("Reloading", false);
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

