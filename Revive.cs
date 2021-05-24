using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Revive : MonoBehaviour
{
    public static Revive revive;

    public Button reviveButton;
    public Button playButton;
    public Button shopButton;
    private int revived;
    public Sprite oneRevive;
    private int vidComp;
    public int totalRevivedTimes;


    private void Start()
    {
        totalRevivedTimes = PlayerPrefs.GetInt("totalReviveTimes",0);
        revived = PlayerPrefs.GetInt("OneRevive");
        PlayerPrefs.SetInt("videoComplete", 0);

        if (revived == 1)
        {
            reviveButton.interactable = true;
        }
        else
        {
            reviveButton.interactable = false;
            reviveButton.image.overrideSprite = oneRevive;

        }
    }
    private void Update()
    {
        vidComp = PlayerPrefs.GetInt("videoComplete");
        if (vidComp == 1)
        {
            VideoComplete();
        }
    }



    public void SceneSwitcher()
    {

        AdManager.instance.ShowRewardedAd();

    }

    public void VideoComplete()
    {
        reviveButton.interactable = false;
        playButton.interactable = false;
        shopButton.interactable = false;
        PlayerPrefs.SetInt("videoComplete", 0);
        totalRevivedTimes++;
        PlayerPrefs.SetInt("totalReviveTimes", totalRevivedTimes);
        SceneManager.LoadScene(1);

    }
}
