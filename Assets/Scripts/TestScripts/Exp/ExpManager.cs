using UnityEngine;
using UnityEngine.UI;

public class ExpManeger : MonoBehaviour
{

    [SerializeField] Text ExpText;
    int Exp;
    public static ExpManeger instance;
    AudioSource audioSource;
    public AudioClip getsound;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void ExpBarDraw()
    {//経験値を拾った時に呼び出される
        Exp++;
        ExpText.text = Exp.ToString();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(getsound);
    }
}
