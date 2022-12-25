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
    public int WhichHouse { get; private set; }

    private int deliveryCount;
    private PlayerInput input;

    void Start()
    {
        IsInventoryEmpty = true;
        OutputZone.OnPickUp += PickUp;
        InputZone.OnDropDown += DropDown;
        OutputZone.OnDescriptionShow += ViewDescription;
        InputZone.OnDescriptionShow += ViewDescription;
        Sign.OnDescriptionShow += ViewDescription;
        input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        
    }

    public void PickUp(int houseNum)
    {
        inventory.SetActive(true);
        WhichHouse = houseNum;
        IsInventoryEmpty = false;
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
        descriptionPanel.GetDescriptionPanel.SetActive(true);
        descriptionPanel.GetNameText.text = itemData.name;
        descriptionPanel.GetDescriptionText.text = itemData.description;
        input.DeactivateInput();
    }
}
