using System;
using System.Collections.Generic;

namespace NetflixAndChill
{
    public class Session
    {
        private static Random rand = new Random();

        public List<User> Users = new List<User>();
        public string SessionID { get; set; }

        public static string GenerateSessionId(int alphaCount = 2, int numCount = 2)
        {
            List<char> generatedChars = new List<char>();

            for (int i = 0; i < alphaCount; i++)
            {
                generatedChars.Add((char)rand.Next(65, 90));
            }

            for (int i = 0; i < numCount; i++)
            {
                generatedChars.Add((char)rand.Next(48, 57));
            }

            return String.Join("", generatedChars);
        }
    }
}
