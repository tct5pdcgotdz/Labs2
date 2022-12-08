using Backups.Entities;

namespace Backups.Extra.Clearing
{
    public class TimeClearing : IClearing
    {
        private DateTime _dateToClean;
        public TimeClearing(DateTime dateToClean)
        {
            _dateToClean = dateToClean;
        }

        public List<RestorePoint> Clearing(List<RestorePoint> restorePoints)
        {
            return restorePoints.Where(restorePoint => restorePoint.DateTime < _dateToClean).ToList();
        }
    }
}