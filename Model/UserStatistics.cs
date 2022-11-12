using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WpfApp_Klimchenya.Model;

public class UserStatistics 
{
    [JsonProperty("Name")]
    public User User { get; set; }

    
    public List<DayStatistics> DaysList { get; set; }
    [JsonIgnore]
    public PointShapeLineExample PointShapeLine { get; set; }

    public double AvgSteps { get; set; }
    public int BestSteps { get; set; }
    public int WorstSteps { get; set; }
    public int TotalSteps { get; set; }

    public UserStatistics()
    {
        DaysList = new List<DayStatistics>(31);
    }

    public void AddToList(DayStatistics valueDayStatistics)
    {
        if (DaysList.Count != 31)
        {
            DaysList.Add(valueDayStatistics);
        }
    }
    public void CountAllInfoSteps()
    {
        CountTotalSteps();
        CountWorstSteps();
        CountBestSteps();
        CountAvgSteps();
    }
    public void CountTotalSteps()
    {
        int count = 0;
        foreach (var day in DaysList)
        {
            count += day.Steps;
        }

        TotalSteps = count;
    }
    public void CountAvgSteps()
    {
        AvgSteps = TotalSteps / 30;
    }
    public void CountBestSteps()
    {
        int best = 0;
        foreach (var day in DaysList)
        {
            if (day.Steps > best)
            {
                best = day.Steps;
            }
        }
        BestSteps = best;
    }
    public void CountWorstSteps()
    {
        int worst = Int32.MaxValue;
        foreach (var day in DaysList)
        {
            if (day.Steps < worst)
            {
                worst = day.Steps;
            }
        }
        WorstSteps = worst;
    }


    public void CreateGraph()
    {
        PointShapeLine = new PointShapeLineExample(DaysList);
    }

    

  
}