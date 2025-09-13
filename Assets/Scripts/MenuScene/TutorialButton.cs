using UnityEngine;

public class TutorialButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject TutorialPanel; // チュートリアルパネルをInspectorで設定
    [SerializeField] private GameObject OtherPanel; // 他のパネルをInspectorで設定
    void Start()
    {
        TutorialPanel.SetActive(false);
        OtherPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        //シーンを切り替える
        TutorialPanel.SetActive(true);
        OtherPanel.SetActive(false);
        Debug.Log("TutorialButton Clicked");
    }
}
