using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Serialization;

public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
   [SerializeField] private string androidAdUnityId;
   private string adUnity;

   private void Awake()
   {
      adUnity = androidAdUnityId;
   }

   public void LoadInterstitialAds()
   {
      Advertisement.Load(adUnity,this);
   }

   public void ShowInterstitialAds()
   {
      Advertisement.Show(adUnity, this);
      LoadInterstitialAds();
   }

   public void OnUnityAdsAdLoaded(string placementId)
   {
      Debug.Log("InterstititalAds");
   }

   public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
   {

   }

   public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
   {
      
   }

   public void OnUnityAdsShowStart(string placementId)
   {
 
   }

   public void OnUnityAdsShowClick(string placementId)
   {
    
   }

   public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
   {
      Debug.Log("Interstitial Ads Completed");
   }
}
