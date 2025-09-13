using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Create StatusData")]
public class StatusData : ScriptableObject
{
    public float MAXHP; //最大HP
    public float ATK; //攻撃力　
    public float SPEED; //移動速度
    public float NockBack; //のけぞり
    public float SPAN; //間隔
    public int EXP; //経験値

}