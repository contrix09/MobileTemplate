using Android.App;
using MobileTemplate.Repositories.Database;
using SQLite;
using System.IO;

namespace MobileTemplate.Droid.Database
{
    public class AndroidDatabaseConnection : IPlatformDatabaseConnection
    {
        /// <summary>
        /// Creates and returns an <see cref="SQLiteConnection"/> object from the Android platform.
        /// </summary>
        /// <param name="databaseName">The name of the Database file.</param>
        public SQLiteConnection CreateDatabaseConnection(string databaseName)
        {
            var appName = Application.Context.PackageName;
            var packageInfo = Application.Context.PackageManager.GetPackageInfo(appName, 0);
            var appDirectory = packageInfo.ApplicationInfo.DataDir;
            var path = Path.Combine(appDirectory, databaseName);

            return new SQLiteConnection(path, true);
        }
    }
}