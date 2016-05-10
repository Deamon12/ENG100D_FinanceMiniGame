using UnityEngine;
using System.Collections;

public class ListController : MonoBehaviour
{
    public class List
    {
        ////List of product 
        private int[][] list = null;

        //number of product categories
        const int numOfProdCategory = 3;
        const int maxNumOfProd = 8;

        //Default Constructor
        public List()
        {
            list = new int[3][];
            for (int j = 0; j < 3; j++)
            {
                list[j] = new int[3];

            }
        }

        //Accessor Functions
        public int[][] getList()
        {
            return list;
        }
        public int getListValue(int indexOfProduct, int option)
        {
            return list[indexOfProduct][option];
        }

        //Mutator Function
        public void setList(int[][] currList)
        {
            list = currList;
        }

        public int getNumOfProdCategory()
        {
            return numOfProdCategory;
        }

        /**
         *
         * Description : This function is for updating list element
         */
        public void setListValue(int indexOfProduct, int option, int val)
        {
            list[indexOfProduct][option] = val;
        }


        /**
         * @name : findProduct()
         * @param : index of item from products list
         * @return : index of item from grocery list. (-1 for not exist)
         * Description : If the item is in the grocery list, this will print the index of the item from the grocery list.
         *
         */
        public int findProduct(int product)
        {
            int result = -1;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i][0] == product)
                {
                    result = i;
                }
            }
            return result;
        }


        /**
         * @name : makeList
         * Description : This function generate new grocery list.
         */
        public void makeList()
        {
            //Setting First Product
            int product = Random.Range(0, numOfProdCategory);
            int numOfProduct = Random.Range(1, maxNumOfProd);

            list[0][0] = product;       //first product
            list[0][1] = numOfProduct;  //number of first product
            list[0][2] = 0;             //This will trace the number of product in cart

            //Setting Second Product
            do
            {
                product = Random.Range(0, numOfProdCategory);
            } while (product == list[0][0]);
            numOfProduct = Random.Range(1, maxNumOfProd);

            list[1][0] = product;        //second product
            list[1][1] = numOfProduct;   //number of second product
            list[1][2] = 0;              //This will trace the number of product in cart

            //Setting Third Product
            do
            {
                product = Random.Range(0, numOfProdCategory);
            } while (product == list[0][0] || product == list[1][0]);
            numOfProduct = Random.Range(1, maxNumOfProd);

            list[2][0] = product;           //third product
            list[2][1] = numOfProduct;      //number of third product
            list[2][2] = 0;                 //This will trace the number of product in cart

        }

        /**
         * @name : isDone()
         * @return : This return true when user buy all the groceries from the list.
         */
        public bool isDone()
        {
            if (list[0][1] <= list[0][2] && list[1][1] <= list[1][2]
                && list[2][1] <= list[2][2])
            {
                return true;
            }
            return false;
        }

        /**
         * @name : printList()
         * @return : void
         * Description : This is made for debugging purpose. This prints out all the elements of list.
         */
        public void printList()
        {
            for (int i = 0; i < 3; i++)
            {
                Debug.Log(list[i][0] + "," + list[i][1] + "," + list[i][2]);
            }
        }


        
    }

    void Start()
    {

    }
    void Update()
    {

    }
}
