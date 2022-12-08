using Backups.Entities;

namespace Backups.Extra.Clearing
{
    public class QuantityClearing : IClearing
    {
        private int _quantity;
        public QuantityClearing(int quantity)
        {
            _quantity = quantity;
        }

        public List<RestorePoint> Clearing(List<RestorePoint> restorePoints)
        {
            var pointsToClean = new List<RestorePoint>();
            for (int i = 0; i < restorePoints.Count - _quantity; i++)
                pointsToClean.Add(restorePoints[i]);
            return pointsToClean;
        }
    }
}