using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] RuntimeStatus statusdata;
    Vector3 worldAngle;
    public SpriteRenderer spriteRenderer;
    private float currentTime;
    [SerializeField] GameObject punch;
    [SerializeField] Sprite imageIdle;
    [SerializeField] Sprite imagePunch;

    void Start()
    {
        spriteRenderer.sprite = imageIdle;
        punch.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (this.transform.position.y < 3)
            {
                transform.position += new Vector3(0, statusdata.SPEED * Time.deltaTime, 0);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (this.transform.position.y > -2.3)
            {
                transform.position += new Vector3(0, -1 * statusdata.SPEED * Time.deltaTime, 0);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.transform.position.x > -3)
            {
                worldAngle.y = 0f;
                this.transform.localEulerAngles = worldAngle;
                transform.position += new Vector3(-1 * statusdata.SPEED * Time.deltaTime, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (this.transform.position.x < 3)
            {
                worldAngle.y = -180f;
                this.transform.localEulerAngles = worldAngle;
                transform.position += new Vector3(statusdata.SPEED * Time.deltaTime, 0, 0);
            }
        }
        if (currentTime > statusdata.SPAN)//2秒ごとに実行される
        {
            spriteRenderer.sprite = imagePunch;//Playerの画像を攻撃用の画像に切り替える
            punch.GetComponent<BoxCollider2D>().enabled = true;//あたり判定をつける
            StartCoroutine("Punchswitch");//攻撃を持続させるためのコルーチンを起動する
            
        }
        currentTime += Time.deltaTime;//経過時間をカウントする
    }

    IEnumerator Punchswitch()
    {
        yield return new WaitForSeconds(5);//5秒後に下の2行を実行する
        spriteRenderer.sprite = imageIdle;//待機状態の画像に切り替える
        punch.GetComponent<BoxCollider2D>().enabled = false;//あたり判定をなくす
        currentTime = 0f;
        StopCoroutine("Punchswitch");//コルーチンを終了する
    }
}