using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchScript : MonoBehaviour
{
    [SerializeField]
    StatusData statusdata;

    void Start()
    {
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyScript>().Damage(statusdata.ATK);
            other.gameObject.GetComponent<EnemyScript>().NockBack(statusdata.NockBack);
        }
    }
}