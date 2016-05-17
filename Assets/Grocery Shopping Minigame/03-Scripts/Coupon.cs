using UnityEngine;
using System.Collections;

public abstract class Coupon {
	public abstract int[] applyCoupon (int[] prices, int[] brands, int[] products);

	protected int getIndexOfFirstItemWithMinPrice(int minPrice, int productID, int brandID, int[] prices, int[] brands, int[] products) {
		int numItems = prices.Length;
		for (int currIndex = 0; currIndex < numItems; currIndex++) {
			if (products [currIndex] == productID && brands [currIndex] == brandID && prices [currIndex] >= minPrice) {
				return currIndex;
			}
		}
		return -1;
	}

	protected int getNumOfProductsOfBrand(int productID, int brandID, int[] brands, int[] products) {
		int numItems = brands.Length;
		int numValidItems = 0;
		for (int currIndex = 0; currIndex < numItems; currIndex++) {
			if (products [currIndex] == productID && brands [currIndex] == brandID) {
				numValidItems++;
			}
		}
		return numValidItems;
	}
}

public abstract class SingleProductCoupon : Coupon {
	protected int productID;
	protected int brandID;

	protected SingleProductCoupon(int prod, int brand) {
		productID = prod;
		brandID = brand;
	}
}

public abstract class MultiProductCoupon : Coupon {
	protected int productA;
	protected int productB;
	protected int brandA;
	protected int brandB;

	protected MultiProductCoupon(int prodA, int prodB, int brandIDA, int brandIDB) {
		productA = prodA;
		productB = prodB;
		brandA = brandIDA;
		brandB = brandIDB;
	}
}

public class BOGOCoupon : SingleProductCoupon {
	BOGOCoupon(int prod, int brand) : base (prod, brand){}


	public override int[] applyCoupon(int[] prices, int[] brands, int[] products) {
		int qualifyingIndex = getIndexOfFirstItemWithMinPrice (0, productID, brandID, prices, brands, products);
		if (qualifyingIndex > 0 && getNumOfProductsOfBrand(productID, brandID, brands, products) > 1) {
			int targetIndex = getIndexOfFirstItemWithMinPrice (1, productID, brandID, prices, brands, products);
			if (targetIndex > 0) {
				prices [targetIndex] = 0;
			}
		}
		return prices;
	}
}

public class BuyOneGetTwoCoupon : SingleProductCoupon {
				BuyOneGetTwoCoupon(int prod, int brand) : base (prod, brand) {}


	public override int[] applyCoupon(int[] prices, int[] brands, int[] products) {
		int qualifyingIndex = getIndexOfFirstItemWithMinPrice (0, productID, brandID, prices, brands, products);
		if (qualifyingIndex > 0 && getNumOfProductsOfBrand(productID, brandID, brands, products) > 1) {
			int targetIndex = getIndexOfFirstItemWithMinPrice (1, productID, brandID, prices, brands, products);
			if (targetIndex > 0) {
				prices [targetIndex] = 0;
			}
			targetIndex = getIndexOfFirstItemWithMinPrice (1, productID, brandID, prices, brands, products);
			if (targetIndex > 0) {
				prices [targetIndex] = 0;
			}
		}
		return prices;
	}
}

public class BuyOneAGetOneBCoupon : MultiProductCoupon {
				BuyOneAGetOneBCoupon(int prodA, int prodB, int brandA, int brandB) : base (prodA, prodB, brandA, brandB) {}

	public override int[] applyCoupon(int[] prices, int[] brands, int[] products) {
		int qualifyingIndex = getIndexOfFirstItemWithMinPrice (0, productA, brandA, prices, brands, products);
		if (qualifyingIndex > 0) {
			int targetIndex = getIndexOfFirstItemWithMinPrice (1, productB, brandB, prices, brands, products);
			if (targetIndex > 0) {
				prices [targetIndex] = 0;
			}
		}
		return prices;
	}
}
