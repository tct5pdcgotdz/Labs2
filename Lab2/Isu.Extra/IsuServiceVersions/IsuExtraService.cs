namespace Isu.Extra.IsuServiceVersions
{
    public class IsuExtraService : IsuServiceDecorator
    {
        public IsuExtraService(IsuServiceBase isuService)
            : base(isuService)
        {
        }
    }
}
