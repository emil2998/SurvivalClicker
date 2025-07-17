using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
    [Header("Resources Text")]
    [SerializeField]
    private TMP_Text daysText;
    [SerializeField] private TMP_Text poopulationText;
    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text foodText;
    [SerializeField] private TMP_Text ironText;

    [Header("Building text")]
    [SerializeField]
    private TMP_Text houseText;
    [SerializeField] private TMP_Text farmText;
    [SerializeField] private TMP_Text woodcutterText;

    [SerializeField] private TMP_Text notificationText;

    [Header("Win/Lose text")]
    [SerializeField] private TMP_Text daysSurvivedWinPanelText;
    [SerializeField] private TMP_Text daysSurvivedLosePanelText;
    [SerializeField] private TMP_Text playerNameWinPanelText;
    [SerializeField] private TMP_Text playerNameLosePanelText;
    [SerializeField] private TMP_InputField playerNameLoseInput;
    [SerializeField] private TMP_InputField playerNameWinInput;

    private void Awake()
    {
        notificationText.text = "";
        playerNameWinInput.onEndEdit.AddListener(SavePlayerName);
        playerNameLoseInput.onEndEdit.AddListener(SavePlayerName);
     
    }

    public void UpdateText(int days, int currentPopulation, int maxPopulation, int workers, int unemployed, int food, int wood, int iron, int farm, int house, int woodcutter)
    {
        daysText.text = days.ToString();
        //resources
        if (unemployed <= 0) { unemployed = 0; }
        poopulationText.text = $"{currentPopulation}/{maxPopulation}\n    Workers:{workers}\n     Unemployed:{unemployed}";
        foodText.text = $"{food}";
        woodText.text = wood.ToString();
        ironText.text = $"Iron: {iron}";

        //Buildings
        farmText.text = $"Farm: {farm}";
        houseText.text = $"House: {house}";
        woodcutterText.text = $"Wood Cutter: {woodcutter}";
    }

    public void UpdateEndGameTexts()
    {
        Time.timeScale = 0f;
        daysSurvivedLosePanelText.text = "You survived " + ClickerSave.GetDaysSurvived().ToString() + " days!";
        daysSurvivedWinPanelText.text = "You survived " + ClickerSave.GetDaysSurvived().ToString() + " days!";
    }

    private void SavePlayerName(string name)
    {
        playerNameLoseInput.readOnly = true;
        playerNameWinInput.readOnly = true;
        ClickerSave.SavePlayerName(name);
        UpdateEndGameTextPlayerName();
    }

    public void UpdateEndGameTextPlayerName()
    {
        string playerName = ClickerSave.GetPlayerName();
        playerNameLosePanelText.text = playerName + " , you have lost the game!";
        playerNameWinPanelText.text = playerName + " , you have won the game!";
    }


    public IEnumerator NotificationText(string text)
    {
        notificationText.text = text;
        yield return new WaitForSeconds(2);
        notificationText.text = String.Empty;
    }
}
