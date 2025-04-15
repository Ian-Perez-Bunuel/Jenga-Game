using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    //reference to Difficulty script from the main menu
    Difficulty difficulty;
    //change in damage depending of difficulty
    public int speedChange;
    public int modSpeed;
    private int dif;
    //amount of damage enemy will deal
    public int damage = 1;

    //view distance that the enemy can see
    public float viewDist = 1f;

    public Rigidbody2D rb;
    Vector2 playerPos;

    private GameObject player;

    public int speed;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        dif = PlayerPrefs.GetInt("difficulty");

        player = GameObject.FindGameObjectWithTag("Player");

        //setting the speed to a different value depending on the difficulty
        if (dif == 1)
        {
            speedChange = 0;
        }

        if (dif == 2)
        {
            speedChange = 2;
        }

        if (dif == 3)
        {
            speedChange = 4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //set the modified speed
        modSpeed = speedChange + speed;


        //checks distance between enemy and Player
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;



        //Player Position
        playerPos = player.transform.position;


        //Getting the Posistion the enemy should be looking in
        Vector2 lookDir = playerPos - rb.position;
        // Atan2 is a function that returns the angle of the x axis and a 2D vector starting at 0 and terminating at x,y
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;


        if (distance < viewDist)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, modSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

    }



}

