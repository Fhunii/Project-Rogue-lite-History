using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;
using NUnit.Framework.Constraints; // コルーチンに必要

public class RoundUI : MonoBehaviour
{
    [SerializeField] Sprite[] roundImages;
    [SerializeField] Image roundImage;
    [SerializeField] GameObject RoundUIObject;

    void Start()
    {
        roundImage.sprite = null;
        RoundUIObject.SetActive(true);
        ChangeRoundImage();
        Debug.Log(roundImages.Length);
    }

    public void ChangeRoundImage()
    {
        RoundUIObject.SetActive(true);
        // 呼び出されたとき、roundImagesを配列の中で次のスプライトに変えてroundImageに適応する
        for (int i = 0; i < roundImages.Length; i++)
        {
            if (roundImage.sprite == roundImages[i])
            {
                if (i == roundImages.Length - 1)
                {
                    roundImage.sprite = roundImages[0];
                    StartCoroutine(HideAfterDelay(0.75f));
                    return;
                }
                roundImage.sprite = roundImages[i + 1];
                StartCoroutine(HideAfterDelay(0.75f));
                return;
            }
        }

        // 初回呼び出しなどで sprite がまだ設定されていない場合
        if (roundImages.Length > 0)
        {
            roundImage.sprite = roundImages[0];
            StartCoroutine(HideAfterDelay(0.75f));
        }
    }

    private IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        RoundUIObject.SetActive(false);
    }
}
