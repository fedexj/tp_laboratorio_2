using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public string archivo;

        public Texto(string archivo)
        {
            this.archivo = archivo;
        }
        public bool guardar(string datos) {
            try
            {
                StreamWriter sWriter = new StreamWriter(this.archivo,true);
                sWriter.WriteLine(datos);
                sWriter.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException("error en guardado de Archivo", e);
            }     
        }
        public bool leer(out List<string> datos) {
            datos = new List<string>();
            try
            {
                StreamReader sReader = new StreamReader(this.archivo);
               
                while(!sReader.EndOfStream){
                    datos.Add(sReader.ReadLine());
                }                              
                sReader.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException("error en lectura de Archivo", e);
            }	
        }
    }
}
