using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;

    private bool isFacingRight = true;
    private bool isGrounded = false;

    private Rigidbody2D rb2d;
    private Animator animator;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0 && !isFacingRight)
            FlipSprite();
        else if (horizontalInput < 0 && isFacingRight)
            FlipSprite();
    }

    private void Movement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalMovement * movementSpeed * Time.deltaTime, 0, 0);
        animator.SetFloat("speed", Mathf.Abs(horizontalMovement));
    }

    private void Jump()
    {
        isGrounded = false;
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        animator.SetBool("isJumping", true);
    }

    private void FlipSprite()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }
}
