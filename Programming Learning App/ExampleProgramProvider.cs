namespace Programming_Learning_App;

public class ExampleProgramProvider
{
    private IProgramParser Parser;
    private Random rand;

    public ExampleProgramProvider(IProgramParser parser)
    {
        Parser = parser;
        rand = new Random();
    }

    public BlockProgram Basic() 
    {
        string fileContent = File.ReadAllText("UserPrograms/Basic.txt");
        return Parser.Parse(fileContent);
    }
    public BlockProgram Advanced()
    {
        string fileContent = File.ReadAllText("UserPrograms/Advanced.txt");
        return Parser.Parse(fileContent);
    }
    public BlockProgram Expert()
    {
        string fileContent = File.ReadAllText("UserPrograms/Expert.txt");
        return Parser.Parse(fileContent);
    }
    public BlockProgram Random()
    {
        switch (rand.Next(3))
        {
            case 0:
                return Basic();
            case 1:
                return Advanced();
            default:
                return Expert();
        }
    }
}