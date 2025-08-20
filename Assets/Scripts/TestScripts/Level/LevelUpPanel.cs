using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelUpPanel : MonoBehaviour
{
    public static LevelUpPanel instance;
    Text itemText;
    public GameManagerScript GMscript;
    string ItemName;

    [SerializeField] GameObject LevelUPUI;
    Image itemimage;
    
    [SerializeField] Sprite imageFunnel;
    [SerializeField] Sprite imageTsuba;
    public int argmentrnd;
    public Image Imagename;
    //public GamemanegerScript GMscript;
    [SerializeField] GameObject drone;
    [SerializeField] RuntimeStatus runtimeStatus;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelPanelprocess()
    {
        //argmentrnd = Random.Range(0, 2);
        //itemimage = this.GetComponentInChildren<Image>();
        //if (argmentrnd == 0)
        //{
        //    Debug.Log(argmentrnd);
        //    itemimage.sprite = imageFunnel;
        //    GMscript.gameObject.GetComponent<GamemanegerScript>().ItemNum(argmentrnd);
        //}
        //if (argmentrnd == 1)
        //{
        //    Debug.Log(argmentrnd);
        //    itemimage.sprite = imageTsuba;
        //    GMscript.gameObject.GetComponent<GamemanegerScript>().ItemNum(argmentrnd);
        //}

    }

    public void Onclick()
    {
        Imagename=this.gameObject.GetComponent<Image>();
        Debug.Log(Imagename.sprite.name);
        if (Imagename.sprite.name == "ItemPanel1_0")
        {
            //ドローンの生成
            var Drone = Instantiate(drone, transform.position, transform.rotation);
            Debug.Log("ドローンを選択");
        }

	if (Imagename.sprite.name == "ItemPanel2_0") {
            Debug.Log("パンチを選択");
	        runtimeStatus.AddATK(1);
            Debug.Log("ATK:"+runtimeStatus.ATK);
        }

	if (Imagename.sprite.name == "ItemPanel3_0") {
            Debug.Log("聖水を選択");
        }

        Time.timeScale = 1;
        LevelUPUI.GetComponent<Canvas>().enabled = false;
        
    }


}