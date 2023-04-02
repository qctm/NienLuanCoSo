using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : EnemyDamage
{
    [SerializeField] private float speed; //toc do di chuyen
    [SerializeField] private float range; //pham vi kha dung
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerlayer;
    private float checkTimer;
    private Vector3 destination; //diem den
    private bool attacking;
    private Vector3[] directions = new Vector3[2]; //huong di chuyen cuar spike head

    private void OnEnable()
    {
        Stop();
    }
    private void Update()
    {
        if(attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if(checkTimer > checkDelay)
            {
                CheckForPlayer();
            }
        }
    }
    private void CheckForPlayer()
    {
        CalculateDirections();
        //neu spike nhin thay player
        for (int i=0; i<directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerlayer);
            
            if(hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }

    //tinh toan huong di chuyen cua spike head
    private void CalculateDirections()
    {
        /*
        directions[0] = transform.right * range; //huong: sang phai
        directions[1] = -transform.right * range; //huong: sang trai
        */
        directions[0] = transform.up * range; //huong: len tren
        directions[1] = -transform.up * range; //huong: di xuong
    }

    private void Stop()
    {
        destination = transform.position;
        attacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Stop();
    }
}
