using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40; 
    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        SkeletonEnemiesMovement skeleton = hitInfo.GetComponent<SkeletonEnemiesMovement>();
        //GhostEnemiesMovement ghost = hitInfo.GetComponent<GhostEnemiesMovement>();
        if (skeleton != null /*|| ghost != null*/)
        {
            //ghost.TakeDamage(damage);
            skeleton.TakeDamage(damage);
        }
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
        //GetComponent<MyPlayerMovementScript>().GetPoint();
    }

}
