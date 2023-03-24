using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBlast: MonoBehaviour
{

    public float speed = 30.0f;
    public int damage = 1;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
       // Get Rigidbody Component
       rb = GetComponent<Rigidbody2D>(); 
       
    }

    void Update()
    {
       
       rb.velocity = transform.right * speed * Time.deltaTime; // This line of code adds velocity and make the gameobject move forward
      
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
