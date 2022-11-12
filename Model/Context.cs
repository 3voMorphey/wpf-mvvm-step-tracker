

using System.Collections.Generic;
using System.Data;

namespace WpfApp_Klimchenya.Model;

public class Context
{
    private Dictionary<string, UserStatistics> statistics;

    public Dictionary<string, UserStatistics> Statistics
    {
        get { return statistics;}
        set { statistics = value;}
    }

    public Context()
    {
        Statistics = IO.ReadFiles();
    }
}

