using System;
using System.Collections.Generic;
using System.Linq;
using TeamJStats.Domain;
using TeamJStats.Services.XmlStats.Models;
using TeamJStats.Services.XmlStats.Services.BoxScores;
using TeamJStats.Services.XmlStats.Services.Events;
using TeamJStats.Services.XmlStats.Services.Sports;

namespace TeamJStats.Services
{
    public class ImportService : IImportService
    {
        public ImportService()
        {
            
        }

        public IEnumerable<BoxScore> GetBoxScores(DateTime date)
        {
            var events = GetEvents(date);
            var boxScores = GetBoxScores(events);

            return boxScores;
        }

        public IEnumerable<Team> GetTeams()
        {
            var sportService = new XmlStatsSportService();
            var xmlTeams = sportService.GetTeams();
            return xmlTeams.Select(ToTeam);
        }

        private static BoxScore ToBoxScore(XmlStatsNbaBoxScore source, Event ev)
        {
            return new BoxScore
            {
                Key = ev.Id,
                AwayTeam = ToTeam(source.AwayTeam),
                HomeTeam = ToTeam(source.HomeTeam),
                GameDateTime = ev.GameDateTime,
                AwayTeamStats = source.AwayTeamPlayerStats.Select(ToGameStats),
                HomeTeamStats = source.HomeTeamPlayerStats.Select(ToGameStats),
            };
        }

        private static Team ToTeam(XmlStatsTeam source)
        {
            return new Team
            {
                Name = source.Name,
                State = source.State,
                City = source.City,
                Conference = source.Conference,
                Key = source.Key               
            };
        }

        private static GameStats ToGameStats(XmlStatsBasketballStats source)
        {
            return new GameStats
            {
                Assists = source.Assists,
                Blocks = source.Blocks,
                DefensiveRebounds = source.DefensiveRebounds,
                FieldGoalsAttempted = source.FieldGoalsAttempted,
                FieldGoalsMade = source.FieldGoalsMade,
                FieldGoalPercentage = source.FieldGoalPercentage,
                FreeThrowsAttempted = source.FreeThrowsAttempted,
                FreeThrowsMade = source.FreeThrowsMade,
                FreeThrowPercentage = source.FreeThrowPercentage,
                ThreePointFieldGoalsAttempted = source.ThreePointFieldGoalsAttempted,
                ThreePointFieldGoalsMade = source.ThreePointFieldGoalsAttempted,
                ThreePointFieldGoalsPercentage = source.ThreePointFieldGoalPercentage,
                Minutes = source.Minutes,
                OffensiveRebounds = source.OffensiveRebounds,
                PersonalFouls = source.PersonalFouls,
                // Player = get from repo
                Points = source.Points,
                Rebounds = source.Rebounds,
                Starter = source.Starter,
                Steals = source.Steals,
                Turnovers = source.Turnovers
            };
        }

        private IEnumerable<BoxScore> GetBoxScores(IEnumerable<Event> events)
        {
            var boxScores = new List<BoxScore>();

            foreach (var ev in events)
            {
                var boxScore = GetBoxScore(ev);
                boxScores.Add(boxScore);
            }

            return boxScores;
        }

        private BoxScore GetBoxScore(Event ev)
        {
            var boxScoreService = new XmlStatsBoxScoreService();
            var xmlBoxScore = boxScoreService.Get(ev.Id);
            return ToBoxScore(xmlBoxScore, ev);
        }

        private IEnumerable<Event> GetEvents(DateTime date)
        {
            var eventService = new XmlStatsEventsService();

            var xmlStatsEvents = eventService.List(new XmlStatsEventListOptions
            {
                Date = date,
                Sport = Sport.nba
            });

            var events = xmlStatsEvents.Select(e => new Event
            {
                Id = e.Key,
                GameDateTime = e.GameDateTime
            }).ToList();

            return events;
        }
    }
}