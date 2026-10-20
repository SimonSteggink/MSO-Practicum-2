namespace Programming_Learning_App;

public class ExecutionContext
{
    public Character Character { get; }
    public List<string> Trace { get; }

    public ExecutionContext()
    {
        Character = new Character();
        Trace = new List<string>();
    }
}
