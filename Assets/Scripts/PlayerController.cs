using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float verticalInput;
    public float horizontalInput;
    public float speed = 5;
    public GameObject bombPrefab;
    public GameObject bulletsPrefab;
    private GameObject tmpBullets;
    //public GameObject gunIndicator;
    private float powerupStrength = 25f;
    public float health = 100f;
    //public Transform transform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.left * verticalInput * Time.deltaTime * speed);
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput);
        FireBomb();
        if (Input.GetKeyDown(KeyCode.B))
        {
            LaunchBullets();
        }
    }
    private void FireBomb()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bombPrefab, transform.position + new Vector3(0, 1, 0), transform.rotation);
            
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            health--;
            if(health <= 1)
            {
                Destroy(gameObject);
                GameController.instance.RestartGame();
            }
        }
    }
    void LaunchBullets()
    {
        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            tmpBullets = Instantiate(bulletsPrefab, transform.position + Vector3.up,
            Quaternion.identity);
            tmpBullets.GetComponent<Bullet>().Fire(enemy.transform);
        }
    }
}
