namespace Api.Db;

public record Data
{
    public int Id { get; set; }
    public string ? Name { get; set; }
}

public class DataDb
{
    public static List<Data> dataSet = new List<Data>()
    {
        new Data{ Id = 1, Name = "object 1" },
        new Data{ Id = 2, Name = "object 2" },
        new Data{ Id = 3, Name = "object 3" },
        new Data{ Id = 4, Name = "object 4" },
        new Data{ Id = 5, Name = "object 5" }
    };

    public static List<Data> GetData()
    {
        return dataSet;
    }

    public static Data GetData(int iId)
    {
        return dataSet.SingleOrDefault(data => data.Id == iId);
    }

    public static Data CreateData(Data data)
    {
        dataSet.Add(data);
        return data;
    }

    public static Data UpdateData(Data update)
    {
        dataSet = dataSet.Select(data =>
        {
            if(data.Id == update.Id)
            {
                data.Name = update.Name;
            }
            return data;
        }).ToList();
        return update;
    }

    public static void DeleteData(int iId)
    {
        dataSet = dataSet.FindAll(data => data.Id != iId).ToList();
    }
}