using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public int Workers { get; set; }
    public int Unemployed { get; set; }
    public int Wood { get; set; }
    public int Food { get; private set; }
    public int Iron { get; set; }
    public int Farm { get; set; }
    public int Woodcutter { get; set; }
    public int House { get; set; }

    //TODO
     private int tools;
     private int stone;
     private int gold;
     private int blacksmith;
     private int quarry;
     private int ironMines;
     private int goldMines;

    private LifeCycleManager gameLifeCycle;

    private void Awake()
    {
        gameLifeCycle = GetComponent<LifeCycleManager>();
        Unemployed = 20;
        Wood = 10;
        Iron = 5;
        Food = 60;
    }

    public void FoodConsumption(int foodConsumed)
    {
        Food -= foodConsumed * Poopulation();
        if (Food < 0)
        {
            Unemployed += Food;
            Food = 0;
        }
    }

    public void FoodGathering()
    {
        Food += Unemployed / 2;
    }

    public void FoodProduction()
    {
        Food += Farm * 4;
    }
    public void WoodProduction()
    {
        Wood += Woodcutter * 2;
    }

    public void IncreasePoopulation()
    {
        if (gameLifeCycle.Days % 2 == 0)
        {
            if (GetMaxPoopulation() > Poopulation())
            {
                Unemployed += House;
                if (GetMaxPoopulation() < Poopulation())
                {
                    Unemployed = GetMaxPoopulation() - Workers;
                }
            }
        }
    }


    public int Poopulation()
    {
        return Workers + Unemployed;
    }



    // number of max house * 4 
    public int GetMaxPoopulation()
    {
        int maxPoopulation = House * 4;
        return maxPoopulation;
    }

    //TODO: Make this method a class
    /*
    private void BuildCost(int woodCost, int stoneCost, int workerAssign)
    {
        if (Wood >= woodCost && stone >= stoneCost && Unemployed >= workerAssign)
        {
            Wood -= woodCost;
            stone -= stoneCost;
            Unemployed -= workerAssign;
            Workers += workerAssign;
        }
    }
    */
}
