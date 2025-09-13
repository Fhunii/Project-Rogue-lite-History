using UnityEngine;

public class GameButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private string gameSceneName; // シーン名をアサインする
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameSceneName);
        Debug.Log("GameButton Clicked");
    }
}
