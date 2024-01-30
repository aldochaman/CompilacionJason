using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Compilacion
{
     public class TablaDatos
     {
          public int Id { get; set; }
          public string Sistema { get; set; }
          public string RutaSalida { get; set; }
          public string RutaOrigen { get; set; }
          public string Criterios { get; set; }
     }

     public class TablaDatosManager
     {
          private List<TablaDatos> registros;
          private string filePath;

          public TablaDatosManager()
          {
               this.filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "miTabla.json");

               if (!File.Exists(filePath))
               {
                    // Si el archivo no existe, creamos uno nuevo con una lista vacía de registros
                    string emptyJson = JsonConvert.SerializeObject(new List<TablaDatos>(), Formatting.Indented);
                    File.WriteAllText(filePath, emptyJson);
               }

               this.registros = new List<TablaDatos>();
               CargarDatosDesdeArchivo();
          }
          public List<TablaDatos> LeerRegistros()
          {
               return registros;
          }
          // Método para insertar un nuevo registro
          public void InsertarRegistro(TablaDatos registro)
          {
               if (registro == null)
               {
                    throw new ArgumentNullException(nameof(registro), "El registro no puede ser nulo.");
               }

               if (registros.Exists(r => r.Id == registro.Id))
               {
                    throw new ArgumentException("Ya existe un registro con el mismo ID en la tabla.");
               }

               if (registros.Exists(r => r.Sistema == registro.Sistema))
               {
                    throw new ArgumentException("Ya existe un registro con el mismo Sistema en la tabla.");
               }

               registros.Add(registro);
               GuardarDatosEnArchivo();
          }

          // Método para cargar los datos desde el archivo JSON
          private void CargarDatosDesdeArchivo()
          {
               try
               {
                    if (File.Exists(filePath))
                    {
                         string jsonString = File.ReadAllText(filePath);
                         registros = JsonConvert.DeserializeObject<List<TablaDatos>>(jsonString);
                    }
               }
               catch (Exception ex)
               {
                    // Manejo de excepciones si ocurre algún error al cargar los datos
                    Console.WriteLine("Error al cargar los datos: " + ex.Message);
               }
          }
          // Método para guardar los datos en el archivo JSON
          private void GuardarDatosEnArchivo()
          {
               try
               {
                    string jsonString = JsonConvert.SerializeObject(registros, Formatting.Indented);
                    File.WriteAllText(filePath, jsonString);
               }
               catch (Exception ex)
               {
                    // Manejo de excepciones si ocurre algún error al guardar los datos
                    Console.WriteLine("Error al guardar los datos: " + ex.Message);
               }
          }
          public bool ModificarRegistro(TablaDatos registroModificado)
          {
               int index = registros.FindIndex(registro => registro.Id == registroModificado.Id);
               if (index >= 0)
               {
                    registros[index] = registroModificado;
                    GuardarDatosEnArchivo();
                    return true;
               }
               return false;
          }
          public bool EliminarRegistroPorId(int id)
          {
               int index = registros.FindIndex(registro => registro.Id == id);
               if (index >= 0)
               {
                    registros.RemoveAt(index);
                    GuardarDatosEnArchivo();
                    return true;
               }
               return false;
          }
     }
}


