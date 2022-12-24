using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DescriptionPanel : MonoBehaviour
{
    [SerializeField] private GameObject descriptionPanel;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private PlayerInput input;

    public GameObject GetDescriptionPanel => descriptionPanel;
    public TextMeshProUGUI GetNameText => nameText;
    public TextMeshProUGUI GetDescriptionText => descriptionText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            descriptionPanel.SetActive(false);
            input.ActivateInput();
        }
    }
}
