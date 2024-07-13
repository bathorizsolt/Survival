using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] public GameObject[] projectilePrefabs;
    public float projectileSpeed = 1f;
    public float fireRate = 1f;
    [SerializeField] GameObject SpawnPosition;
    public GameObject player;
    private float nextFireTime;

    void Start()
    {

    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + 3f / fireRate;
        }
    }

    void FireProjectile()
    {
        if (player != null && SpawnPosition != null)
        {
            Vector2 direction = ((Vector2)player.transform.position - (Vector2)SpawnPosition.transform.position).normalized;

            GameObject projectile = Instantiate(projectilePrefabs[Random.Range(0, projectilePrefabs.Length)], SpawnPosition.transform.position, Quaternion.identity);

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * projectileSpeed;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }
}