using UnityEngine;
using UnityEngine.UI;

public class LifeCycleManager : MonoBehaviour
{

    public int Days { get; private set; }
    [SerializeField] private Image dayImage;

    public int populationWinCondition;
    public bool isGameWon = false;
    public bool isGameLost = false;

    private float timer;

    private GameManager gameManager;
    private InGameUIManager inGameUIManager;
    private ResourcesManager resourcesManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        inGameUIManager = GetComponent<InGameUIManager>();
        resourcesManager = GetComponent<ResourcesManager>();
    }
    public void TimeOfDay()
    {
        if (!gameManager.isGameRunning)
        {
            return;
        }
        timer += Time.deltaTime;
        dayImage.fillAmount = timer / 60;
        if (timer >= 60)
        {
            Days++;
            resourcesManager.FoodGathering();
            resourcesManager.FoodProduction();
            resourcesManager.WoodProduction();
            resourcesManager.FoodConsumption(1);
            resourcesManager.IncreasePoopulation();

            if(resourcesManager.Poopulation() >= populationWinCondition)
            {
               isGameWon=true;
                //ZADACA SA SAVE SYSTEMOM
                Time.timeScale = 0f;
                ClickerSave.SaveDaysSurvived(Days);

            }
            if (resourcesManager.Poopulation() <= 0)
            {
                isGameLost = true;
                Time.timeScale = 0f;
                ClickerSave.SaveDaysSurvived(Days);

            }
            if (Days == 30 && (resourcesManager.Poopulation() < populationWinCondition))
            {
                isGameLost=true;
                Time.timeScale = 0f;
                ClickerSave.SaveDaysSurvived(Days);
          
            }
            inGameUIManager.UpdateText(Days, resourcesManager.Poopulation(), resourcesManager.GetMaxPoopulation(), resourcesManager.Workers, resourcesManager.Unemployed, resourcesManager.Food, resourcesManager.Wood, resourcesManager.Iron, resourcesManager.Farm, resourcesManager.House, resourcesManager.Woodcutter);

            timer = 0;
        }
    }

}
