using System;

namespace NetflixAndChill
{
    public class User
    {
        private static Random rand = new Random();

        public int UserId { get; set; }
        public string Name { get; set; }

        public static int GenerateUserId()
        {
            return rand.Next(Int32.MaxValue - 1);
        }
    }
}
