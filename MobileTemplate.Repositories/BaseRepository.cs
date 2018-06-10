using MobileTemplate.Repositories.Database;
using System;

namespace MobileTemplate.Repositories
{
    public class BaseRepository
    {
        protected IAppDatabase Db { get; }

        public BaseRepository(IAppDatabase appDatabase)
        {
            this.Db = appDatabase ?? throw new ArgumentNullException();
        }
    }
}
