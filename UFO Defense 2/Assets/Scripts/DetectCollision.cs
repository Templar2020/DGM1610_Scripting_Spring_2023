using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    private ScoreManager scoreManager; // A variable to hold the reference to the scoremanager
    public int scoreToGive;
    public ParticleSystem explosionParticle; // Store the particle system


    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); // Get scoremanager component
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("LazerBolt")) 
        {
            Destroy(gameObject);// Destroy this game object (UFO)
            Destroy(other.gameObject);//Destroy the other game object it hits            
        }

        Explosion();
        scoreManager.IncreaseScore(scoreToGive); // Increase Score        
    }

   
    void Explosion()
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);                
    }
    
}
