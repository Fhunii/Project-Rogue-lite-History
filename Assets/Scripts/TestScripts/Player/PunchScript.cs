using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PunchScript : MonoBehaviour
{
    [SerializeField] StatusData statusdata;
    public AudioClip sound;//☑
    AudioSource audioSource;//☑\
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
	void Update(){}
 
 void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            audioSource.PlayOneShot(sound);//☑
            other.gameObject.GetComponent<EnemyScript>().Damage(statusdata.ATK);
            other.gameObject.GetComponent<EnemyScript>().NockBack(statusdata.NockBack);
   
        }
    }
}