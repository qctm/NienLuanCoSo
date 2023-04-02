using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Arrowtrap : MonoBehaviour
{
    [SerializeField] private float attackCD;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private float CDTimer;
    private void Attack()
    {
        CDTimer = 0;
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<EnemyProjectile>().ActivateProjectfile();
    }

    private int FindFireball()
    {
        for(int i = 0; i<fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    private void Update()
    {
        CDTimer += Time.deltaTime;
        if(CDTimer >= attackCD)
        {
            Attack();
        }
    }
}
