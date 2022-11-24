using Isu.Tools;

namespace Isu.Models
{
    public class GroupName
    {
        private const int LENGTH = 6;
        private const int MAXNUMBER = 10000;
        private const int MINNUMBER = 1000;
        private const int MAXCOURSE = 6;

        public GroupName(string name)
        {
            if (!IsValideGroupName(name))
            {
                throw new InvalideGroupNameException();
            }

            Name = name;
            MegaFacSymbol = name[0];
        }

        public string Name { get; private set; }

        public char MegaFacSymbol { get; }

        public CourseNumber GetCourseNumber()
        {
            return (CourseNumber)int.Parse(Name[1].ToString());
        }

        private bool IsValideGroupName(string name)
        {
            return IsCorrectLength(name) && IsCorrectSymbol(name) && IsCorrectCourse(name) && IsCorrectNumber(name);
        }

        private bool IsCorrectLength(string name)
        {
            return name.Length == LENGTH;
        }

        private bool IsCorrectSymbol(string name)
        {
            char symbol = name[0];
            return symbol >= 'A' && symbol <= 'Z';
        }

        private bool IsCorrectNumber(string name)
        {
            return int.TryParse(name[2..], out int number) && number >= MINNUMBER && number <= MAXNUMBER;
        }

        private bool IsCorrectCourse(string name)
        {
            return int.TryParse(name[1].ToString(), out int number) && number <= MAXCOURSE && number >= 1;
        }
    }
}