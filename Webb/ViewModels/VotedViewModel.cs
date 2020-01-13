using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webb.ViewModels
{
    public class VotedViewModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string IsPositive { get; set; }
        public int UserId { get; set; }
        public DateTime OpinionDate { get; set; }
    }
}
