namespace Isu.Extra.Models
{
    public class StudentId
    {
        private static int _id = 0;

        public static int GenerateNewId()
        {
            return _id++;
        }
    }
}
