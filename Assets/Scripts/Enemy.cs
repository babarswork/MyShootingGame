using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody enemyRb;
    private GameObject player;
    private GameObject walls;
    public float enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        walls = GameObject.Find("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate((player.transform.position - transform.position).normalized * speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either wall, destroy it
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }
    public void ApplyDamage(float DamageAmount)
    {
        enemyHealth -= DamageAmount;

        if (enemyHealth < 1f)
        {
            Die();
            GameController.instance.EnemyKilled();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
