using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AzureServicesForUnity.Shared;

public class ScoreContainer : TableEntity
{
    public int Protein;
    public int Carbs;
    public int Vegetables;
    public int Dairy;
    public int OilsAndFats;

    public ScoreContainer(string partitionKey, string rowKey)
    : base(partitionKey, rowKey) {  }

    public ScoreContainer() : base() 
    {
        PartitionKey = TableStorageClient.Instance.CurrentUser.PartitionKey;
        RowKey = TableStorageClient.Instance.CurrentUser.SchoolAndClass;
    }

    public void MoveToScoreContainer(Dictionary<string, object> ingredientTracker)
    {
        this.Carbs = (int)ingredientTracker[Category.Carb.ToString()];
        this.Protein = (int)ingredientTracker[Category.Protein.ToString()];
        this.Dairy = (int)ingredientTracker[Category.Dairy.ToString()];
        this.Vegetables = (int)ingredientTracker[Category.Vege.ToString()];
        this.OilsAndFats = (int)ingredientTracker[Category.OilsAndFats.ToString()];
    }

    public void EmptyContainer()
    {
        this.Carbs = 0;
        this.Protein = 0;
        this.Dairy = 0;
        this.Vegetables = 0;
        this.OilsAndFats = 0;
    }
}

public class Score
{
    private Dictionary<string, object> ingredientTracker = new Dictionary<string, object>();
    public Dictionary<string, object> IngredientTracker => ingredientTracker;

    private ScoreContainer container = new ScoreContainer();

    public Score()
    {
        Initialize();
    }

    public void Initialize()
    {
        for (int i = 0; i < Enum.GetValues(typeof(Category)).Length; i++)
        {
            ingredientTracker.Add(Enum.GetName(typeof(Category), i), 0);
        }
    }

    public void AddScore(Ingredient ID)
    {
        ingredientTracker.TryGetValue(ID.Category.ToString(), out object tempScore);
        ingredientTracker[ID.Category.ToString()] = (int)tempScore + 1;
    }

    public void UpdateScoreToDatabase(Score thisScore)
    {
        //Debug.Log(ingredientTracker[Category.Protein.ToString()]);
        //Debug.Log(ingredientTracker[Category.Carb.ToString()]);
        //Debug.Log(ingredientTracker[Category.Dairy.ToString()]);
        //Debug.Log(ingredientTracker[Category.Vege.ToString()]);

        //TableStorageClient client = TableStorageClient.Instance;

        //container.MoveToScoreContainer(ingredientTracker);
        //client.UpdateEntity(container, client.CurrentUser.SchoolAndClass, updateEntityResponse =>
        //{
        //    if (updateEntityResponse.Status == CallBackResult.Success)
        //    {
        //        string result = "UpdateEntity completed";
        //        Debug.Log(result);
        //    }
        //    else
        //    {
        //        Debug.Log("Error");
        //    }
        //});
        //container.EmptyContainer();
    }

}
