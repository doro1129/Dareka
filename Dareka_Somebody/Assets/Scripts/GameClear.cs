using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    [SerializeField] private GameObject GameClearCanvas;
    public AudioClip gameclearClip;
    public GameObject collections;

    public GameObject reward;
    public GameObject rewardDescription;
    public Sprite finishSprite;

    public void CallGameClearMenu()
    {
        CollectionManager collectionManager = collections.GetComponent<CollectionManager>();
        Image rewardImage = reward.GetComponent<Image>();
        Text rewardText = rewardDescription.GetComponent<Text>();

        int rewardNum = collectionManager.Collect();
        if (rewardNum != -1)
        {
            rewardImage.sprite = collectionManager.collectionsProps[rewardNum];
            rewardText.text = string.Format("{0}\n\n{1}",
                GameManager.instance.collectionsProps[rewardNum],
                GameManager.instance.collectionsDescriptions[rewardNum]);
        }
        else
        {
            rewardImage.sprite = finishSprite;
            rewardText.text = string.Format("{0}",
                "해당 스테이지에서 획득할 수 있는 모든 보상을 다 모았습니다!");
        }

        SoundManager.instance.SFXPlay("GameClear", gameclearClip);
        GameManager.isPaused = true;
        GameClearCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseGameClearMenu()
    {
        GameManager.isPaused = false;
        GameClearCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}