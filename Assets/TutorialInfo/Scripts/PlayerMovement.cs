using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 movement;

    private Animator anim;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); // Get the Animator
    }

  void Update()
{
    float moveX = Input.GetAxisRaw("Horizontal");
    float moveZ = Input.GetAxisRaw("Vertical");

    movement = new Vector3(moveX, 0f, moveZ).normalized;

    // Face movement direction
    if (movement != Vector3.zero)
        transform.forward = movement;

    // Toggle running animation
    anim.SetBool("isRunning", movement.magnitude > 0);
}


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Call this from other scripts when picking up computer parts
    public void PlayCollectAnimation()
    {
        anim.SetTrigger("collect");
    }

    // Call this when player dies
    public void PlayDieAnimation()
    {
        anim.SetTrigger("die");
    }
}
