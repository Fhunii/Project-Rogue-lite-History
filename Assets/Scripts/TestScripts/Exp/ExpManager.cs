
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public  class ExpManeger : MonoBehaviour
{
    public static ExpManeger instance;
    [SerializeField] GameObject LevelUPpanelUI;
    [SerializeField] Text LevelText;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Particle;
    [SerializeField] Text LevelUPText;
    public static int currentExp;
    public static int CurrentLv;
    int NextLevel;
    int NeedEXP;
    int CumEXP;//累計経験値
    AudioSource audioSource;
    public AudioClip getsound;
    public int[,] EXP =//レベルと必要経験値
        { { 1, 0},
        {2, 6},
        {3, 8},
        {4, 10},
        {5, 14},
        {6, 18},
        {7, 20},
        {8, 25},
        {9, 30} ,
        {10, 35},
        {11, 40},
        {12, 50},
        {13, 60},
        {14, 70},
        {14, 80},

    };
    Vector2 PlayerPos;


	public Slider EXPBar;
	public AudioClip sound;
    // Start is called before the first frame update

    void Start() {
        currentExp=0;
        CurrentLv=1;
        NextLevel = CurrentLv + 1;
        NeedEXP = EXP[CurrentLv, 1];
        if (instance == null)
        {
            instance = this;
        }
          if (EXPBar != null)
        {
            EXPBar.maxValue= NeedEXP;
            EXPBar.value = currentExp;
        }
	    audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {//今の経験値と必要経験値を比べて今の経験値が上だったらレベルをあげる
        if (currentExp >= EXP[CurrentLv, 1]) {
            Debug.Log("レベルアップ"+CurrentLv +"→"+ NextLevel);
            CurrentLv += 1;
            NextLevel += 1;
            LevelText.text = "Level:"+CurrentLv.ToString();
		StartCoroutine(LevelUP());
        }
        
    }

    private IEnumerator LevelUP()
    {
        audioSource.PlayOneShot(sound);
        PlayerPos = Player.transform.position;
        currentExp = 0;//現在の経験値を0にする
        EXPBar.maxValue = NeedEXP;
        EXPBar.value = currentExp;
        var confetti = Instantiate(Particle, PlayerPos, transform.rotation);
        LevelUPText.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(2);//コルーチンで2秒遅延
        LevelUPText.GetComponent<Text>().enabled = false;
        
    }

	public void ExpBarDraw() {//経験値を拾った時にEXPorbから呼び出される
       
        CumEXP++;
        currentExp++;
        EXPBar.value = currentExp;
    }

}

public class GamemanegerScript
{
}