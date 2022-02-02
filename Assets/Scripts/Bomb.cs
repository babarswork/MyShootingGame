using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody bombRb;
    private GameObject player;
    //private float moveForce = 5;
    public float launchVelocity = 100f;
    // Start is called before the first frame update
    void Start()
    {
        bombRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        BombMovementForward();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BombMovementForward()
    {
        bombRb.AddRelativeForce(new Vector3(0, launchVelocity, launchVelocity));
        StartCoroutine(BlastTiming());
        Destroy(gameObject, 3);

    }
    IEnumerator BlastTiming()
    {
        yield return new WaitForSeconds(2.5f);
        BombBlast();

    }
    void BombBlast()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f);
        foreach (Collider items in colliders)
        {
            if (items.gameObject.CompareTag("Enemy"))
            {
                Destroy(items.gameObject);
                if (player != null && items.gameObject.CompareTag("Player"))
                {
                    player.GetComponent<PlayerController>().health--;
                    Debug.Log(player.GetComponent<PlayerController>().health);
                }
            }
        }
    }
}
