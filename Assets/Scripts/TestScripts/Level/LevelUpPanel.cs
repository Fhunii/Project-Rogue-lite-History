using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // EventTriggerを扱うために必要

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] private GameObject levelUpUI;
    // ImageとButtonを統合し、ItemPanelのGameObjectを直接割り当てる
    [SerializeField] private GameObject[] itemPanels;       // ItemPanel1,2,3 の GameObject

    [Header("Resources フォルダパス")]
    [SerializeField] private string[] resourcePaths = {
        "Sprites/TestSprites/ItemPanels/ItemPanel1",
        "Sprites/TestSprites/ItemPanels/ItemPanel2",
        "Sprites/TestSprites/ItemPanels/ItemPanel3"
    };

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

        // 画像ごとに処理を分岐
        switch (spriteName)
        {
            case "ItemPanel1-1_0":
                Debug.Log("ドローンを付与する処理");
                Time.timeScale = 1;
                break;
            case "ItemPanel1-2_0":
                Debug.Log("ドローンを強化する処理");
                Time.timeScale = 1;
                break;
            case "ItemPanel1-3_0":
                Debug.Log("ドローン最終強化");
                Time.timeScale = 1;
                break;

            case "ItemPanel2-1_0":
                Debug.Log("パンチを付与");
                Time.timeScale = 1;
                break;
            case "ItemPanel2-2_0":
                Debug.Log("パンチ強化");
                Time.timeScale = 1;
                break;
            case "ItemPanel2-3_0":
                Debug.Log("パンチ最終強化");
                Time.timeScale = 1;
                break;

            case "ItemPanel3-1_0":
                Debug.Log("聖水を付与");
                Time.timeScale = 1;
                break;
            case "ItemPanel3-2_0":
                Debug.Log("聖水強化");
                Time.timeScale = 1;
                break;
            case "ItemPanel3-3_0":
                Debug.Log("聖水最終強化");
                Time.timeScale = 1;
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
}