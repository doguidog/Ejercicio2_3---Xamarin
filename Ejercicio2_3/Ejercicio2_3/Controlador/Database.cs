using Ejercicio2_3.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_3.Controlador
{

    public class Database
    {

        readonly SQLiteAsyncConnection db;
        public Database(string pathdb) 
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<ModeloAudio>().Wait();
        }

        public Task<List<ModeloAudio>> ObtenerListaAudios()
        {
            return db.Table<ModeloAudio>().ToListAsync();
        }

        public Task<ModeloAudio> ObtenerAudio(int pcodigo)
        {
            return db.Table<ModeloAudio>()
                .Where(i => i.Id == pcodigo)
                .FirstOrDefaultAsync();
        }

        public Task<int> GrabarAudio(ModeloAudio audio)
        {
            if (audio.Id != 0)
            {
                return db.UpdateAsync(audio);
            }
            else
            {
                return db.InsertAsync(audio);
            }
        }

        public Task<int> EliminarAudio(ModeloAudio audio)
        {
            return db.DeleteAsync(audio);
        }
    }
}
