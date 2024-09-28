using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;   // Control the bird's speed
    private Rigidbody2D rb;
    public bool isDead = false;
  
    private AudioSource audioSource; // Reference to AudioSource component

    public AudioClip takeoffSound; // Assign takeoff sound from the Inspector
    public AudioClip deathSound;   // Assign death sound from the Inspector

    public float maxRotationUp = 45f;   // Maximum upward rotation
    public float maxRotationDown = -45f; // Maximum downward rotation
    public float rotationSpeed = 5f;     // Speed of rotation adjustment

    void Start()
    {
        // Get Rigidbody2D, Animator, and AudioSource components
        rb = GetComponent<Rigidbody2D>();
 
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    void Update()
    {
        // Left mouse click or tap to make the bird fly up
        if ((Input.GetMouseButtonDown(0) && !isDead)|| (Input.GetKeyDown(KeyCode.Space)&&!isDead))
        {
            rb.velocity = Vector2.up * speed;
            // Trigger takeoff animation

            // Play takeoff sound
            audioSource.PlayOneShot(takeoffSound); // Play the takeoff sound
        }

        // Rotate the bird based on its velocity
        RotateBird();

      
    }

    private void RotateBird()
    {
        // Rotate upwards when moving up, downwards when falling
        float targetRotation = Mathf.Lerp(maxRotationDown, maxRotationUp, (rb.velocity.y + speed) / (2 * speed));

        // Smoothly rotate towards the target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetRotation), Time.deltaTime * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isDead)
        {
            isDead = true;
            // Trigger death animation

            // Play death sound
            audioSource.PlayOneShot(deathSound); // Play the death sound
        }
    }
}
