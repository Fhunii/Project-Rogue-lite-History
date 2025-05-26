using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject Player;
    Vector3 PlayerPos;

    [SerializeField]
    StatusData statusdata; // スクリプト間の参照

    bool MUTEKI; // 攻撃を受けるかどうかの切り替えを行う
    private float HP;
    private float currentTime = 0f; // 無敵時間の経過を測る
    
    Vector3 diff; // プレイヤーとの距離を測るため
    Vector3 vector;
    private Rigidbody2D rb; // Rigidbody2Dの取得

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerPos = Player.transform.position; // Start時点でのプレイヤー位置を取得
        this.transform.LookAt(PlayerPos); // プレイヤーの方を向く（2Dの場合、LookAtはY軸回転に影響する可能性があるので注意）

        HP = statusdata.MAXHP; // HPを初期化
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントを取得
    }

    void Update()
    {
        PlayerPos = Player.transform.position; // プレイヤーの現在位置を毎フレーム取得
        transform.position = Vector2.MoveTowards(transform.position, PlayerPos, statusdata.SPEED * Time.deltaTime); // 現在位置からプレイヤーの位置に向けて移動

        diff.x = PlayerPos.x - this.transform.position.x; // プレイヤーと敵キャラのX軸の位置関係を取得する

        if (diff.x > 0) // Playerが敵キャラの右側にいる時、右側を向く
        {
            vector = new Vector3(0, -180, 0);
            this.transform.eulerAngles = vector;
        }
        else if (diff.x < 0) // Playerが敵キャラの左側にいる時、左側を向く
        {
            vector = new Vector3(0, 0, 0);
            this.transform.eulerAngles = vector;
        }

        if (MUTEKI) // 攻撃を受けてから無敵状態の場合の処理
        {
            currentTime += Time.deltaTime;
            if (currentTime > statusdata.SPAN) // 無敵時間が経過したら
            {
                currentTime = 0f;
                MUTEKI = false; // 無敵状態を終わらせる
                rb.linearVelocity = new Vector2(0, 0); // ノックバックを止める   
            }
        }

        if (HP <= 0) // HPが0以下になったら消える
        {
            Destroy(this.gameObject);
        }
    }

    public void Damage(float damage)
    {
        if (!MUTEKI) // 無敵状態じゃないときに攻撃を受ける
        {
            HP -= damage; // HP減少
            Debug.Log("Current HP: " + HP); // 現在のHPを表示
            MUTEKI = true; // 無敵状態にする
        }
    }

    public void NockBack(float nockback)
    {
        Vector2 thisPos = transform.position;
        // 攻撃を受けた時点での敵キャラとプレイヤーとの位置関係（X軸のみ）
        // プレイヤーが敵の右にいれば正の値、左にいれば負の値
        float destination = thisPos.x - PlayerPos.x; 
        
        // 殴った方向に飛んでいく（X軸にのみノックバックを適用）
        rb.linearVelocity = new Vector2(destination * nockback, 0);
    }
}