using UnityEngine;
using TMPro;
using UnityEditor.ShortcutManagement;

public class Timer : MonoBehaviour
{
    // TextMeshProの参照をInspectorで割り当てる
    public TMP_Text timerText;
    [SerializeField] private GameObject gameClearUI;

    // タイマーの残り時間（秒）
    private float remainingTime = 180f; 
    void Start()
    {
        // タイマーの初期化
        remainingTime = 180f;
        gameClearUI.SetActive(false);
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            // 毎フレーム時間を減らす
            remainingTime -= Time.deltaTime;

            // マイナスにならないようにする
            if (remainingTime < 0)
                remainingTime = 0;

            // 分と秒に変換
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);

            // 表示を更新 (例: "09:58")
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            // タイムアップ時の処理
            gameClearUI.SetActive(true);
            Time.timeScale = 0f; // ゲームを停止

            // ここにタイムアップ時の追加処理を記述できます
        }
    }
}
