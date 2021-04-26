using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject enemy;
    public EnemyController enemyController;
    public GameObject fireEff;
    public GameObject deadEff;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.CompareTag("Enemy")) {
            rb.velocity = Vector3.zero;
            Destroy(other.gameObject);
            deadEff.SetActive(true);
            fireEff.SetActive(false);
        }
    }
}
