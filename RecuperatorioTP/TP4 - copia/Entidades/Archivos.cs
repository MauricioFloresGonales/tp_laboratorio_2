using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text.Json;

namespace Entidades
{
    public static class Archivos
    {
        public static void GenerarAnalisis<T>(List<T> lista, string fileName) where T : IAnalisis
        {
            try
            {
                string datetime = string.Concat(DateTime.Now.ToString("HH_mm_ss"));
                string filename = string.Concat(datetime, "_", fileName);
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename);

                using (StreamWriter auxSW = new StreamWriter(path, true))
                {
                    auxSW.WriteLine($"Archivos de: {fileName}");
                    auxSW.WriteLine($"Analisis De {typeof(T).ToString()}");
                    foreach (T item in lista)
                    {
                        string texto = item.ResultadosTotales(lista);
                        auxSW.WriteLine(texto);
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public static void GenerarJson<T>(List<T> lista, string fileName) where T : IAnalisis
        {
            try
            {
                string datetime = string.Concat(DateTime.Now.ToString("HH_mm_ss"));
                string filename = string.Concat("JSON", datetime, "_", fileName);
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename);

                using (StreamWriter auxSW = new StreamWriter(path, true))
                {
                    auxSW.WriteLine($"Archivos de: {fileName}");
                    auxSW.WriteLine($"Analisis De {typeof(T).ToString()}");
                    foreach (T item in lista)
                    {
                        string texto = JsonSerializer.Serialize(item);
                        auxSW.WriteLine(texto);
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public static void GenerarXML<T>(List<T> lista, string fileName) where T : IAnalisis
        {
            try
            {
                string datetime = string.Concat(DateTime.Now.ToString("HH_mm_ss"));
                string filename = string.Concat("XML", datetime, "_", fileName);
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename);

                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));

                    xmlSerializer.Serialize(streamWriter, lista);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
