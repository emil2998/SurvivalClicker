using UnityEngine;

public class SaveSystemBasic
{
    private const string NAME_KEY = "nameKey";
    private const string AGE_KEY = "ageKey";
    private const string WEIGHT_KEY = "weightKey";

    PersonData person = new();
    public SaveSystemBasic() {
      
        person.Name = "Emil";
        person.Age = 26;
        person.Weight = 118.8f;
        SavePersonName();
        SavePersonAge();
        SavePersonWeight();
    }
   

    public void SavePersonName()
    {
        PlayerPrefs.SetString(NAME_KEY, person.Name);
        PlayerPrefs.Save();
    }
    public void SavePersonAge()
    {
        PlayerPrefs.SetInt(AGE_KEY, person.Age);
        PlayerPrefs.Save();
    }
    public void SavePersonWeight()
    {
        PlayerPrefs.SetFloat(WEIGHT_KEY, person.Weight);
        PlayerPrefs.Save();
    }


    public string GetPersonName()
    {
        return PlayerPrefs.GetString(NAME_KEY,"");
    }
    public  int GetPersonAge()
    {
        return PlayerPrefs.GetInt(AGE_KEY, 0);       
    }
    public float GetPersonWeight()
    {   
       return PlayerPrefs.GetFloat(WEIGHT_KEY, 0f);
    }
}
