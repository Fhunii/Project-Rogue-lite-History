using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // --- 変数の統合 ---
    GameObject Player;
    Vector3 PlayerPos;
    [SerializeField] StatusData statusdata;
    
    // HPとダメージ関連
    private float HP;
    private bool MUTEKI; // 無敵状態フラグ
    private float currentTime = 0f; // 無敵時間の計測用

    // プレイヤーとの位置関係・向きの制御用
    Vector3 diff;
    Vector3 vector;

    // 物理挙動用
    private Rigidbody2D rb;

    // --- Startメソッドの統合 ---
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
        // 変数の初期化
        HP = statusdata.MAXHP;
        rb = GetComponent<Rigidbody2D>();

        // プレイヤーの初期位置を向く（2Dでは不要な場合もあります）
        if (Player != null) {
            PlayerPos = Player.transform.position;
            this.transform.LookAt(PlayerPos);
        }
    }

    // --- Updateメソッドの統合 ---
    void Update()
    {
        // Playerオブジェクトが存在する場合のみ実行
        if (Player == null) return;

        // [2つ目のスクリプトの機能] プレイヤー追跡と向きの制御
        PlayerPos = Player.transform.position; // プレイヤーの現在位置を取得
        
        // 無敵状態でない場合のみプレイヤーを追跡
        if (!MUTEKI)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerPos, statusdata.SPEED * Time.deltaTime);
        }

        diff.x = PlayerPos.x - this.transform.position.x; // プレイヤーと敵キャラのX軸の位置関係

        // プレイヤーの位置に合わせて左右の向きを変える
        if (diff.x > 0) // Playerが右側にいる時
        {
            vector = new Vector3(0, -180, 0);
            this.transform.eulerAngles = vector;
        }
        else if (diff.x < 0) // Playerが左側にいる時
        {
            vector = new Vector3(0, 0, 0);
            this.transform.eulerAngles = vector;
        }

        // [1つ目のスクリプトの機能] 無敵時間の処理
        if (MUTEKI)
        {
            currentTime += Time.deltaTime;
            if (currentTime > statusdata.SPAN)
            {
                currentTime = 0f;
                MUTEKI = false; // 無敵状態を解除
                rb.velocity = new Vector2(0, 0); // ノックバックを停止
            }
        }

        // [1つ目のスクリプトの機能] HPが0になったら消滅
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // --- 1つ目のスクリプトのメソッド ---

    /// <summary>
    /// ダメージを受ける処理
    /// </summary>
    /// <param name="damage">受けるダメージ量</param>
    public void Damage(float damage)
    {
        if (!MUTEKI) // 無敵状態でなければダメージを受ける
        {
            HP -= damage;
            Debug.Log("残りHP: " + HP);
            MUTEKI = true; // ダメージを受けたら無敵状態にする
        }
    }

    /// <summary>
    /// ノックバック処理
    /// </summary>
    /// <param name="nockback">ノックバックの強さ</param>
    public void NockBack(float nockback)
    {
        if (Player == null) return;

        Vector2 thisPos = transform.position;
        // 攻撃を受けた時点でのプレイヤーとの正確な位置関係で計算する
        float destination = thisPos.x - Player.transform.position.x;
        
        // プレイヤーと逆方向に飛んでいく
        rb.velocity = new Vector2(destination * nockback, 0);
    }
}