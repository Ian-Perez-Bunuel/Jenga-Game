using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector2 movement;
    public Rigidbody2D rb;
    public Camera cam;
    public float activeMoveSpeed;

    //dash info
    public float dashSpeed;
    public float dashLength = 0.5f;
    public float dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;

    Vector2 mousePos;

    void Start()
    {
        activeMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from the user
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //get mouse position
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


        // On dash key pressed do:
        if (Input.GetMouseButtonDown(1))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                this.GetComponent<CircleCollider2D>().enabled = false;
            }
        }

        // When dash ends, do:
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
                this.GetComponent<CircleCollider2D>().enabled = true;
            }
        }

        // Dash cooldown
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * activeMoveSpeed * Time.fixedDeltaTime);

        //Getting the Posistion the character should be looking in
        Vector2 lookDir = mousePos - rb.position;

        // Atan2 is a function that returns the angle of the x axis and a 2D vector starting at 0 and terminating at x,y
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        // makes player rotate to the angle we found above
        rb.rotation = angle;
    }
}