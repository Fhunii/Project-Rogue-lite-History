using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class RoundUI : MonoBehaviour
{
    [SerializeField] Sprite[] roundImages;
    [SerializeField] UnityEngine.UI.Image roundImage;

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeRoundImage()
    {

        //呼び出されたとき、roundimagesを配列の中で次のスプライトに変えてroundimageに適応する
        for (int i = 0; i < roundImages.Length; i++)
        {
            if (roundImage.sprite == roundImages[i])
            {
                if (i == roundImages.Length - 1)
                {
                    roundImage.sprite = roundImages[0];
                    return;
                }
                roundImage.sprite = roundImages[i + 1];
                return;
            }
        }

        return;
    }
    
}
