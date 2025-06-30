using UnityEngine;

public class ComputerPart : MonoBehaviour
{
    public string partName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.instance.AddPart(partName);
            Destroy(gameObject);
        }
    }
}
