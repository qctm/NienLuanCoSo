using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Saw : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float damage = 1;

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
