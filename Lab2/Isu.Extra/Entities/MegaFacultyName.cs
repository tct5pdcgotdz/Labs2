namespace Isu.Extra.Entities
{
    public class MegaFacultyName
    {
        public MegaFacultyName(string name, char symbol)
        {
            Name = name;
            ShortName = symbol;
        }

        public string Name { get; }
        public char ShortName { get; }
    }
}
