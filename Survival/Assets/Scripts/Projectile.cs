using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float initialSpeed = 4f;
    [SerializeField] float finalSpeed = 15f;
    [SerializeField] float accelerationTime = 1f;
    [SerializeField] float damage = 10f;
    private GameObject player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.velocity = direction * initialSpeed;
            StartCoroutine(IncreaseSpeedOverTime(direction));
        }
    }

    IEnumerator IncreaseSpeedOverTime(Vector2 direction)
    {
        float elapsedTime = 0f;
        while (elapsedTime < accelerationTime)
        {
            elapsedTime += Time.deltaTime;
            rb.velocity = direction * Mathf.Lerp(initialSpeed, finalSpeed, elapsedTime / accelerationTime);
            yield return null;
        }
        rb.velocity = direction * finalSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage((int)damage);
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            Vector2 normal = other.transform.right;
            Vector2 reflectDir = Vector2.Reflect(rb.velocity.normalized, normal).normalized;
            rb.velocity = reflectDir * rb.velocity.magnitude;
            transform.right = reflectDir;
        }
        else if (other.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
