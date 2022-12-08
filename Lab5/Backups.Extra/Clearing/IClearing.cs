using Backups.Entities;

namespace Backups.Extra.Clearing
{
    public interface IClearing
    {
        List<RestorePoint> Clearing(List<RestorePoint> restorePoints);
    }
}