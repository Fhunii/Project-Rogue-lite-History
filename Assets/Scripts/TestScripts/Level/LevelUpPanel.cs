using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting; // EventTriggerを扱うために必要

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] private GameObject levelUpUI;
    // ImageとButtonを統合し、ItemPanelのGameObjectを直接割り当てる
    [SerializeField] private GameObject[] itemPanels;       // ItemPanel1,2,3 の GameObject

    [Header("Resources フォルダパス")]
    [SerializeField]
    private string[] resourcePaths = {
        "Sprites/TestSprites/ItemPanels/ItemPanel1",
        "Sprites/TestSprites/ItemPanels/ItemPanel2",
        "Sprites/TestSprites/ItemPanels/ItemPanel3"
    };

    [SerializeField] private GameObject dronePrefab1; // ドローンのプレハブ
    [SerializeField] private GameObject dronePrefab2; // ドローン強化のプレハブ
    [SerializeField] private GameObject dronePrefab3; // ドローン最終強化のプレハブ
    [SerializeField] private RuntimeStatus playerRuntimeStatus; // プレイヤーのGameObject
    [SerializeField] private RuntimeStatus[] enemyRuntimeStatus; // 敵のGameObject
    [SerializeField] private RuntimeStatus[] weaponStatusData; // 武器のGameObject
    [SerializeField] private GameObject ExitButton; // 終了ボタンのGameObject
    [SerializeField] private PlayerHP playerHP; // プレイヤーのHP管理用インスタンス
    private Sprite[][] panelSprites; // 各パネルごとのスプライト配列
    private int[] currentIndex;      // 各パネルの現在インデックス

    void Awake()
    {
        // 各フォルダからスプライトをロード
        panelSprites = new Sprite[resourcePaths.Length][];
        currentIndex = new int[resourcePaths.Length];

        for (int i = 0; i < resourcePaths.Length; i++)
        {
            panelSprites[i] = Resources.LoadAll<Sprite>(resourcePaths[i]);
            currentIndex[i] = 0;

            // GameObjectからImageコンポーネントを取得
            Image panelImage = itemPanels[i].GetComponent<Image>();
            if (panelImage == null)
            {
                Debug.LogError($"ItemPanel {i} に Image コンポーネントがありません。");
                continue;
            }

            // 初期画像をセット
            if (panelSprites[i].Length > 0)
                panelImage.sprite = panelSprites[i][0];

            // --- EventTriggerの設定 ---
            // EventTriggerコンポーネントを取得または追加
            EventTrigger trigger = itemPanels[i].GetComponent<EventTrigger>();
            if (trigger == null)
            {
                trigger = itemPanels[i].AddComponent<EventTrigger>();
            }

            // PointerClickイベント用のエントリーを作成
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;

            int index = i; // クロージャ対策
            // コールバックに関数を登録
            entry.callback.AddListener((eventData) => { OnItemPanelClick(index); });

            // EventTriggerにエントリーを追加
            trigger.triggers.Add(entry);
        }
    }

    /// <summary>
    /// パネルがクリックされたとき
    /// </summary>
    public void OnItemPanelClick(int panelIndex)
    {
        // GameObjectからImageコンポーネントを取得して現在のスプライトを得る
        Image panelImage = itemPanels[panelIndex].GetComponent<Image>();
        Sprite currentSprite = panelImage.sprite;
        string spriteName = currentSprite.name;
        Debug.Log($"クリックされたパネル {panelIndex + 1} : {spriteName}");

        if (currentIndex[panelIndex] >= panelSprites[panelIndex].Length - 1)
        {
            Debug.Log($"パネル{panelIndex + 1}は最終進化なので処理しません。UIも閉じません。");
            return; // ここで終了（閉じない）
        }

        // 画像ごとに処理を分岐
        switch (spriteName)
        {
            case "ItemPanel1-1_0":
                Debug.Log("フリントロック");
                Time.timeScale = 1;
                Instantiate(dronePrefab1);
                break;
            case "ItemPanel1-2_0":
                Debug.Log("エンフィールド");
                Time.timeScale = 1;
                Instantiate(dronePrefab2);
                break;
            case "ItemPanel1-3_0":
                Debug.Log("シャスポー");
                Time.timeScale = 1;
                Instantiate(dronePrefab3);
                break;

            case "ItemPanel2-1_0":
                Debug.Log("ロマン主義");
                Time.timeScale = 1;
                playerRuntimeStatus.AddATK(2.0f); // ATKを2.0増加
                break;
            case "ItemPanel2-2_0":
                Debug.Log("印象派");
                Time.timeScale = 1;
                foreach (var enemyStatus in enemyRuntimeStatus)
                {
                    enemyStatus.AddATK(-1.0f); // 各敵のATKを1.0減少
                }
                break;
            case "ItemPanel2-3_0":
                Debug.Log("ワーグナー");
                foreach (var weaponStatus in weaponStatusData)
                {
                    weaponStatus.SPAN *= 0.9f; // 各武器の攻撃速度を10%速くする
                }
                Time.timeScale = 1;
                break;

            case "ItemPanel3-1_0":
                Debug.Log("ウィーン体制");
                Time.timeScale = 1;
                //武器の攻撃速度を25%遅くする代わりに武器の攻撃力を2倍にする
                foreach (var weaponStatus in weaponStatusData)
                {
                    weaponStatus.SPAN *= 1.25f; // 各武器の攻撃速度を25%遅くする
                }
                foreach (var weaponStatus in weaponStatusData)
                {
                    weaponStatus.ATK *= 2f; // 各武器の攻撃力を2倍にする
                }
                break;
            case "ItemPanel3-2_0":
                Debug.Log("ナイチンゲール");
                Time.timeScale = 1;
                playerRuntimeStatus.MAXHP *= 2f; // プレイヤーの体力を2倍にする
                playerHP.HP = playerRuntimeStatus.MAXHP; // 現在のHPも最大値に合わせる
                break;
            case "ItemPanel3-3_0":
                Debug.Log("ドイツ帝国");
                Time.timeScale = 1;
                //攻撃力を3倍にする
                playerRuntimeStatus.AddATK(playerRuntimeStatus.ATK * 2); // 3倍にする
                //武器の攻撃速度は2倍にする
                foreach (var weaponStatus in weaponStatusData)
                {
                    weaponStatus.SPAN *= 0.5f; // 各武器の攻撃速度を早くする
                }
                break;
        }

        // 次の画像に進める
        currentIndex[panelIndex]++;
        if (currentIndex[panelIndex] < panelSprites[panelIndex].Length)
        {
            panelImage.sprite = panelSprites[panelIndex][currentIndex[panelIndex]];
        }
        else
        {
            // 最後の画像なら止める（またはループさせても良い）
            currentIndex[panelIndex] = panelSprites[panelIndex].Length - 1;
        }
        levelUpUI.GetComponent<Canvas>().enabled = false;
        Debug.Log("処理終わり");
    }
    public void OnClick()
    {
        // 終了ボタンが押されたらUIを閉じる
    
        levelUpUI.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1; // ゲーム再開
        Debug.Log("終了ボタンが押されました。UIを閉じます。");
        
    }
}