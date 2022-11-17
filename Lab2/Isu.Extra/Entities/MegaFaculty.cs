using Isu.Entities;
using Isu.Extra.Tools;

namespace Isu.Extra.Entities
{
    public class MegaFaculty
    {
        private List<OGNP> _listsOGNP;
        private List<Group> groups;
        private string _name;
        private char _symbol;

        public MegaFaculty(MegaFacultyName megaFacultyName)
        {
            _listsOGNP = new List<OGNP>();
            groups = new List<Group>();

            _name = megaFacultyName.Name;
            _symbol = megaFacultyName.ShortName;
        }

        public OGNP CreateOGNP(string name)
        {
            return new OGNP(name);
        }

        public void AddGroup(Group group)
        {
            if (!CheckCorrectGroup(group))
            {
                throw new InvalidGroupForMegaFacException();
            }

            groups.Add(group);
        }

        private bool CheckCorrectGroup(Group group)
        {
            return group.GroupName.MegaFacSymbol.Equals(_symbol);
        }
    }
}
