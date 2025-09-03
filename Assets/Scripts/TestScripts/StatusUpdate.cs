using UnityEngine;

public class StatusUpdate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] RuntimeStatus[] runtimeStatuses;
    [SerializeField] ItemLevels itemLevels;

    void Start()
    {
        foreach (var status in runtimeStatuses)
        {
            status.Initialize();
        }

        itemLevels.Attack = 0;
        itemLevels.System = 0;
        itemLevels.Art = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
