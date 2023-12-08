public class Room
{
    public int Id { get; set; }
    public int Number { get; set; }
    public int Floor { get; set; }
}

public class Cabinet : Room
{
    public Staff owner { get; set; }
}

public class Ward : Room
{
    public int Number { get; set; }
    public int PatientCapacity { get; set; }
    public bool IsReanimation { get; set; }
}