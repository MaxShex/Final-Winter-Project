using UnityEngine;
using UnityEngine.InputSystem;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject prologPanel;
    [SerializeField] PlayerInput playerInput;

    private void Start()
    {
        playerInput.DeactivateInput();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            prologPanel.SetActive(false);
            playerInput.ActivateInput();
        }
    }
}
