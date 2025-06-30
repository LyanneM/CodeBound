using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<string> collectedParts = new List<string>();
    public Text inventoryText; // Assign this in Inspector

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddPart(string partName)
    {
        if (!collectedParts.Contains(partName))
        {
            collectedParts.Add(partName);
            UpdateInventoryUI();
        }
    }

    void UpdateInventoryUI()
    {
        inventoryText.text = "Parts Collected:\n";
        foreach (string part in collectedParts)
        {
            inventoryText.text += "• " + part + "\n";
        }
    }
}
