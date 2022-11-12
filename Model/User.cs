namespace WpfApp_Klimchenya.Model;

public class User
{
    private string fio;
   
    public string Fio
    {
        get { return fio; }
        set { fio = value; }
    }

    public User(string fio)
    {
        this.fio = fio;
    }

    public User()
    {
            
    }

}