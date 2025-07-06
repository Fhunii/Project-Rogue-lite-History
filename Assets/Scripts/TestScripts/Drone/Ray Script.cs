using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class RayScript : MonoBehaviour
{
    private GameObject[] targets;
    private GameObject closeEnemy;
    [SerializeField] StatusData statusdata;
    Vector3 diff;
    
        void Start()
        {

            Search();//どの敵が一番近いかを比べる
        
        }
    
    void Update() {
        
        if (closeEnemy != null)
        {//敵が見つかった時
        
            transform.position = Vector2.MoveTowards(transform.position, closeEnemy.transform.position, statusdata.SPEED * Time.deltaTime);
            diff = (closeEnemy.transform.position - this.transform.position).normalized;
            this.transform.rotation = Quaternion.FromToRotation(Vector3.right, diff);

        }
        else
        {//敵がいない場合
            Destroy(gameObject);
        }
        }
    
        void Search()
        {

            float closeDist = 100;//仮に初期値を100にする
    
            targets = GameObject.FindGameObjectsWithTag("Enemy");//EnemyというTagを検索する
            foreach (GameObject t in targets)//見つかった数だけループする
            {
            
                float tDist = Vector2.Distance(transform.position, t.transform.position);//ビームとその敵の距離を測る
                
                if (closeDist > tDist)//現在の最短距離よりも近い場合に実行される
                {
                    closeDist = tDist;//最短距離を更新する
                    closeEnemy = t;//ゲームオブジェクトにも代入する
                }
    
            }
    
        }
        void OnTriggerEnter2D(Collider2D other)//敵とぶつかったらダメージ関数を発動
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyScript>().Damage(statusdata.ATK);
                other.gameObject.GetComponent<EnemyScript>().NockBack(statusdata.NockBack);
                Destroy(gameObject);//自分自身を消す
            }
        }
 
}