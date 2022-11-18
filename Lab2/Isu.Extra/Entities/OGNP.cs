namespace Isu.Extra.Entities
{
    public class OGNP
    {
        private List<Flow> _flowsList;
        private string _name;

        public OGNP(string name)
        {
            _flowsList = new List<Flow>();
            _name = name;
        }

        public Flow CreateFlow(string name, int maxPeopleCount)
        {
            return new Flow(maxPeopleCount, name);
        }

        public List<Flow> GetFlows()
        {
            return _flowsList;
        }
    }
}
