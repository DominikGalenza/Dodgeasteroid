using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool testMode = true;

    public static AdManager Instance;

#if UNITY_ANDROID
    private string gameId = "4577557";
#elif UNITY_IOS
    private string gameId = "4577556";
#endif
    private GameOver gameOver;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, testMode);
        }
    }

    public void ShowAd(GameOver gameOver)
    {
        this.gameOver = gameOver;
        Advertisement.Show("rewardedVideo");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError($"Ads error: {message}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch(showResult)
        {
            case ShowResult.Finished:
                gameOver.ContinueGame();
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                Debug.LogWarning("Ad failed");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad started");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ads ready");
    }
}
