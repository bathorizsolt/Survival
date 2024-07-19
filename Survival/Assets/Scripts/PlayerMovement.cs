using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float speedBoostAmount = 7f;
    public float speedBoostDuration = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float originalMoveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalMoveSpeed = moveSpeed;
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float effectiveSpeed = moveSpeed * Time.deltaTime;

        transform.Translate(moveInput * effectiveSpeed, 0f, 0f);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    public void ApplySpeedBoost()
    {
        moveSpeed += speedBoostAmount;
        Invoke("ResetSpeed", speedBoostDuration);
    }

    void ResetSpeed()
    {
        moveSpeed = originalMoveSpeed;
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
}
