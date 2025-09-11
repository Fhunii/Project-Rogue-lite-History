using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorScript : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab1; // 生成する用の敵キャラPrefabを読み込む
    [SerializeField] private GameObject EnemyPrefab2;
    [SerializeField] private GameObject EnemyPrefab3;
    [SerializeField] private GameObject EnemyPrefab4;
    [SerializeField] private StatusData EnemyStatusData1;
    [SerializeField] private StatusData EnemyStatusData2;
    [SerializeField] private StatusData EnemyStatusData3;
    [SerializeField] private StatusData EnemyStatusData4;

    private GameObject Player;
    private float currentTime = 0f;

    // 各Prefabから取得した生成間隔を保存する変数
    private float span1, span2, span3, span4;

    // 敵の種類が切り替わる時間（秒）
    private float EnemyUpdate_1 = 15f;
    private float EnemyUpdate_2 = 30f;
    private float EnemyUpdate_3 = 45f;
    // private float EnemyUpdate_4 = 60f; // この時間を超えた際の敵を設定するため

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); // Playerというタグを検索し、見つかったオブジェクトを代入する

        // ゲーム開始時に、各PrefabからStatusDataを取得し、生成間隔(span)をキャッシュする
        // これにより、Update内で毎フレームGetComponentを呼ぶ必要がなくなり、パフォーマンスが向上する

        span1 = EnemyStatusData1.SPAN;
        span2 = EnemyStatusData2.SPAN;
        span3 = EnemyStatusData3.SPAN;
        span4 = EnemyStatusData4.SPAN;
    }

    void Update()
    {
        currentTime += Time.deltaTime; // 時間経過をcurrentTimeに代入し時間を測る

        GameObject prefabToSpawn;
        float spanToUse;

        // --- 時間経過に応じて、生成するPrefabと適用するspanを決定する ---
        // if-else if を使うことで、どの時間帯に何が出現するかが明確になる
        if (Time.time < EnemyUpdate_1)
        {
            prefabToSpawn = EnemyPrefab1;
            spanToUse = span1;
        }
        else if (Time.time < EnemyUpdate_2)
        {
            prefabToSpawn = EnemyPrefab2;
            spanToUse = span2;
        }
        else if (Time.time < EnemyUpdate_3)
        {
            prefabToSpawn = EnemyPrefab3;
            spanToUse = span3;
        }
        else // EnemyUpdate_3 (45秒)以降
        {
            // 60秒を超えてもEnemyPrefab4が出続けるように設定
            prefabToSpawn = EnemyPrefab4;
            spanToUse = span4;
        }
        
        // --- 決定されたspanとPrefabを使って、生成処理を行う ---
        if (currentTime > spanToUse)
        {
            EnemyGenerate(prefabToSpawn);
            currentTime = 0f; // タイマーをリセット
        }
    }

    public void EnemyGenerate(GameObject Enemy)
    {
        // Playerの現在位置を取得
        Vector2 playerPos = Player.transform.position;

        // 生成される方向を決める乱数用の変数をメソッド内で宣言
        int rndUD = Random.Range(0, 2); // 0:上 1:下
        int rndLR = Random.Range(0, 2); // 0:左 1:右

        // プレイヤーからどれくらい離れた位置で生成するかのオフセット値を計算
        float offsetX, offsetY;

        // X軸方向のオフセット
        if (rndLR == 0) // 左
            offsetX = Random.Range(1.0f, 3.0f);
        else // 右
            offsetX = Random.Range(-3.0f, -1.0f);

        // Y軸方向のオフセット
        if (rndUD == 0) // 上
            offsetY = Random.Range(1.0f, 3.0f);
        else // 下
            offsetY = Random.Range(-3.0f, -1.0f);
        
        // プレイヤーの位置にオフセットを足して、最終的な生成位置を決定
        Vector2 enemySpwnPos = playerPos + new Vector2(offsetX, offsetY);
        
        // Prefabを生成する
        Instantiate(Enemy, enemySpwnPos, transform.rotation);
    }
}