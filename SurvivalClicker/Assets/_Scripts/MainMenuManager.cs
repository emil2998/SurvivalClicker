using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private LifeCycleManager lifeCycleManager;

    [Header("Panels")] [SerializeField]
    private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject winGamePanel;
    [SerializeField] private GameObject loseGamePanel;

    [SerializeField] private GameObject gamePanel;

    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Text volumeText;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        lifeCycleManager = GetComponent<LifeCycleManager>();
    }
    private void Start()
    {
        InitializePanels();
    }
    private void Update()
    {
        if (lifeCycleManager.isGameWon)
        {
            GameWonPanel();
        }
        if (lifeCycleManager.isGameLost)
        {
            GameLosePanel();
        }
    }

    private void GameWonPanel()
    {
        gamePanel.SetActive(false);
        winGamePanel.SetActive(true);
    }
    private void GameLosePanel()
    {
        gamePanel.SetActive(false);
        loseGamePanel.SetActive(true);
    }
    private void InitializePanels()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        gamePanel.SetActive(false);
    }

    public void PlayGame()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameManager.InitializeGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OptionsButton()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void MainMenuButton()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        gamePanel.SetActive(false);
    }

    public void OnVolumeChanged()
    {
        volumeText.text = $"{volumeSlider.value * 100}%";
    }
}
