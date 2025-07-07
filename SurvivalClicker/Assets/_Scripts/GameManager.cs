using UnityEngine;


public class GameManager : MonoBehaviour
{

    public bool isGameRunning = false;

    private InGameUIManager inGameUIManager;
    private LifeCycleManager gameLifeCycle;
    private ResourcesManager resourcesManager;
    


    private void Awake()
    {
        inGameUIManager = GetComponent<InGameUIManager>();
        gameLifeCycle = GetComponent<LifeCycleManager>();
        resourcesManager = GetComponent<ResourcesManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Time.timeScale = 4f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Time.timeScale = 8f;    
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Time.timeScale = 16f;
        }
        // one minute is one day
        gameLifeCycle.TimeOfDay();
    }

    public void InitializeGame()
    {
        isGameRunning = true;
        inGameUIManager.UpdateText(gameLifeCycle.Days, resourcesManager.Poopulation(), resourcesManager.GetMaxPoopulation(), resourcesManager.Workers, resourcesManager.Unemployed, resourcesManager.Food, resourcesManager.Wood, resourcesManager.Iron, resourcesManager.Farm, resourcesManager.House, resourcesManager.Woodcutter);
    }




    private void WorkerAssign(int amount)
    {
        resourcesManager.Unemployed -= amount;
        resourcesManager.Workers += amount;
    }

    private bool CanAssignWorker(int amount)
    {
        return resourcesManager.Unemployed >= amount;
    }

    public void BuildHouse()
    {
        if (resourcesManager.Wood >= 2)
        {
            resourcesManager.Wood -= 2;
            resourcesManager.House++;
            inGameUIManager.UpdateText(gameLifeCycle.Days, resourcesManager.Poopulation(), resourcesManager.GetMaxPoopulation(), resourcesManager.Workers, resourcesManager.Unemployed, resourcesManager.Food, resourcesManager.Wood, resourcesManager.Iron, resourcesManager.Farm, resourcesManager.House, resourcesManager.Woodcutter);
        }
        else
        {
            string text = $"You need {2 - resourcesManager.Wood} more wood";
            StartCoroutine(inGameUIManager.NotificationText(text));
        }
    }

    public void BuildFarm()
    {
        // izgradi se farma
        if (resourcesManager.Wood >= 10 && CanAssignWorker(2))
        {
            resourcesManager.Wood -= 10;
            resourcesManager.Farm++;
            WorkerAssign(2);
            inGameUIManager.UpdateText(gameLifeCycle.Days, resourcesManager.Poopulation(), resourcesManager.GetMaxPoopulation(), resourcesManager.Workers, resourcesManager.Unemployed, resourcesManager.Food, resourcesManager.Wood, resourcesManager.Iron, resourcesManager.Farm, resourcesManager.House, resourcesManager.Woodcutter);
        }

        else
        {
            int neededWoodAmount = 0, neededUnemployedAmount = 0;
            if (10 - resourcesManager.Wood < 0)
            {
                neededWoodAmount = 0;
            }
            else
            {
                neededWoodAmount = 10 - resourcesManager.Wood;
            }
            if (2 - resourcesManager.Unemployed < 0)
            {
                neededUnemployedAmount = 0;
            }
            else
            {
                neededUnemployedAmount = 2 - resourcesManager.Unemployed;
            }
            string text = $"You need more {neededWoodAmount} wood  or {neededUnemployedAmount} people";
            // string text = $"You need more {10 - wood} wood  or {2 - unemployed} people";
            StartCoroutine(inGameUIManager.NotificationText(text));
        }
    }

    public void BuildWoodCutter()
    {
        if (resourcesManager.Wood >= 5 && resourcesManager.Iron > 0 && CanAssignWorker(1))
        {
            resourcesManager.Iron--;
            resourcesManager.Wood -= 5;
            WorkerAssign(1);
            resourcesManager.Woodcutter++;
            inGameUIManager.UpdateText(gameLifeCycle.Days, resourcesManager.Poopulation(), resourcesManager.GetMaxPoopulation(), resourcesManager.Workers, resourcesManager.Unemployed, resourcesManager.Food, resourcesManager.Wood, resourcesManager.Iron, resourcesManager.Farm, resourcesManager.House, resourcesManager.Woodcutter);
            string text = $"You have built wood cutters hut";
            StartCoroutine(inGameUIManager.NotificationText(text));
        }
        else
        {

            int neededWoodAmount = 0, neededIronAmount = 0, neededUnemployedAmount = 0;
            if (5 - resourcesManager.Wood < 0)
            {
                neededWoodAmount = 0;
            }
            else
            {
                neededWoodAmount = 5 - resourcesManager.Wood;
            }

            if (1 - resourcesManager.Iron < 0)
            {
                neededIronAmount = 0;
            }
            else
            {
                neededIronAmount = 1 - resourcesManager.Iron;
            }
            if (1 - resourcesManager.Unemployed < 0)
            {
                neededUnemployedAmount = 0;
            }
            else
            {
                neededUnemployedAmount = 1 - resourcesManager.Unemployed;
            }


            string text = $"You need more {neededWoodAmount} wood or {neededIronAmount} iron or {neededUnemployedAmount} people";
            //string text = $"You need more {5 - wood} wood or {1 - iron} iron or {1 - unemployed} people";

            StartCoroutine(inGameUIManager.NotificationText(text));
        }

    }





}
