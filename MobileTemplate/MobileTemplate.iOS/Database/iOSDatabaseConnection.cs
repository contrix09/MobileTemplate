using SQLite;
using System.IO;

namespace MobileTemplate.iOS.Database
{
    public class iOSDatabaseConnection
    {
        /// <summary>
        /// Creates and returns an <see cref="SQLiteConnection"/> object from the iOS platform.
        /// </summary>
        /// <param name="databaseName">The name of the Database file.</param>
        public SQLiteConnection CreateDatabaseConnection(string databaseName)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, databaseName);

            return new SQLiteConnection(path, true);
        }
    }
}