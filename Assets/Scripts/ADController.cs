using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
public class ADController : MonoBehaviour
{
    private InterstitialAD interstitial;

    public static ADController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        interstitial = GetComponent<InterstitialAD>();
    }
    private void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            interstitial.LoadInterstitialAd();
        });
    }
    public void ShowInterstitial()
    {
        interstitial.ShowAd();
    }
}
