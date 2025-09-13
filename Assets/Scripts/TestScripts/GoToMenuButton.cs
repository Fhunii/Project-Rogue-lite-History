using UnityEngine;

public class GoToMenuButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
        Debug.Log("GoToMenuButton Clicked");
    }
}
