using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

/* Deck.cs
 * Description: Deck class used to store all the terms within a category and then 
 *              randomly load each one 
 * Public Methods: Deck - Constructor
 *                 Draw - Randomly gets one card from the deck
 *                 NumberOfCards - Returns the number of cards in the deck
 */
namespace Assets.Scripts
{
    public class Deck
    {
        private List<string> cardsList; // List to hold all the cards
        private static System.Random random;   // Ensures that the generator is only created once

        /* Constructor, creates a list from the string array and a random num gen */
        public Deck(string catName)
        {
            cardsList = new List<string>();

            TextAsset file = Resources.Load(catName) as TextAsset; // Loads the text file of the same category name

            cardsList = new List<string>(file.text.Split('\n'));

            random = new System.Random();
        }

        /*
         * "Draws" a card from the deck.
         * Essentially gets a random card and removes it from the list
         * @return: the drawn card
         */
        public string Draw()
        {
            // Will hold card that is randomly selected
            string card = "";
            Debug.Log(cardsList.Count);
            Console.WriteLine(cardsList.Count);
            /* Generate a random index */
            int index = random.Next(cardsList.Count);

            /* Get the string and remove it from that index */
            card = (string)cardsList[index];
            cardsList.RemoveAt(index);

            return card; // Return the card
        }

        /* Returns the number of cards left in the deck */
        public int NumberOfCards()
        {
            return cardsList.Count;
        }
    }
}
