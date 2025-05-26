using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject Player;
    Vector3 PlayerPos;

    private float speed = 0.5f;

    Vector3 diff;
    Vector3 vector;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerPos = Player.transform.position;
        this.transform.LookAt(PlayerPos);
    }

    void Update()
    {
        PlayerPos = Player.transform.position; // プレイヤーの現在位置を取得
        transform.position = Vector2.MoveTowards(transform.position, PlayerPos, speed * Time.deltaTime); // 現在位置からプレイヤーの位置に向けて移動

        diff.x = PlayerPos.x - this.transform.position.x; // プレイヤーと敵キャラのX軸の位置関係を取得する

        if (diff.x > 0) // Playerが敵キャラの右側にいる時右側を向く
        {
            vector = new Vector3(0, -180, 0);
            this.transform.eulerAngles = vector;
        }

        if (diff.x < 0) // Playerが敵キャラの左側にいる時左側を向く
        {
            vector = new Vector3(0, 0, 0);
            this.transform.eulerAngles = vector;
        }
    }
}