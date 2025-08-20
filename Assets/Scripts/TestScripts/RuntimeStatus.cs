using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Create RuntimeStatus")]
public class RuntimeStatus : ScriptableObject
{
    [SerializeField] private StatusData statusdata;

    public float MAXHP;
    public float ATK;
    public float SPEED;
    public float NockBack;
    public float SPAN;
    public int EXP;

    void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        MAXHP = statusdata.MAXHP;
        ATK = statusdata.ATK;
        SPEED = statusdata.SPEED;
        NockBack = statusdata.NockBack;
        SPAN = statusdata.SPAN;
        EXP = statusdata.EXP;
    }

    // 必要なら値を変更するメソッドを用意
    public void AddATK(float amount)
    {
        ATK += amount;
    }
}
