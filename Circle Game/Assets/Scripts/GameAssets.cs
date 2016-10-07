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
		return new VirtualCurrencyPack[] {FIFTY_COINS, ONE_HUND_FIFTY_COINS, FIVE_HUND_COINS, TWO_THOUSAND_COINS};
	}

	/// <summary>
	/// see parent.
	/// </summary>
	public VirtualCategory[] GetCategories() {
		return new VirtualCategory[]{};
	}


	public const string COINS_CURRENCY_ITEM_ID = "coins_currency";

	public const string COINS_CURRENCY_50PACK_ITEM_ID = "fifty_coins_pack";
	public const string COINS_CURRENCY_150PACK_ITEM_ID = "one_hunder_and_fifty_coins_pack";

	public const string FIFTY_PACK_PRODUCT_ID = "fifty_coins";
	public const string ONE_HUND_AND_FIFTY_PACK_PRODUCT_ID = "one_hundred_and_fifty_coins";

    public const string COINS_CURRENCY_500PACK_ITEM_ID = "five_hunder_coins_pack";
    public const string COINS_CURRENCY_2000PACK_ITEM_ID = "two_thousand_coins_pack";

    public const string FIVE_HUND_PACK_PRODUCT_ID = "five_hundred_coins";
    public const string TWENTY_HUND_AND_PACK_PRODUCT_ID = "two_thousand_coins";


    public static VirtualCurrency COINS_CURRENCY = new VirtualCurrency(
		"Coins",										// name
		"",												// description
		COINS_CURRENCY_ITEM_ID							// item id
	);


	/** Virtual Currency Packs **/

	public static VirtualCurrencyPack FIFTY_COINS = new VirtualCurrencyPack(
		"50 Coins", "Get 50 Coins for 0.99$", COINS_CURRENCY_50PACK_ITEM_ID, 50,
		COINS_CURRENCY_ITEM_ID,new PurchaseWithMarket(FIFTY_PACK_PRODUCT_ID, 0.99)
	);

	public static VirtualCurrencyPack ONE_HUND_FIFTY_COINS = new VirtualCurrencyPack(
		"150 Coins", "Get 150 Coins for 1.99", COINS_CURRENCY_150PACK_ITEM_ID, 150,
		COINS_CURRENCY_ITEM_ID,new PurchaseWithMarket(ONE_HUND_AND_FIFTY_PACK_PRODUCT_ID, 1.99)
	);

    public static VirtualCurrencyPack FIVE_HUND_COINS = new VirtualCurrencyPack(
        "500 Coins", "Get 500 Coins for 4.99", COINS_CURRENCY_500PACK_ITEM_ID, 500,
        COINS_CURRENCY_ITEM_ID, new PurchaseWithMarket(FIVE_HUND_PACK_PRODUCT_ID, 4.99)
    );

    public static VirtualCurrencyPack TWO_THOUSAND_COINS = new VirtualCurrencyPack(
       "2000 Coins", "Get 2000 Coins for 9.99", COINS_CURRENCY_2000PACK_ITEM_ID, 2000,
       COINS_CURRENCY_ITEM_ID, new PurchaseWithMarket(TWENTY_HUND_AND_PACK_PRODUCT_ID, 9.99)
   );

}

