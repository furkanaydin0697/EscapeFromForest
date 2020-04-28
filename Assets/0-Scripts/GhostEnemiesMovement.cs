using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemiesMovement : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;

    public float speed = 1;

    public bool IsRight;

    void Update()
    {
        if (IsRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D turn)
    {
        if (turn.gameObject.tag == "turn")
        {
            if (IsRight)
            {
                IsRight = false;
            }
            else
            {
                IsRight = true;
            }
        }
    }



    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
