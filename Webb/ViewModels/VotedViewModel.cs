using System;
using Webb.Interfaces;

namespace Webb.ViewModels
{
    public class VotedViewModel : IVotedViewModelInterface
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string IsPositive { get; set; }
        public int UserId { get; set; }
        public DateTime OpinionDate { get; set; }
    }
}
