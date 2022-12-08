using Backups.Archivators;
using Backups.Converter;

namespace Backups.Entities
{
    public class RestorePoint
    {
        private List<Storage> _storages;
        public RestorePoint(IReadOnlyCollection<Storage> storages, IConverter converter, DirectoryInfo directoryInfo)
        {
            _storages = new List<Storage>();
            _storages.AddRange(storages);
            DateTime = DateTime.Now;
            Converter = converter;
            DirectoryInfo = directoryInfo;
        }

        public DirectoryInfo DirectoryInfo { get; }

        public IReadOnlyCollection<Storage> Storages => _storages;

        public DateTime DateTime { get; private set; }

        public IConverter Converter { get; private set; }

        public void AddStorages(List<Storage> storages)
        {
            _storages.AddRange(storages);
            DateTime = DateTime.Now;
        }
    }
}