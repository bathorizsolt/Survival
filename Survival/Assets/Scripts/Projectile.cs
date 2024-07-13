using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private GameObject player;
    private bool isFired = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = (player.transform.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        isFired = true;
    }

    void Update()
    {
        if (!isFired) return;
        /*
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = (player.transform.position - transform.position).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * speed;
    */
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);

            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            Vector2 normal = other.transform.right;
            Vector2 reflectDir = Vector2.Reflect(GetComponent<Rigidbody2D>().velocity.normalized, normal).normalized;
            GetComponent<Rigidbody2D>().velocity = reflectDir * speed;
            transform.right = reflectDir;

        }
        else if (other.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
