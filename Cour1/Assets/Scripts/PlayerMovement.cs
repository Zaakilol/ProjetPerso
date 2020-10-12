using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public int score = 0;
    public Transform spawnPos;
    public int health;
    public Text texthp;
    public GameObject gameOverText;
    public float jumpHeight = 10f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isDamaged = false;
    // Update is called once per frame
    void Update()
    {
        texthp.text = "Health : " + health;
        if (health > 0)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            gameOverText.SetActive(false);
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        else
        {
            gameOverText.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (transform.position.y < -5 && isDamaged == false)
        {
            isDamaged = true;
            controller.enabled = false;
            transform.position = spawnPos.position;
            controller.enabled = true;
            health -= 1;
        }
        else
            isDamaged = false;

    }
    public void Regen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
