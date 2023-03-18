using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio2_3.Modelo
{
    public class ModeloAudio
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Url { get; set; }
        public string Descripcion { get; set; }
        public DateTime Date { get; set; }
    }
}
