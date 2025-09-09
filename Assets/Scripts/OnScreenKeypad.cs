using UnityEngine;
using UnityEngine.UI;

public class OnScreenKeypad : MonoBehaviour
{
    [Header("Keypad Buttons")]
    public Button[] digitButtons = new Button[24]; // 0-9
    public Button submitButton;
    public Button backspaceButton;
    
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        SetupButtons();
    }

    void SetupButtons()
    {
        // Setup digit buttons
        for (int i = 0; i < digitButtons.Length; i++)
        {
            int digit = i; // Capture for closure
            digitButtons[i].onClick.AddListener(() => gameManager.OnDigitPressed(digit));
        }
        
        // Setup action buttons
        submitButton.onClick.AddListener(() => gameManager.OnSubmit());
        backspaceButton.onClick.AddListener(() => gameManager.OnBackspace());
    }
}
