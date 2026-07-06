using UnityEngine;
using System.Collections.Generic;

namespace Consystently 
{
  using Essentials;
  
  namespace Inventories
  {
    public class Catalog : Singleton<Catalog>
    {
      //private List<string> idCombinations
      [Tooltip("The database containing every item that exists in your project.")]
      [SerializeField] private List<ItemData> itemDatabase = new List<ItemData>();

      /// <summary>
      /// The database containing every item that exists.
      /// </summary>
      public List<ItemData> ItemDatabase => itemDatabase;

      protected override void Awake()
      {
        base.Awake();
        RemoveDuplicates();
      }

      /// <summary>
      /// Checks each item in the database if both its name and serial number are unique to it.
      /// </summary>
      private void RemoveDuplicates()
      {
        HashSet<string> uniqueNames = new HashSet<string>();
        HashSet<string> uniqueSerialNumbers = new HashSet<string>();
        List<ItemData> uniqueItems = new List<ItemData>();

        foreach (ItemData item in itemDatabase)
        {
          // Check if either the name or the serial number is unique
          if (!uniqueNames.Contains(item.ItemName) && !uniqueSerialNumbers.Contains(item.SerialNumber))
          {
            uniqueNames.Add(item.ItemName);
            uniqueSerialNumbers.Add(item.SerialNumber);
            uniqueItems.Add(item);
          }
        }

        itemDatabase = uniqueItems;
      }

      /// <summary>
      /// Returns the item with the specified serial number in the catalog. Returns null if no such serial number is active.
      /// </summary>
      /// <param name="serialNumber">The item's serial number.</param>
      /// <returns>An item from the catalog</returns>
      public ItemData GetItemBySerialNumber(string serialNumber)
      {
        ItemData itemToGet = itemDatabase.Find(item => serialNumber == item.SerialNumber);

        if (itemToGet != null)
          return itemToGet;
        else
          return null;
      }

      /// <summary>
      /// Returns the item with the specified name in the catalog. Returns null if no such item name exists.
      /// </summary>
      /// <param name="itemName">The item's name.</param>
      /// <returns>An item from the catalog.</returns>
      public ItemData GetItemByName(string itemName)
      {
        ItemData itemToGet = itemDatabase.Find(item => item.ItemName == itemName);

        if (itemToGet != null)
          return itemToGet;
        else
          return null;
      }

      /// <summary>
      /// Creates an instance of the item with the specified name in the catalog. Returns null if no such serial number is active.
      /// </summary>
      /// <param name="serialNumber">The item's serial number.</param>
      /// <returns>An item object instance.</returns>
      public ItemData CreateItemFromSerialNumber(string serialNumber)
      {
        ItemData itemToCreate = itemDatabase.Find(item => item.SerialNumber == serialNumber);

        if (itemToCreate == null)
          return null;

        Debug.Log("Item of the serial number '" + itemToCreate.SerialNumber + "' created.");
        return Instantiate(itemToCreate);
      }

      /// <summary>
      /// Creates an instance of the item with the specified name in the catalog. Returns null if no such item name exists.
      /// </summary>
      /// <param name="itemName">The item's name.</param>
      /// <returns>An item object instance.</returns>
      public ItemData CreateItemFromName(string itemName)
      {
        ItemData itemToCreate = itemDatabase.Find(item => item.ItemName == itemName);

        if (itemToCreate == null)
          return null;

        Debug.Log("Item of the name '" + itemToCreate.ItemName + "' created.");
        return Instantiate(itemToCreate);
      }

      /// <summary>
      /// Creates an instance of a random item in the catalog.
      /// </summary>
      /// <returns>A random item object instance.</returns>
      public ItemData CreateRandomItem()
      {
        int index = Random.Range(0, itemDatabase.Count);
        ItemData itemToCreate = itemDatabase[index];

        return Instantiate(itemToCreate);
      }
    }
  }
}