using Backups.Entities;

namespace Backups.Extra.Clearing
{
    public class HybridClearing : IClearing
    {
        private List<IClearing> _clearings;
        private CombineType _combineType;
        public HybridClearing(List<IClearing> clearings, CombineType combineType)
        {
            _clearings = clearings;
            _combineType = combineType;
        }

        public List<RestorePoint> Clearing(List<RestorePoint> restorePoints)
        {
            var result = new List<RestorePoint>();
            result.AddRange(restorePoints);
            switch (_combineType)
            {
                case CombineType.Everything:
                    foreach (IClearing clearing in _clearings)
                    {
                        result = result.Intersect(clearing.Clearing(restorePoints)).ToList();
                    }

                    break;
                case CombineType.AtLeastOne:
                    foreach (IClearing clearing in _clearings)
                    {
                        result = result.Union(clearing.Clearing(restorePoints)).ToList();
                    }

                    break;
            }

            return result;
        }
    }
}