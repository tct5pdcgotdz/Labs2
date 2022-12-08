using Backups.Entities;

namespace Backups.Extra.Recovery
{
    public interface IRecovery
    {
        public void Recovery(RestorePoint restorePoint);
    }
}