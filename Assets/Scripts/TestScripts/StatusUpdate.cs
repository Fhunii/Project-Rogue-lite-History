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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
