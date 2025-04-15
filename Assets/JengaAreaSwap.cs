using UnityEngine;
using UnityEngine.SceneManagement;

public class JengaAreaSwap : MonoBehaviour
{
    // The color of the block when it is not hovered over
    public Color normalColor = Color.white;

    // The color of the block when it is hovered over
    public Color hoverColor = Color.yellow;

    // The sprite renderer component of the block
    private SpriteRenderer spriteRenderer;

    // Set the initial color of the block
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = normalColor;
    }




    // Update the color of the block based on the hover state
    private void Update()
    {
        // Check if the mouse is hovering over the block
        if (IsMouseOver())
        {
            // Change the color of the block to the hover color
            spriteRenderer.color = hoverColor;

            // Check if the mouse button is pressed
            if (Input.GetMouseButtonDown(0))
            {
                // Destroy the game object
                Destroy(gameObject);

                // Load other scene
                SceneManager.LoadScene("Jenga Area");
            }
        }
        else
        {
            // Change the color of the block to the normal color
            spriteRenderer.color = normalColor;
        }
    }

    // Check if the mouse is hovering over the block
    private bool IsMouseOver()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Create a rectangle the size of the block at the block's position
        Rect rect = new Rect(
            transform.position.x - spriteRenderer.bounds.size.x / 2,
            transform.position.y - spriteRenderer.bounds.size.y / 2,
            spriteRenderer.bounds.size.x,
            spriteRenderer.bounds.size.y
        );

        // Check if the mouse position is within the rectangle
        return rect.Contains(mousePosition);
    }
}