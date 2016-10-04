using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla.Store;

public class GameAssets : IStoreAssets{

	public int GetVersion() {
		return 0;
	}

	public VirtualCurrency[] GetCurrencies() {
		return new VirtualCurrency[]{COINS_CURRENCY};
	}

	/// <summary>
	/// see parent.
	/// </summary>
	public VirtualGood[] GetGoods() {
		return new VirtualGood[] {};
	}

	/// <summary>
	/// see parent.
	/// </summary>
	public VirtualCurrencyPack[] GetCurrencyPacks() {
		return new VirtualCurrencyPack[] {ONE_HUND_COINS, TWO_HUND_COINS};
	}

	/// <summary>
	/// see parent.
	/// </summary>
	public VirtualCategory[] GetCategories() {
		return new VirtualCategory[]{};
	}


	public const string COINS_CURRENCY_ITEM_ID = "Coins_currency";

	public const string COINS_CURRENCY_100PACK_ITEM_ID = "One_Hunder_Coins_Pack";
	public const string COINS_CURRENCY_200PACK_ITEM_ID = "Two_Hunder_Coins_Pack";

	public const string ONE_HUND_PACK_PRODUCT_ID = "One_Hunder_Coins";
	public const string TWO_HUND_PACK_PRODUCT_ID = "Two_Hunder_Pearls";




	public static VirtualCurrency COINS_CURRENCY = new VirtualCurrency(
		"Pearls",										// name
		"",												// description
		COINS_CURRENCY_ITEM_ID							// item id
	);


	/** Virtual Currency Packs **/

	public static VirtualCurrencyPack ONE_HUND_COINS = new VirtualCurrencyPack(
		"100 Coins", "Get 100 Coins for 0.99", COINS_CURRENCY_100PACK_ITEM_ID, 100,
		COINS_CURRENCY_ITEM_ID,new PurchaseWithMarket(ONE_HUND_PACK_PRODUCT_ID, 0.99)
	);

	public static VirtualCurrencyPack TWO_HUND_COINS = new VirtualCurrencyPack(
		"200 Coins", "Get 200 Coins for 1.99", COINS_CURRENCY_200PACK_ITEM_ID, 200,
		COINS_CURRENCY_ITEM_ID,new PurchaseWithMarket(TWO_HUND_PACK_PRODUCT_ID, 1.99)
	);



}

