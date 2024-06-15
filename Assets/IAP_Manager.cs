using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAP_Manager : MonoBehaviour
{
   [SerializeField] private GameObject ads;
   private string removeAds = "com.kkkk1401.dinorunner.removeads";
   public Button remove;
   private String isPurchase = "isPurchase";
   private int purchased;
   public void OnPurchaseComplete(Product product)
   {
      if (product.definition.id == removeAds)
      {  
         
         PlayerPrefs.SetInt(isPurchase, 1);
         Debug.Log("All ads remove");
      }
   }

   private void Awake()
   {
      purchased = PlayerPrefs.GetInt(isPurchase, 0);
      checkPurchase();
   }

   private void Start()
   {
   
   }

   public void checkPurchase()
   {
      if (purchased == 1)
      {
         remove.gameObject.SetActive(false);
         ads.gameObject.SetActive(false);
      }
      else remove.gameObject.SetActive(true);
   }
   
   public void OnPurchaseFailed(Product product, PurchaseFailureReason failureDescription)
   {
      Debug.Log(failureDescription);
   }
}
