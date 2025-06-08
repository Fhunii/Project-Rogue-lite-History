using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIを使用する際は宣言が必要
using UnityEngine.EventSystems; // UIイベントを使用する際は宣言が必要


public class HPbarController : MonoBehaviour
{
    [SerializeField]
    private RectTransform canvasRectTfm;
    [SerializeField]
    private Transform targetTfm;
    private RectTransform myRectTfm;
    private Vector3 offset = new Vector3(0, -0.2f, 0);
    Vector2 pos;
    public Vector2 worldAngle;
    Vector3 def;
    Vector3 _parent;
    Vector3 before;

    private float previousTargetY; // targetTfmの以前のY位置を保存

    // Start is called before the first frame update
    void Start()
    {
        myRectTfm = GetComponent<RectTransform>();
        def = transform.localRotation.eulerAngles;
        
        // targetTfmの現在のY位置でpreviousTargetYを初期化
        if (targetTfm != null)
        {
            previousTargetY = targetTfm.position.y;
        }
    }

    void Update()
    {
        // 親の回転に基づいて回転補正を処理
        _parent = transform.parent.transform.localRotation.eulerAngles;
        if (before != _parent)
        {
            transform.localRotation = Quaternion.Euler(def - _parent);
        }
        before = transform.localRotation.eulerAngles;

        // targetTfmのY位置が変更されたかチェック
        if (targetTfm != null && targetTfm.position.y != previousTargetY)
        {
            // targetTfm.position.yが変更された場合、canvasRectTfmのローカル位置をゼロに設定
            if (canvasRectTfm != null)
            {
                canvasRectTfm.localPosition = Vector3.zero;
            }
            // previousTargetYを現在のY位置に更新
            previousTargetY = targetTfm.position.y;
        }
    }
}