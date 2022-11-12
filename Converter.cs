using System.Collections.Generic;
using System.Collections.ObjectModel;
using LiveCharts;
using WpfApp_Klimchenya.Model;

namespace WpfApp_Klimchenya;

public static class Converter
{
    public static Dictionary<string, UserStatistics> ListToDictionary(List<Record> records)
    {
        var result = new Dictionary<string, UserStatistics>();
        foreach (var record in records)
        {
            if (result.ContainsKey(record.User))
            {
                var user = RecordToUserStatistics(record);
                result[record.User].DaysList.Add(user.DaysList[0]);
            }
            else
            {
                result.Add(record.User, RecordToUserStatistics(record));
            }
            
        }

        return result;
    }

    public static UserStatistics RecordToUserStatistics(Record record)
    {
        var userStat = new UserStatistics();
        var user = new User();
        var dayStat = new DayStatistics();

        user.Fio = record.User;
        dayStat.Rank = record.Rank;
        dayStat.Status = record.Status;
        dayStat.Steps = record.Steps;

        userStat.User = user; 
        userStat.AddToList(dayStat);

        return userStat;
    }

    public static ObservableCollection<UserStatistics> DictionaryTObservableCollection(Dictionary<string, UserStatistics> dictionary)
    {
        foreach (var user in dictionary)
        {
            user.Value.CountAllInfoSteps();
        }
        return  new ObservableCollection<UserStatistics>(dictionary.Values);
    }

    public static ChartValues<double> ListToChartValues(List<DayStatistics> list)
    {
        ChartValues<double> values = new ChartValues<double>();
        foreach (var day in list)
        {
            values.Add((double)day.Steps);
        }

        return values;
    }
}