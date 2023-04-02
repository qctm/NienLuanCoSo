using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Fire : MonoBehaviour
{
    [SerializeField] private float damage = 1;
    [Header("Firetrap timer")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    
    private Animator anim;
    private SpriteRenderer spRend;
    private bool triggered;
    private bool active;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //khong hoat dong
            if (!triggered)
            {
                //bat lua
                StartCoroutine(ActivateFiretrap());
            }
            //hoat dong
            if (active)
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }
    private IEnumerator ActivateFiretrap()
    {
        //canh bao cho player
        triggered = true;
        spRend.color = Color.red;

        //doi delay
        yield return new WaitForSeconds(activationDelay);
        spRend.color = Color.white;
        active = true;
        anim.SetBool("activated", true);
       //deactivate
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
