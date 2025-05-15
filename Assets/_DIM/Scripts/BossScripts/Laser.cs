using UnityEngine;


public class Laser : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject laser;
    [SerializeField] Rigidbody2D rb;
    private PlayerStats player;
    public float projectileSpeed;

    /// <summary>
    /// Define the speed of the fireballs
    /// </summary>
    void Start()
    {
        rb.linearVelocity = transform.up * projectileSpeed;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Different ways for the fireball to interact with objects like platforms, ice, and the player.
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(laser);
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            player.TakeDamage(2);
        }
    }
}
