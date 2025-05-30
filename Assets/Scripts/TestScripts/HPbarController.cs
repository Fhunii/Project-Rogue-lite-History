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
    // Start is called before the first frame update
    void Start()
    {
        myRectTfm = GetComponent<RectTransform>();
        def = transform.localRotation.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        // 親の回転補正は不要
        // ワールド座標をスクリーン座標に変換
        Vector3 screenPos = Camera.main.WorldToScreenPoint(targetTfm.position + offset);
        myRectTfm.position = screenPos;
    }
}