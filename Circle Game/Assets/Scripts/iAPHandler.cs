using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla.Store;
using UnityEngine.UI;
public class iAPHandler : MonoBehaviour {

	public static string errorMsg = "Status:";
    

    [SerializeField]
    Text textBox;


	void Start() {

		StoreEvents.OnMarketPurchase += onMarketPurchase;
		StoreEvents.OnMarketRefund += onMarketRefund;
		StoreEvents.OnItemPurchased += onItemPurchased;
		StoreEvents.OnGoodEquipped += onGoodEquipped;
		StoreEvents.OnGoodUnEquipped += onGoodUnequipped;
		StoreEvents.OnGoodUpgrade += onGoodUpgrade;
		StoreEvents.OnBillingSupported += onBillingSupported;
		StoreEvents.OnBillingNotSupported += onBillingNotSupported;
		StoreEvents.OnMarketPurchaseStarted += onMarketPurchaseStarted;
		StoreEvents.OnItemPurchaseStarted += onItemPurchaseStarted;
		StoreEvents.OnUnexpectedErrorInStore += onUnexpectedErrorInStore;
		StoreEvents.OnCurrencyBalanceChanged += onCurrencyBalanceChanged;
		StoreEvents.OnGoodBalanceChanged += onGoodBalanceChanged;
		StoreEvents.OnMarketPurchaseCancelled += onMarketPurchaseCancelled;
		StoreEvents.OnRestoreTransactionsStarted += onRestoreTransactionsStarted;
		StoreEvents.OnRestoreTransactionsFinished += onRestoreTransactionsFinished;

#if UNITY_ANDROID && !UNITY_EDITOR
		StoreEvents.OnIabServiceStarted += onIabServiceStarted;
		StoreEvents.OnIabServiceStopped += onIabServiceStopped;
#endif
        SoomlaStore.Initialize(new  GameAssets());
		



	}
	void AddCoins(int count) {
		int cCoins = PlayerPrefs.GetInt (Helpers.COINS_KEY, 0);
        string text = textBox.text;
         text = text + "Coins " + cCoins.ToString() + "CoinsToBe Added: " + count.ToString();
        textBox.text = text;
		cCoins += count;
		PlayerPrefs.SetInt (Helpers.COINS_KEY, cCoins);
			
	}

	/// <summary>
	/// Handles a market purchase event.
	/// </summary>
	/// <param name="pvi">Purchasable virtual item.</param>
	/// <param name="purchaseToken">Purchase token.</param>
	public void onMarketPurchase(PurchasableVirtualItem pvi, string purchaseToken,Dictionary<string,string> type) {
		
	}

	/// <summary>
	/// Handles a market refund event.
	/// </summary>
	/// <param name="pvi">Purchasable virtual item.</param>
	public void onMarketRefund(PurchasableVirtualItem pvi) {

	}

	/// <summary>
	/// Handles an item purchase event. 
	/// </summary>
	/// <param name="pvi">Purchasable virtual item.</param>
	public void onItemPurchased(PurchasableVirtualItem pvi, string note) {
		Debug.Log( "Bought pack.\n Thanks!");
        textBox.text = "Bought pack.";
		if (pvi.ItemId == GameAssets.COINS_CURRENCY_50PACK_ITEM_ID) {
			AddCoins (50);
		}
		else if (pvi.ItemId == GameAssets.COINS_CURRENCY_150PACK_ITEM_ID) {
			AddCoins (150);
		}
        else if (pvi.ItemId == GameAssets.COINS_CURRENCY_500PACK_ITEM_ID) {
            AddCoins(500);
        }
        else if(pvi.ItemId == GameAssets.COINS_CURRENCY_2000PACK_ITEM_ID) {

            AddCoins(2000);
        }


	}

	/// <summary>
	/// Handles a good equipped event.
	/// </summary>
	/// <param name="good">Equippable virtual good.</param>
	public void onGoodEquipped(EquippableVG good) {

	}

	/// <summary>
	/// Handles a good unequipped event.
	/// </summary>
	/// <param name="good">Equippable virtual good.</param>
	public void onGoodUnequipped(EquippableVG good) {

	}

	/// <summary>
	/// Handles a good upgraded event. 
	/// </summary>
	/// <param name="good">Virtual good that is being upgraded.</param>
	/// <param name="currentUpgrade">The current upgrade that the given virtual 
	/// good is being upgraded to.</param>
	public void onGoodUpgrade(VirtualGood good, UpgradeVG currentUpgrade) {

	}

	/// <summary>
	/// Handles a billing supported event.
	/// </summary>
	public void onBillingSupported() {

	}

	/// <summary>
	/// Handles a billing NOT supported event.
	/// </summary>
	public void onBillingNotSupported() {

	}

	/// <summary>
	/// Handles a market purchase started event. 
	/// </summary>
	/// <param name="pvi">Purchasable virtual item.</param>
	public void onMarketPurchaseStarted(PurchasableVirtualItem pvi) {

	}

	/// <summary>
	/// Handles an item purchase started event. 
	/// </summary>
	/// <param name="pvi">Purchasable virtual item.</param>
	public void onItemPurchaseStarted(PurchasableVirtualItem pvi) {

	}

	/// <summary>
	/// Handles an item purchase cancelled event. 
	/// </summary>
	/// <param name="pvi">Purchasable virtual item.</param>
	public void onMarketPurchaseCancelled(PurchasableVirtualItem pvi) {
		//print(");
		Debug.Log("Cancelled purchase.");
	}

	/// <summary>
	/// Handles an unexpected error in store event.
	/// </summary>
	/// <param name="message">Error message.</param>
	public void onUnexpectedErrorInStore(string message) {

		if (message == "") {
			Debug.Log( "Something went wrong.\n Try Again Later.");
		}else {
			Debug.Log( message);
		}

	}

	/// <summary>
	/// Handles a currency balance changed event.
	/// </summary>
	/// <param name="virtualCurrency">Virtual currency whose balance has changed.</param>
	/// <param name="balance">Balance of the given virtual currency.</param>
	/// <param name="amountAdded">Amount added to the balance.</param>
	public void onCurrencyBalanceChanged(VirtualCurrency virtualCurrency, int balance, int amountAdded) {
		//ExampleLocalStoreInfo.UpdateBalances();
	}

	/// <summary>
	/// Handles a good balance changed event.
	/// </summary>
	/// <param name="good">Virtual good whose balance has changed.</param>
	/// <param name="balance">Balance.</param>
	/// <param name="amountAdded">Amount added.</param>
	public void onGoodBalanceChanged(VirtualGood good, int balance, int amountAdded) {
		//ExampleLocalStoreInfo.UpdateBalances();
	}

	/// <summary>
	/// Handles a restore Transactions process started event.
	/// </summary>
	public void onRestoreTransactionsStarted() {

	}

	/// <summary>
	/// Handles a restore transactions process finished event. 
	/// </summary>
	/// <param name="success">If set to <c>true</c> success.</param>
	public void onRestoreTransactionsFinished(bool success) {
		if (success) {

			errorMsg = "";

		}
	}

	public void Package1Clicked() {
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer ) {
			StoreInventory.BuyItem(GameAssets.COINS_CURRENCY_50PACK_ITEM_ID);
		}else {
			//Testing on the computer e.g
			Debug.Log("Thanks for your purchase. \n It means a lot!");

		}
	}
	public void Package2Clicked() {
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer ) {
			StoreInventory.BuyItem(GameAssets.COINS_CURRENCY_150PACK_ITEM_ID);
		}else {
			//Testing on the computer e.g
			Debug.Log("Thanks for your purchase. \n It means a lot!");
		}
	}

    public void Package3Clicked()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            StoreInventory.BuyItem(GameAssets.COINS_CURRENCY_500PACK_ITEM_ID);
        }
        else
        {
            //Testing on the computer e.g
            Debug.Log("Thanks for your purchase. \n It means a lot!");
        }
    }

    public void Package4Clicked()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            StoreInventory.BuyItem(GameAssets.COINS_CURRENCY_2000PACK_ITEM_ID);
        }
        else
        {
            //Testing on the computer e.g
            Debug.Log("Thanks for your purchase. \n It means a lot!");
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
	public void onIabServiceStarted() {

	}
	public void onIabServiceStopped() {

	}
#endif




}
