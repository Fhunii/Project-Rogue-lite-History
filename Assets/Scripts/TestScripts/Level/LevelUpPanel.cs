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

    }

    public void Onclick()
    {
        Imagename=this.gameObject.GetComponent<Image>();
        Debug.Log(Imagename.sprite.name);
        if (Imagename.sprite.name == "ItemPanel1_0")
        {
            var Drone = Instantiate(drone, transform.position, transform.rotation);
            Debug.Log("乱を選択");
            //ソースイメージを変更
            

        }

	    if (Imagename.sprite.name == "ItemPanel2_0")
        {
            Debug.Log("制を選択");
	        runtimeStatus.AddATK(1);
            Debug.Log("ATK:"+runtimeStatus.ATK);
        }

	    if (Imagename.sprite.name == "ItemPanel3_0")
        {
            Debug.Log("芸を選択");
        }

        Time.timeScale = 1;
        LevelUPUI.GetComponent<Canvas>().enabled = false;
        
    }


}