using UnityEngine;

public class StatusUpdate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] RuntimeStatus[] runtimeStatuses;

    void Start()
    {
        foreach (var status in runtimeStatuses)
        {
            status.Initialize();
        }
        Time.timeScale = 1f; // ゲームの時間を通常に戻す

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
