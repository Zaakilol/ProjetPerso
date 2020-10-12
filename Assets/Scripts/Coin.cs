using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int score = 10;
    public PlayerMovement playerMovement;
    public GameObject pickupEffect;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            spawnPoint.position = gameObject.transform.position;
            UpdateScore(score);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    void UpdateScore(int add)
    {
        playerMovement.score += add;
    }
}
