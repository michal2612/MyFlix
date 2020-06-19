namespace Webb.Interfaces
{
    public interface IMovieModelInterface
    {
        int Id { get; set; }
        string Name { get; set; }
        int VotesInGeneral { get; set; }
        bool? IsPositive { get; set; }
        int PositiveVotes { get; set; }
    }
}
