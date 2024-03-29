using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;// Add the UI library namespace

public class Health : MonoBehaviour
{

    public int maxHealth = 10;
    public int currentHealth; 
    public int numberOfhearts; // Number of hearts
    public Image[] hearts; // Number of heart images in the UI
    public Sprite fullHeart; // Full heart sprite
    public Sprite emptyHeart; // Empty heart sprite
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;// Reset time back to realtime
        currentHealth = maxHealth; // Set current health to max health
    }

    void Update()
    {
        //currentHealth will not exceed number of hearts
        if(currentHealth > numberOfhearts)
        {
            currentHealth = numberOfhearts;
        }
        // Populate and manage hearts on HUD UI
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
               hearts[i].sprite = fullHeart; 
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numberOfhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;  
            }
        }
    }
    public void TakeDamage(int dmgAmount)
    {
        currentHealth -= dmgAmount;
        Debug.Log("Player Health = "+ currentHealth);
        
        if(currentHealth <=0)
        {
            Debug.Log("You are dead! Game Over!"); // Game Over message in the console
            Time.timeScale = 0; // Freeze the game           
        }
    }

    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth >= maxHealth)// Puts a cap on current health amount
        {
            currentHealth = maxHealth;
        }
    }
}
