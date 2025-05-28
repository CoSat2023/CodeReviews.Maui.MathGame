using MathGame.Maui.Models;
using SQLite;

namespace MathGame.Maui.Data
{
    public class GameRepository
    {
        string _dbPath;
        private SQLiteConnection conn;
        private bool _initialized = false;

        public GameRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void Init()
        {
            if (_initialized)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Game>();
            _initialized = true;
        }

        public List<Game> GetAllGames()
        {
            Init();
            return conn.Table<Game>().ToList();
        }

        public void Add(Game game)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Insert(game);
        }

        public void Delete(int id)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Delete(new Game { Id = id });
        }
    }
}
