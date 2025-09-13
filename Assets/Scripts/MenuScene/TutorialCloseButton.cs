using UnityEngine;

public class TutorialCloseButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject TutorialPanel; // チュートリアルパネルをInspectorで設定
    [SerializeField] private GameObject OtherPanel; // 他のパネルをInspectorで設定
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        //シーンを切り替える
        TutorialPanel.SetActive(false);
        Debug.Log("TutorialCloseButton Clicked");
        OtherPanel.SetActive(true);
    }
}
