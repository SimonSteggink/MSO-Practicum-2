namespace Programming_Learning_App;

public interface IProgramParser
{
    public BlockProgram Parse(string text);
}

public class TextProgramParser : IProgramParser 
{
    public BlockProgram Parse(string text) 
    {

    }
}