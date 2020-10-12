using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public int alertLevel = 0;
    float flashLightTimer = 0;
    float downTime = -1;
    public MeshRenderer currentMaterial;
    public float hp = 50;
    float globalAlertTimer = 2;
    public GameObject angerLight1;
    public GameObject angerLight2;
    public Animator anim;
    float activeTimer;

    // Start is called before the first frame update
    void Start()
    {
        activeTimer = Random.Range(10f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        activeTimer -= Time.deltaTime;
        Debug.Log(activeTimer);
        anim.SetInteger("AlertLevel", alertLevel);
        angerLight1.SetActive(false);
        angerLight2.SetActive(false);
        switch (alertLevel)
        {
            case (1):
                angerLight1.SetActive(true);
                break;
            case (2):
                angerLight1.SetActive(true);
                break;
            case (3):
                angerLight2.SetActive(true);
                break;
        }
        if (hp <= 0)
            Destroy(gameObject);
        flashLightTimer -= Time.deltaTime;
        if (flashLightTimer <= downTime && alertLevel < 3 && alertLevel > 0)
        {
            alertLevel = 0;
            downTime = -1;
        }
        else if (alertLevel == 3)
        {
            globalAlertTimer -= Time.deltaTime;
            if (globalAlertTimer <= 0)
            {
                alertLevel = 4;
                EnemyManager[] enemiesManager = GameObject.FindObjectsOfType<EnemyManager>();
                for (int i = 0; i < enemiesManager.Length; i++)
                {
                    if (Vector3.Distance(gameObject.transform.position, enemiesManager[i].gameObject.transform.position) < 50 && enemiesManager[i].alertLevel < 3)
                        enemiesManager[i].alertLevel = 3;
                }
            }
        }
        if(activeTimer <= 0 && alertLevel == 0)
        {
            alertLevel = 1;
            flashLightTimer = 1;
            downTime = -4;
            activeTimer = Random.Range(10, 20);
        }
    }

    public void inFlashLight()
    {
        if (flashLightTimer <= 0)
        {
            switch (alertLevel)
            {
                case (0):
                    alertLevel = 1;
                    flashLightTimer = 1;
                    downTime = -4;
                    break;
                case (1):
                    alertLevel = 2;
                    flashLightTimer = 1f;
                    downTime = -6;
                    break;
                case (2):
                    alertLevel = 3;
                    break;
            }
        }
    }
}
