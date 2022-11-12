using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using WpfApp_Klimchenya.Model;

namespace WpfApp_Klimchenya;

public static class IO
{
    public static Dictionary<string, UserStatistics> ReadFiles()
    {
        Dictionary<string, UserStatistics> statisticsMap = null;
        List<Record> records = new List<Record>();
        List<Record> totalList = new List<Record>();
        for (int i = 1; i <= 30; i++)
        {
            using (StreamReader r = new StreamReader($"TestData/day{i}.json"))
            {
                string jsonReadToEnd = r.ReadToEnd();
                records = JsonConvert.DeserializeObject<List<Record>>(jsonReadToEnd);
            }

            totalList.AddRange(records);
        }
        statisticsMap = Converter.ListToDictionary(totalList);

        return statisticsMap;
    }

    public static void WriteFile(UserStatistics userStatistics)
    {
        using (StreamWriter sw = new StreamWriter($"{userStatistics.User.Fio}.json"))
        {
            string resultSerializeObject = JsonConvert.SerializeObject(userStatistics);
            sw.Write(resultSerializeObject);
        }
    }
}