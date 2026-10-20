using System.Diagnostics;

namespace Programming_Learning_App;

public interface IProgramParser
{
    public BlockProgram Parse(string text);
}

public class TextProgramParser : IProgramParser 
{
    public BlockProgram Parse(string text) 
    {
        int index = 0;
        string[] textList = text.Split('\n');

        List<ICommand> commands = ParseCommands(textList, ref index, 0);
        return new BlockProgram("Awesome", commands);
    }

    public List<ICommand> ParseCommands(string[] text, ref int index, int minIndentation) 
    {
        List<ICommand> commands = new List<ICommand>();

        while (index < text.Length) 
        {
            int indentation = text[index].Length - text[index].TrimStart().Length;

            if (indentation < minIndentation) 
            {
                break;
            }

            if (string.IsNullOrEmpty(text[index].Trim()))
            {
                index++;
                continue;
            }

            string[] commandsText = text[index].TrimStart().Split(" ");
            index++;

            if (commandsText[0] == "Move")
            {
                commands.Add(new MoveCommand(int.Parse(commandsText[1])));
            }

            else if (commandsText[0] == "Turn")
            {
                TurnDirection direction = TurnDirection.Left;

                if (commandsText[1] == "left")
                {
                    direction = TurnDirection.Left;
                }

                else if (commandsText[1] == "right")
                {
                    direction = TurnDirection.Right;
                }

                commands.Add(new TurnCommand(direction));
            }

            else if (commandsText[0] == "Repeat")
            {
                int count = int.Parse(commandsText[1]);

                List<ICommand> repeatCommands = ParseCommands(text, ref index, indentation + 1);

                commands.Add(new RepeatCommand(count, repeatCommands));
            }
        }
        return commands;
    }
}