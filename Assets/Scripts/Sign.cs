using System;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public static Action<ItemData> OnDescriptionShow;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            OnDescriptionShow?.Invoke(GetComponent<Item>().GetItemData);
        }
    }
}
