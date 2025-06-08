using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIを使用する際は宣言が必要
 
public class PlayerHP : MonoBehaviour
{
    [SerializeField] StatusData statusdata;
    
    public Slider hpBar;
    
    float HP;
    // Start is called before the first frame update
    void Start()
    {
        if (hpBar != null)
        {
            hpBar.maxValue= statusdata.MAXHP;
            hpBar.value = statusdata.MAXHP;
        }
        HP = statusdata.MAXHP;
    }
}