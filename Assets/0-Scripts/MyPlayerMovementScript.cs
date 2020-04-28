using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerMovementScript : MonoBehaviour
{
    private int health = 100;
    public int point = 0;

    private AudioSource fireAudio;


    public CharacterController2D controller;

    public Animator animator;

    public float runSpeed = 40f;
    float horizantalMove = 0f;

    public Transform firePoint;
    public GameObject bulletPrefab;

    bool jump = false;
    bool crouch = false;
    bool fire = false;

    private void Start()
    {
        fireAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        horizantalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetBool("IsShoot", false);

        animator.SetFloat("Speed", Mathf.Abs(horizantalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJump", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            
            fire = true;
            animator.SetBool("IsShoot", true);
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        fireAudio.Play();
    }

    public void GetPoint()
    {
        point += 10;
    }


    public void OnLanding()
    {
        animator.SetBool("IsJump", false);
    }

    public void OnCrouch(bool isCrouch)
    {
        animator.SetBool("IsCrouch", isCrouch);
    }

    


    private void FixedUpdate()
    {
        //Move my character
        controller.Move(horizantalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
