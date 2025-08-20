using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Create RuntimeStatus")]
public class RuntimeStatus : ScriptableObject
{
    [SerializeField] private StatusData statusdata;

    public float MAXHP { get; private set; }
    public float ATK { get; private set; }
    public float SPEED { get; private set; }
    public float NockBack { get; private set; }
    public float SPAN { get; private set; }
    public int EXP { get; private set; }

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
