using UnityEngine;

public static class ClickerSave
{
    private const string DAYS_SURVIVED_KEY = "daysSurvivedKey";
    private const string PLAYER_NAME_KEY = "playerNameKey";

    public static void SaveDaysSurvived(int daysSurvived)
    {
        PlayerPrefs.SetInt(DAYS_SURVIVED_KEY, daysSurvived);
        PlayerPrefs.Save();
    }

    public static int GetDaysSurvived()
    {
        return PlayerPrefs.GetInt(DAYS_SURVIVED_KEY,0);
    }

    public static void SavePlayerName(string playerName)
    {
        PlayerPrefs.SetString(PLAYER_NAME_KEY, playerName);
        PlayerPrefs.Save();
    }

    public static string GetPlayerName() 
    {
        return PlayerPrefs.GetString(PLAYER_NAME_KEY, "");
    }

}
