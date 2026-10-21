namespace Programming_Learning_App;


public struct ProgramStats {
    public int Commands;
    public int MaxNesting;
    public int Repeats;
}
public class StatsCalculator
{
    public ProgramStats Calculate(BlockProgram p) 
    {
        ProgramStats stats = new ProgramStats();
        Visit(p.Commands, 0, ref stats);
        return stats;
    }

    // Walks the command tree, so commands inside repeat bodies are counted too
    private void Visit(List<ICommand> commands, int depth, ref ProgramStats stats)
    {
        foreach (ICommand command in commands)
        {
            stats.Commands++;

            if (command is RepeatCommand repeat)
            {
                stats.Repeats++;
                stats.MaxNesting = Math.Max(stats.MaxNesting, depth + 1);
                Visit(repeat.Body, depth + 1, ref stats);
            }
        }
    }
}