using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Serialization;

public class BannerAds : MonoBehaviour
{
    [SerializeField] private string androidAdUnityId;
    private string adUnity;

    private void Awake()
    {
        adUnity = androidAdUnityId;
        
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    public void LoadBannerAd()
    {
        BannerLoadOptions options = new BannerLoadOptions()
        {
            loadCallback = BannerLoaded,
            errorCallback = BannerLoadError
        };
        
        Advertisement.Banner.Load(adUnity, options);
    }

    public void ShowBannerAds()
    {
        BannerOptions options = new BannerOptions()
        {
            showCallback = BannerShow,
            clickCallback = BannerClicked,
            hideCallback = BannerHidden
        };
        Advertisement.Banner.Show(adUnity, options);
    }

    public void HiddenBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    private void BannerShow()
    {
        
    }

    private void BannerClicked()
    {
      
    }

    private void BannerHidden()
    {
    
    }

    private void BannerLoaded()
    {
      
    }
    private void BannerLoadError(string message)
    {
        
    }
}
