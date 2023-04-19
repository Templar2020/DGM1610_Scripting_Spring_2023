using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBlast_Fixed: MonoBehaviour
{

    public float speed = 30f;
    public int damage = 1;
    public Rigidbody2D rb;
    public PlayerController2D player;
    public int detonationTimer = 10;


    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); // Reference the rigidbody2D component
       player = GameObject.Find("Player").GetComponent<PlayerController2D>();

       if(player.isFacingRight)
         rb.velocity = transform.right * speed * 100 * Time.deltaTime;
       else
         rb.velocity = transform.right * -speed * 100 * Time.deltaTime; // This line of code add velocity and make the gameobject move forward or backward

        //Self Distruct after a certain amount of time
        Destroy(gameObject,detonationTimer);      
    }

    void Update()
    {
       
      
    }

    // Detect any collisions and triggers
    void OnTriggerEnter2D(Collider2D other)
    {
       Enemy enemy = other.GetComponent<Enemy>();

       if(other.gameObject.CompareTag("Enemy"))
       {
         enemy.TakeDamage(damage);//Run the TakeDamage function and apply damage to enemy          
       }
       
       Destroy(gameObject);// Destroy Projectile
        
    }
    
}
