using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakterin yürüme hızı
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Karakteri ileri yönde hareket ettirme
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            // Eğer engelle temas ederse, engelin içinden geç
            Physics2D.IgnoreCollision(other, GetComponent<Collider2D>());
        }
    }
}
