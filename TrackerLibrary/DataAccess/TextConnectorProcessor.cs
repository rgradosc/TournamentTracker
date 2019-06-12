using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using TrackerLibrary.Models;

// * Load the text file
// * Convert the text to List<PrizeModel>
// Find the max ID
// Add the new record with the new ID (max + 1)
// Convert the prize to List<string>
// Save the List<string> to the text file

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName) // PrizeModels.csv
        {
            // C:\data\TournamentTracker\PrizeModels.csv
            return string.Format(@"{0}\{1}", ConfigurationManager.AppSettings["filePath"], fileName);
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PrizeModel p = new PrizeModel();
                p.Id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                output.Add(p);
            }

            return output;
        }

        public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PersonModel p = new PersonModel();
                p.Id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.EmailAddress = cols[3];
                p.CellphoneNumber = cols[4];
                output.Add(p);
            }

            return output;
        }

        public static List<TeamModel> ConvertToTeamModels(this List<string> lines, string peopleFileName)
        {
            // id, team name, list of ids separated by the pipe
            // 3, Tim's team, 1|2|3|4

            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> people = peopleFileName.FullFilePath().LoadFile().ConvertToPersonModels();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                TeamModel t = new TeamModel();
                t.Id = int.Parse(cols[0]);
                t.TeamName = cols[1];

                string[] personIds = cols[2].Split('|');

                foreach (string id in personIds)
                {
                    t.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
                }

                output.Add(t);
            }

            return output;
        }

        public static List<TournamentModel> ConvertToTournamentModels(this List<string> lines, string teamFileName, string peopleFileName, string prizeFileName)
        {
            // id

            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> teams = teamFileName.FullFilePath().LoadFile().ConvertToTeamModels(peopleFileName);
            List<PrizeModel> prizes = prizeFileName.FullFilePath().LoadFile().ConvertToPrizeModels();
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                TournamentModel tm = new TournamentModel();
                tm.Id = int.Parse(cols[0]);
                tm.TournamentName = cols[1];
                tm.EntryFee = decimal.Parse(cols[2]);

                string[] teamIds = cols[3].Split('|');

                foreach (string id in teamIds)
                {
                    tm.EnteredTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
                }

                string[] prizeIds = cols[4].Split('|');

                foreach (string id in prizeIds)
                {
                    tm.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
                }

                // Capture Rounds information
                string[] rounds = cols[5].Split('|');
 
                foreach (string round in rounds)
                {
                    string[] msText = round.Split('^');
                    List<MatchupModel> ms = new List<MatchupModel>();
 
                    foreach (string matchupModelTextId in msText)
                    {
                        ms.Add(matchups.Where(x => x.Id == int.Parse(matchupModelTextId)).First());
                    }

                    tm.Rounds.Add(ms);
                }

                output.Add(tm);
            }

            return output;
        }

        private static List<MatchupEntryModel> ConvertStringToMatchupEntryModels(string input)
        {
            string[] ids = input.Split('|');
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();

            List<string> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile();
            List<string> matchingEntries = new List<string>();

            foreach (string id in ids)
            {
                foreach (string entry in entries)
                {
                    string[] cols = entry.Split(',');

                    if (cols[0] == id)
                    {
                        matchingEntries.Add(entry);
                    }
                }
            }

            output = matchingEntries.ConvertToMatchupEntryModels();

            return output;
        }

        public static List<MatchupEntryModel> ConvertToMatchupEntryModels(this List<string> lines)
        {
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                MatchupEntryModel me = new MatchupEntryModel();
                me.Id = int.Parse(cols[0]);
                if (cols[1].Length == 0)
                {
                    me.TeamCompeting = null;

                }
                else
                {
                    me.TeamCompeting = LookupTeamById(int.Parse(cols[1]));
                }

                me.Score = double.Parse(cols[2]);

                int parentId = 0;
                if (int.TryParse(cols[3], out parentId))
                {
                    me.ParentMatchup = LookupMatchupById(parentId);
                }
                else
                {
                    me.ParentMatchup = null;
                }

                output.Add(me);
            }

            return output;
        }

        private static MatchupModel LookupMatchupById(int id)
        {
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            return matchups.Where(x => x.Id == id).First();
        }

        private static TeamModel LookupTeamById(int id)
        {
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(GlobalConfig.PeopleFile);

            return teams.Where(x => x.Id == id).First();
        }

        public static List<MatchupModel> ConvertToMatchupModels(this List<string> lines)
        {
            List<MatchupModel> output = new List<MatchupModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                MatchupModel p = new MatchupModel();
                p.Id = int.Parse(cols[0]);
                p.Entries = ConvertStringToMatchupEntryModels(cols[1]);
                
                if (cols[2].Length == 0)
                {
                    p.Winner = null;
                }
                else
                {
                    p.Winner = LookupTeamById(int.Parse(cols[2]));
                }

                p.MatchupRound = int.Parse(cols[3]);
                output.Add(p);
            }

            return output;
        }

        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel p in models)
            {
                lines.Add(string.Format("{0},{1},{2},{3},{4}", p.Id, p.PlaceNumber, p.PlaceName, p.PrizeAmount, p.PrizePercentage));
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToPeopleFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PersonModel p in models)
            {
                lines.Add(string.Format("{0},{1},{2},{3},{4}", p.Id, p.FirstName, p.LastName, p.EmailAddress, p.CellphoneNumber));
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToTeamFile(this List<TeamModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TeamModel t in models)
            {
                lines.Add(string.Format("{0},{1},{2}", t.Id, t.TeamName, ConvertToPeopleListToString(t.TeamMembers)));
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }


        public static void SaveRoundsToFile(this TournamentModel model, string matchupFile, string matchupEntryFile)
        {
            foreach (List<MatchupModel> round in model.Rounds)
            {
                foreach (MatchupModel matchup in round)
                {
                    matchup.SaveMatchupToFile(matchupFile, matchupEntryFile);        
                }
            }
        }

        public static void SaveMatchupToFile(this MatchupModel matchup, string matchupFile, string matchupEntryFile)
        {
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            int currentId = 1;

            if (matchups.Count > 0)
            {
                currentId = matchups.OrderByDescending(x => x.Id).First().Id + 1;
            }

            matchup.Id = currentId;

            matchups.Add(matchup);
            
            List<string> lines = new List<string>();

            foreach (MatchupModel m in matchups)
            {
                string winner = "";
                if (m.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }

                lines.Add(string.Format("{0},{1},{2},{3}", m.Id, "", winner, m.MatchupRound));
            }

            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);

            foreach (MatchupEntryModel entry in matchup.Entries)
            {
                entry.SaveEntryToFile(matchupEntryFile);
            }

            lines = new List<string>();

            foreach (MatchupModel m in matchups)
            {
                string winner = "";
                if (m.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }

                lines.Add(string.Format("{0},{1},{2},{3}", m.Id, ConvertMatchupEntryListToString(m.Entries), winner, m.MatchupRound));
            }

            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);

        }

        public static void SaveEntryToFile(this MatchupEntryModel entry, string matchupEntryFile){

            List<MatchupEntryModel> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();

            int currentId = 1;

            if (entries.Count > 0)
            {
                currentId = entries.OrderByDescending(x => x.Id).First().Id + 1;
            }

            entry.Id = currentId;
            entries.Add(entry);

            List<string> lines = new List<string>();

            foreach (MatchupEntryModel e in entries)
            {
                string parent = "";
                if (e.ParentMatchup != null)
                {
                    parent = e.ParentMatchup.Id.ToString();
                }
                string teamCompeting = "";
                if (e.TeamCompeting != null)
                {
                    teamCompeting = e.TeamCompeting.Id.ToString();
                }
                lines.Add(string.Format("{0},{1},{2},{3}", e.Id, teamCompeting, e.Score, parent));
            }

            File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
        }

        public static void SaveToTournamentFile(this List<TournamentModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TournamentModel tm in models)
            {
                lines.Add(string.Format("{0},{1},{2},{3},{4},{5}",
                    tm.Id,
                    tm.TournamentName,
                    tm.EntryFee,
                    ConvertTeamListToString(tm.EnteredTeams),
                    ConvertPrizeListToString(tm.Prizes),
                    ConvertRoundListToString(tm.Rounds)));
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        private static string ConvertMatchupEntryListToString(List<MatchupEntryModel> entries)
        {
            string output = string.Empty;

            if (entries.Count > 0)
            {
                foreach (MatchupEntryModel e in entries)
                {
                    output += string.Format("|{0}", e.Id);
                }

                output = output.Substring(1);
            }

            return output;
        }

        private static string ConvertRoundListToString(List<List<MatchupModel>> rounds)
        {
            string output = string.Empty;

            if (rounds.Count > 0)
            {
                foreach (List<MatchupModel> r in rounds)
                {
                    output += string.Format("|{0}", ConvertMatchupListToString(r));
                }

                output = output.Substring(1);
            }

            return output;
        }

        private static string ConvertMatchupListToString(List<MatchupModel> matchups)
        {
            string output = string.Empty;

            if (matchups.Count > 0)
            {
                foreach (MatchupModel m in matchups)
                {
                    output += string.Format("^{0}", m.Id);
                }

                output = output.Substring(1);
            }

            return output;
        }

        private static string ConvertPrizeListToString(List<PrizeModel> prizes)
        {
            string output = string.Empty;

            if (prizes.Count > 0)
            {
                foreach (PrizeModel p in prizes)
                {
                    output += string.Format("|{0}", p.Id);
                }

                output = output.Substring(1);
            }

            return output;
        }

        private static string ConvertTeamListToString(List<TeamModel> teams)
        {
            string output = string.Empty;

            if (teams.Count > 0)
            {
                foreach (TeamModel t in teams)
                {
                    output += string.Format("|{0}", t.Id);
                }

                output = output.Substring(1);
            }

            return output;
        }

        private static string ConvertToPeopleListToString(List<PersonModel> people)
        {
            string output = string.Empty;

            if (people.Count > 0)
            {
                foreach (PersonModel p in people)
                {
                    output += string.Format("|{0}", p.Id);
                }

                output = output.Substring(1);
            }

            return output;
        }
    }
}
