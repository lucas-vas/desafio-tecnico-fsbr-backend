namespace DesafioTecnicoFSBR.Infra.Configuration.User
{
    public sealed class CurrentUser : ICurrentUser
    {
        private static Guid _userId;

        public Guid Get()
        {
            return _userId;
        }

        public static void SetUserId(Guid userId) => _userId = userId;
    }
}
