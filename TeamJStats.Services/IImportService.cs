using System;
using System.Collections.Generic;
using TeamJStats.Domain;

namespace TeamJStats.Services
{
    public interface IImportService
    {
        IEnumerable<BoxScore> GetBoxScores(DateTime date);
        IEnumerable<Team> GetTeams();
    }

    public class Event
    {
        public string Id { get; set; }
        public DateTime GameDateTime { get; set; }
    }
}