/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        // This dictionary will store the total points for each player
        Dictionary<string, int> players = new Dictionary<string, int>();

        // Read the CSV file
        using (TextFieldParser reader = new TextFieldParser("basketball.csv"))
        {
            reader.TextFieldType = FieldType.Delimited;
            reader.SetDelimiters(",");
            reader.ReadFields(); // Skip the header row

            // Go through each row in the file
            while (!reader.EndOfData)
            {
                string[] fields = reader.ReadFields();

                string playerId = fields[0];
                string pointsText = fields[8];

                int points = 0;

                // Try to convert the points to an integer
                if (int.TryParse(pointsText, out int parsedPoints))
                {
                    points = parsedPoints;
                }

                // Add to the player's total points in the dictionary
                if (players.ContainsKey(playerId))
                {
                    players[playerId] = players[playerId] + points;
                }
                else
                {
                    players.Add(playerId, points);
                }
            }
        }

        // Now put the dictionary entries into a list so we can sort them
        List<KeyValuePair<string, int>> playerList = new List<KeyValuePair<string, int>>();

        foreach (KeyValuePair<string, int> entry in players)
        {
            playerList.Add(entry);
        }

        // Sort the list in descending order based on total points
        playerList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

        // Print the top 10 players
        Console.WriteLine("Top 10 Players by Total Points:");

        int count = 0;
        foreach (KeyValuePair<string, int> entry in playerList)
        {
            Console.WriteLine($"{count + 1}. {entry.Key}: {entry.Value} points");
            count++;

            if (count == 10)
            {
                break;
            }
        }
    }
}
