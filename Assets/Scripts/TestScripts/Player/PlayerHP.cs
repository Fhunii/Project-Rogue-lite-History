using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIを使用する際は宣言が必要

public class PlayerHP : MonoBehaviour
{
    [SerializeField] RuntimeStatus statusdata;
    [SerializeField] GameObject GameOverUI;

    public Slider hpBar;

    public float HP;
    // Start is called before the first frame update
    float currentTime = 0f;
    void Start()
    {
        if (hpBar != null)
        {
            hpBar.maxValue = statusdata.MAXHP;
            hpBar.value = statusdata.MAXHP;
        }
        HP = statusdata.MAXHP;
        GameOverUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (HP > statusdata.MAXHP)
        {
            HP = statusdata.MAXHP;
        }
        if (hpBar != null)
        {
            hpBar.value = HP;
        }
        if (HP <= 0)
        {
            currentTime += Time.deltaTime;
            if (currentTime > 1f)
            {
                //Destroy(Player);
                GameOverUI.SetActive(true);
                Time.timeScale = 0f;

            }
        }
    }
    public void Heal(float healAmount)
    {
        HP += healAmount;
    }
    public void Damage(float damageAmount)
    {
        HP -= damageAmount;
    }
}
