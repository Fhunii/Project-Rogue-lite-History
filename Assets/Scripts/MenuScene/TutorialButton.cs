using UnityEditor.SearchService;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject TutorialPanel; // チュートリアルパネルをInspectorで設定
    void Start()
    {
        TutorialPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        //シーンを切り替える
        TutorialPanel.SetActive(true);
        Debug.Log("TutorialButton Clicked");
    }
}
