using System;
using System.Collections.Generic;
using System.Text;

namespace ArtefactDungeon
{
    public class Inventory
    {
        public List<Item> itemList = new List<Item>();
        public void ShowItems() // Function to show the player items he owns
        {
            Console.WriteLine("Inventory: ");
            for (int i = 0; i < itemList.Count; i++) // Looping through items list
            {
                Console.WriteLine("Item: " + itemList[i].itemName);
            }
        }
    }
}
