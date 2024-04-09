using System.Collections.Generic;
using System.Data;
using Database;
using UnityEngine;

public class DatabaseReader : MonoBehaviour
{
    public static List<string> itemsID;
    public static List<int> itemsRarity;
    private void Start()
    {
        itemsID = new List<string>();
        itemsRarity = new List<int>();
        DataTable ItemsDatabase = MyDataBase.GetTable("SELECT * FROM Items;");
        for (int i = 0; i < ItemsDatabase.Rows.Count; i++)
        {
            string ItemID = ItemsDatabase.Rows[i][1].ToString();
            int Rarity = int.Parse(ItemsDatabase.Rows[i][2].ToString());
            itemsID.Add(ItemID);
            itemsRarity.Add(Rarity);
        }
    }
}
