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
        stats.Commands = p.Commands.Count;
        stats.Repeats = p.Commands.OfType<RepeatCommand>().Count();
        stats.MaxNesting = (p.Commands.OfType<RepeatCommand>().Select(rc => rc.Body.OfType<RepeatCommand>().Count()).DefaultIfEmpty(0).Max()) + 1;
        return stats;
    }
}