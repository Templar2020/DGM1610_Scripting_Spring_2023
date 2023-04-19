using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Stats")]
    public float moveSpeed;                 // movement speed in units per second
    public float jumpForce;                 // force applied upwards

    public int curHp;                       // Current Health of the player
    public int  maxHp;                      // Maximum amount of health a player can have

    [Header("Mouse Look")]
    public float lookSensitivity;           // Mouse look sensitivity
    public float maxLookX;                  // Lowest down we can look
    public float minLookX;                  // Highest up we can look
    private float rotX;                     // Current x rotation of the camera

    private Camera camera;                  //Main Camera Reference
    private Rigidbody rb;                   //Player Rigidbody reference
    //private Weapon weapon;                //Weapon reference

    void Awake()
    {
       //weapon = GetComponent<Weapon>();
       curHp = maxHp;
    }

    // Start is called before the first frame update
    void Start()
    {
       //Get Components
       camera = Camera.main;
       rb = GetComponent<Rigidbody>(); 

       /* Initialize the UI
       GameUI.instance.UpdateHealthBar(curHp, maxHp);
       GameUI.instance.UpdateScoreText(0);
       GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo); */
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed; // Get left and right input
        float z = Input.GetAxis("Vertical") * moveSpeed; // Get forward and back input

        // Move direction relative to camera
        Vector3 dir = transform.right * x + transform.forward * z;    
       
        dir.y = rb.velocity.y;     
        rb.velocity = dir; //Apply force in the relative direction of the camera         
    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;
         
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0); 
        transform.eulerAngles += Vector3.up * y;

    }

    void Jump()
    {
      Ray ray = new Ray(transform.position, Vector3.down); 

      if(Physics.Raycast(ray, 1.1f))
      {
          // Add force to jump
          rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
      }
        
    } 

    // Applies Damage to the Player
    public void TakeDamage(int damage)
    {
        curHp -= damage;

        if(curHp <= 0)
            Die();

        //GameUI.instance.UpdateHealthBar(curHp, maxHp);
    }

    // If players health is reduced zero or below then run Die() 
    void Die()
    {
        //GameManager.instance.LoseGame();
        Debug.Log("Player has died! Game Over!");
        Time.timeScale = 0;
    }
    public void GiveHealth(int amountToGive)
    {
        //curHp = Mathf.Clamp(curHp + amountToGive, 0, maxHp);
        //GameUI.instance.UpdateHealthBar(curHp, maxHp);
         Debug.Log("Player has been healed!");
    }

    public void GiveAmmo(int amountToGive)
    {
        //weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        //GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
        Debug.Log("Player has collected ammo!");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook(); 

        /* Fire Button 
        if(Input.GetButton("Fire1")) 
        {
          if(weapon.CanShoot())
            weapon.Shoot();  
        }*/


        // Jump Button
         if(Input.GetButtonDown("Jump"))
            Jump();   

        /* Don't do anything is the game is pause
        if(GameManager.instance.gamePaused == true)
            return;  */         
    }
}
