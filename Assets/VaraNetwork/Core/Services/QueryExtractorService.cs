using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class QueryExtractorService
{
    /// <summary>
    /// Extracts queries and their return types from a service structure string.
    /// </summary>
    /// <param name="serviceStructure">The string representation of the service structure.</param>
    /// <returns>A dictionary where the key is the query name and the value is the return type.</returns>
    public static Dictionary<string, string> ExtractQueries(string serviceStructure)
    {
        // Dictionary to hold the query names and their return types
        var queries = new Dictionary<string, string>();

        // Regular expression to match the query lines
        string pattern = @"query\s+(\w+)\s*:\s*\(\)\s*->\s*([\w\s{}]+);";

        // Match the pattern against the input string
        var matches = Regex.Matches(serviceStructure, pattern);

        // Iterate through the matches and add them to the dictionary
        foreach (Match match in matches)
        {
            if (match.Groups.Count == 3)
            {
                string queryName = match.Groups[1].Value.Trim();
                string returnType = match.Groups[2].Value.Trim();
                queries.Add(queryName, returnType);
            }
        }

        return queries;
    }
}
