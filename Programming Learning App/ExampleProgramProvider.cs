namespace Programming_Learning_App;

public class ExampleProgramProvider
{
    private IProgramParser Parser;
    private Random rand;

    public ExampleProgramProvider(IProgramParser parser)
    {
        Parser = parser;
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
        string fileContent = File.ReadAllText("UserPrograms/Advanced.txt");

        switch (rand.Next(2)) 
        {
            case 0:
                fileContent = File.ReadAllText("UserPrograms/Basic.txt");
                break;
            case 1:
                fileContent = File.ReadAllText("UserPrograms/Advanced.txt");
                break;
            case 2:
                fileContent = File.ReadAllText("UserPrograms/Expert.txt");
                break;
        }

        return Parser.Parse(fileContent);
    }
}