namespace WpfApp_Klimchenya.Model;

public class DayStatistics
{
    private int steps;
    private string status;
    private int rank;

    public int Steps
    {
        get { return steps; }
        set { steps = value; }
    }
    public string Status
    {
        get { return status; }
        set { status = value; }
    }
    public int Rank
    {
        get { return rank; }
        set { rank = value; }
    }

    public DayStatistics()
    {
            
    }
}