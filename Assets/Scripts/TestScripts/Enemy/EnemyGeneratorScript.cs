using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorScript : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab; // 生成する用の敵キャラPrefabを読み込む

    GameObject Player;
    Vector2 PlayerPos; // キャラクターの位置を代入する変数
    private float currentTime = 0f;
    private float span = 3f;

    // 生成される方向を決める乱数用の変数
    int rndUD; // 上下
    int rndLR; // 左右
    Vector2 enemyspwnPos; // 生成される位置

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); // Playerというタグを検索し、見つかったオブジェクトを代入する
    }

    void Update()
    {
        currentTime += Time.deltaTime; // 時間経過をcurrentTimeに代入し時間を測る
        if (currentTime > span) // spanで設定した3秒を越えたら処理を実行
        {
            EnemyGenerate(EnemyPrefab);
            currentTime = 0f;
        }
    }

    public void EnemyGenerate(GameObject Enemy)
    {
        // EnemyPrefabのスポーン位置を決める
        PlayerPos = Player.transform.position; // Playerの現在位置を取得

        // 上下どちらにスポーンするか
        rndUD = Random.Range(0, 2); // 0:上 1:下
        // 左右どちらになるか
        rndLR = Random.Range(0, 2); // 0:左 1:右

        // プレイヤーからどれくらい離れた位置で生成するか
        float rndPositiveX = Random.Range(1.0f, 3.0f);
        float rndPositiveY = Random.Range(1.0f, 3.0f);
        float rndNegativeX = Random.Range(-1.0f, -3.0f);
        float rndNegativeY = Random.Range(-1.0f, -3.0f);

        switch (rndUD)
        {
            case 0: // rndUDが上の場合
                enemyspwnPos.y = rndPositiveY; // 上方向の乱数を代入
                break;
            case 1: // rndUDが下の場合
                enemyspwnPos.y = rndNegativeY; // 下方向の乱数を代入
                break;
        }

        switch (rndLR)
        {
            case 0: // rndLRが左の場合
                enemyspwnPos.x = rndPositiveX; // 左方向の乱数を代入
                break;
            case 1: // rndLRが右の場合
                enemyspwnPos.x = rndNegativeX; // 右方向の乱数を代入
                break;
        }

        enemyspwnPos = enemyspwnPos + PlayerPos; // プレイヤーの位置に先ほどの乱数を足した位置に生成する
        var enemy = Instantiate(Enemy, enemyspwnPos, transform.rotation); // Prefabを生成する
    }
}