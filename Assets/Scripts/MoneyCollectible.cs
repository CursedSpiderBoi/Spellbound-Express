using UnityEngine;

public class MoneyCollectible : MonoBehaviour
{
    public int value = 1; // You can use this later for score/money count
    public float moveSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // Destroy if off-screen
        if (transform.position.x < -15f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // You can add to a score here
            Debug.Log("Collected!");

            // Optionally play a VFX/SFX before destroying
            Destroy(gameObject);
        }
    }
}
