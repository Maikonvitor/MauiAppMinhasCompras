using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        private readonly SQLiteAsyncConnection _conn;
        private readonly Task _initializationTask;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _initializationTask = _conn.CreateTableAsync<Produto>();
        }

        public async Task<int> Insert(Produto p)
        {
            await _initializationTask;
            return await _conn.InsertAsync(p);
        }

        public async Task<int> Update(Produto p)
        {
            await _initializationTask;
            return await _conn.UpdateAsync(p);
        }

        public async Task<int> Delete(int id)
        {
            await _initializationTask;
            return await _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        public async Task<List<Produto>> GetAll()
        {
            await _initializationTask;
            return await _conn.Table<Produto>().ToListAsync();
        }

        public async Task<List<Produto>> Search(string q)
        {
            await _initializationTask;
            string sql = "SELECT * FROM Produto WHERE Descricao LIKE ?";
            return await _conn.QueryAsync<Produto>(sql, "%" + q + "%");
        }
    }
}
