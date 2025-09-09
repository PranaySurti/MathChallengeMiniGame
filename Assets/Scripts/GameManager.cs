using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public enum GameState { Menu, Gameplay, End }

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject menuPanel;
    public GameObject gameplayPanel;
    public GameObject endPanel;
    
    [Header("Menu UI")]
    public Button additionButton;
    public Button subtractionButton;
    
    [Header("Gameplay UI")]
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI inputText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public Image timerBar;
    
    [Header("End UI")]
    public TextMeshProUGUI finalScoreText;
    public Button restartButton;
    public Button menuButton;
    
    [Header("Game Settings")]
    public float timePerQuestion = 15f;
    public int maxLives = 3;
    
    // Game State
    private GameState currentState;
    private bool isAdditionMode = true;
    private int score = 0;
    private int lives = 3;
    private int correctAnswer = 0;
    private string currentInput = "";
    private Coroutine timerCoroutine;
    
    // Input System
    private GameInputActions inputActions;

    void Awake()
    {
        inputActions = new GameInputActions();
    }

    void Start()
    {
        SetupUI();
        SetState(GameState.Menu);
    }

    void SetupUI()
    {
        // Menu buttons
        additionButton.onClick.AddListener(() => StartGame(true));
        subtractionButton.onClick.AddListener(() => StartGame(false));
        
        // End buttons
        restartButton.onClick.AddListener(RestartGame);
        menuButton.onClick.AddListener(ReturnToMenu);
    }

    void OnEnable()
    {
        inputActions.Enable();
        
        // Subscribe to input events
        inputActions.Gameplay.Digit1.performed += ctx => OnDigitPressed(1);
        inputActions.Gameplay.Digit2.performed += ctx => OnDigitPressed(2);
        inputActions.Gameplay.Digit3.performed += ctx => OnDigitPressed(3);
        inputActions.Gameplay.Digit4.performed += ctx => OnDigitPressed(4);
        inputActions.Gameplay.Digit5.performed += ctx => OnDigitPressed(5);
        inputActions.Gameplay.Digit6.performed += ctx => OnDigitPressed(6);
        inputActions.Gameplay.Digit7.performed += ctx => OnDigitPressed(7);
        inputActions.Gameplay.Digit8.performed += ctx => OnDigitPressed(8);
        inputActions.Gameplay.Digit9.performed += ctx => OnDigitPressed(9);
        inputActions.Gameplay.Digit0.performed += ctx => OnDigitPressed(0);
        inputActions.Gameplay.Submit.performed += ctx => OnSubmit();
        inputActions.Gameplay.Backspace.performed += ctx => OnBackspace();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    public void StartGame(bool additionMode)
    {
        isAdditionMode = additionMode;
        score = 0;
        lives = maxLives;
        SetState(GameState.Gameplay);
        GenerateNewQuestion();
        UpdateUI();
    }

    void GenerateNewQuestion()
    {
        var (question, answer) = EquationGenerator.GenerateEquation(isAdditionMode);
        questionText.text = question;
        correctAnswer = answer;
        currentInput = "";
        inputText.text = "";
        
        StartQuestionTimer();
    }

    void StartQuestionTimer()
    {
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);
            
        timerCoroutine = StartCoroutine(QuestionTimer());
    }

    IEnumerator QuestionTimer()
    {
        float timeLeft = timePerQuestion;
        
        while (timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / timePerQuestion;
            yield return null;
        }
        
        // Time's up!
        OnTimeOut();
    }

    void OnTimeOut()
    {
        lives--;
        if (lives <= 0)
        {
            EndGame();
        }
        else
        {
            GenerateNewQuestion();
            UpdateUI();
        }
    }

    public void OnDigitPressed(int digit)
    {
        if (currentState != GameState.Gameplay) return;
        
        currentInput += digit.ToString();
        inputText.text = currentInput;
    }

    public void OnSubmit()
    {
        if (currentState != GameState.Gameplay || string.IsNullOrEmpty(currentInput)) 
            return;

        if (int.TryParse(currentInput, out int playerAnswer))
        {
            if (playerAnswer == correctAnswer)
            {
                score++;
                GenerateNewQuestion();
            }
            else
            {
                lives--;
                if (lives <= 0)
                {
                    EndGame();
                }
                else
                {
                    GenerateNewQuestion();
                }
            }
            UpdateUI();
        }
    }

    public void OnBackspace()
    {
        if (currentState != GameState.Gameplay || currentInput.Length == 0) 
            return;
            
        currentInput = currentInput[..^1];
        inputText.text = currentInput;
    }

    public void OnClear()
    {
        if (currentState != GameState.Gameplay) return;
        
        currentInput = "";
        inputText.text = "";
    }

    void UpdateUI()
    {
        scoreText.text = $"Score: {score}";
        livesText.text = $"Lives: {lives}";
    }

    void EndGame()
    {
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);
            
        finalScoreText.text = $"Final Score: {score}";
        SetState(GameState.End);
    }

    void RestartGame()
    {
        StartGame(isAdditionMode);
    }

    void ReturnToMenu()
    {
        SetState(GameState.Menu);
    }

    void SetState(GameState newState)
    {
        currentState = newState;
        
        menuPanel.SetActive(newState == GameState.Menu);
        gameplayPanel.SetActive(newState == GameState.Gameplay);
        endPanel.SetActive(newState == GameState.End);
    }
}
