using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Create RuntimeStatus")]
public class RuntimeStatus : ScriptableObject
{
    [SerializeField] StatusData statusdata;
    public float MAXHP { get { return statusdata.MAXHP; } set { } }
    public float ATK { get { return statusdata.ATK; } set { } }
    public float SPEED { get { return statusdata.SPEED; } set { } }
    public float NockBack { get { return statusdata.NockBack; } set { } }
    public float SPAN { get { return statusdata.SPAN; } set { } }
    public int EXP { get { return statusdata.EXP; } set { } }
    
}