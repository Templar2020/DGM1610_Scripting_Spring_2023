using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBounds = 50.0f;
    public float lowerBounds = -15.0f;
    public ScoreManager scoreManager;// Reference the score manager so that we can update the score
    private DetectCollision detectCollision;    

    // Start is called before the first frame update
    void Start()
    {
       scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); //Getting the component ScoreManager.
       detectCollision = GetComponent<DetectCollision>();// Getting the component DetectCollisions.
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBounds)
        {
            Destroy(gameObject);
        }

        else if (transform.position.z < lowerBounds)
        {
            scoreManager.DecreaseScore(detectCollision.scoreToGive); // Everytime a ship sneeks past the lower bounds deduct points
            Destroy(gameObject);
        }
    }
}