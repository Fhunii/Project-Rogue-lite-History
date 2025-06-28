using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpOrbScript : MonoBehaviour
{
    [SerializeField] Text ExpText;
    public int EXP;

    public AudioClip sound;
    AudioClip getsound;
    AudioSource audioSource;
    int Exp;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ExpManeger.instance.ExpBarDraw();
            Destroy(this.gameObject);
        }
    }
}