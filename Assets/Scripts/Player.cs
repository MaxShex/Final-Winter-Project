using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] TextMeshProUGUI counterText;
    [SerializeField] DescriptionPanel descriptionPanel;

    public bool IsInventoryEmpty { get; private set; }

    private int deliveryCount;
    private PlayerInput input;


    void Start()
    {
        IsInventoryEmpty = true;
        OutputZone.OnPickUp += PickUp;
        InputZone.OnDropDown += DropDown;
        OutputZone.OnDescriptionShow += ViewDescription;
        input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        
    }

    public void PickUp()
    {
        inventory.SetActive(true);
        descriptionPanel.GetDescriptionPanel.SetActive(true);
        IsInventoryEmpty = false;
        input.DeactivateInput();
    }

    public void DropDown()
    {
        deliveryCount++;
        IsInventoryEmpty = true;
        counterText.text = $"{deliveryCount}";
        inventory.SetActive(false);
    }

    public void ViewDescription(ItemData itemData)
    {
        descriptionPanel.GetNameText.text = itemData.name;
        descriptionPanel.GetDescriptionText.text = itemData.description;
    }
}