using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;

public class StrikerBehaviour : MonoBehaviour
{
    public EnemyManager manager;
    public AudioSource sound;
    public AudioClip[] clips;
    int currentState = 0;
    public AudioClip footstep;
    float footstepTimer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        footstepTimer -= Time.deltaTime;
        if (currentState == 4 && footstepTimer <= 0)
        {
            if (sound.isPlaying == false)
            {
                sound.clip = footstep;
                sound.Play();
                footstepTimer = 0.3f;
            }
        }
        if (currentState != manager.alertLevel)
        {
            switch (manager.alertLevel)
            {
                case (0):
                    sound.Stop();
                    break;
                case (1):
                    sound.Stop();
                    sound.clip = clips[Random.Range(0, 18)];
                    sound.Play();
                    break;
                case (2):
                    sound.Stop();
                    sound.clip = clips[18];
                    sound.Play();
                    break;
                case (3):
                    sound.Stop();
                    if (manager.scream == true)
                    {
                        sound.clip = clips[19];
                        sound.Play();
                    }
                    break;
            }
            currentState = manager.alertLevel;
        }
    }
}
