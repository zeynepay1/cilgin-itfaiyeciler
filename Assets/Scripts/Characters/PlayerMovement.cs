using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Hareket Ayarlarý")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Zemin Kontrolü")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Zemin kontrolü
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Yatay hareket
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Animasyon
        if (animator != null)
        {
            animator.SetFloat("Move", Mathf.Abs(moveInput));
            animator.SetBool("IsJumping", !isGrounded);
        }

        // Yön kontrolü (saða/sola bakýþ)
        if (moveInput > 0)
            transform.localScale = new Vector3(1.5f, 2, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1.5f, 2, 1);

        // Zýplama
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}