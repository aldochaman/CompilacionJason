using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Compression;

namespace Compilacion
{
     public partial class Form1 : Form
     {
          private string Mitabla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "miTabla.txt");
          

          
          public Form1()
          {
               InitializeComponent();
          }
          private void btnRuta_Click(object sender, EventArgs e)
          {
               DialogResult result = folderBrowserDialog1.ShowDialog();
               if (result == DialogResult.OK)
               {
                    txtRutaOrigen.Text = folderBrowserDialog1.SelectedPath;
               }
          }


          private void btnCrearZip_Click(object sender, EventArgs e)
          {
               string rutaOrigen = txtRutaOrigen.Text.Trim();
               string rutaSalida = txtRutaSalida.Text.Trim();
               string phrase = txtcriterios.Text;
               string[] Criterios = phrase.Split(',');

               if (!Directory.Exists(rutaOrigen))
               {
                    string successMessage = $"Error la ruta de Origen no existe";
                    ShowAndCloseMessageBox(successMessage, "Error", 3000);
                    return;
               }

               if (!Directory.Exists(rutaSalida))
               {
                    string successMessage = $"Error la ruta de Salida no existe";
                    ShowAndCloseMessageBox(successMessage, "Error", 3000);
                    return;
               }

               try
               {
                    string nombreZip = cmbSistema.Text.Trim();

                    // Get the current date and time
                    DateTime currentDateTime = DateTime.Now;

                    // Format the date and time components
                    string dateSuffix = currentDateTime.ToString("yyyyMMdd_HHmmss");

                    // Concatenate the date and time to the zip file name
                    string rutaZip = Path.Combine(rutaSalida, $"{nombreZip}_{dateSuffix}.zip");

                    using (FileStream zipToCreate = new FileStream(rutaZip, FileMode.Create))
                    {
                         using (ZipArchive zip = new ZipArchive(zipToCreate, ZipArchiveMode.Create))
                         {
                              ComprimirDirectorio(zip, rutaOrigen, "", Criterios);
                         }
                    }
                    string successMessage = $"Archivo ZIP creado en: {rutaZip}";
                    ShowAndCloseMessageBox(successMessage, "Éxito", 3000);
               }
               catch (Exception ex)
               {
                    //MessageBox.Show($"Error al crear el archivo ZIP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    string successMessage = $"Error al crear el archivo ZIP:{ex}";
                    ShowAndCloseMessageBox(successMessage, "Error", 3000);
               }
          }
                
          private void ComprimirDirectorio(ZipArchive zip, string rutaDirectorio, string rutaRelativa, string[] exclusiones)
          {
               foreach (string archivo in Directory.GetFiles(rutaDirectorio))
               {
                    string nombreArchivo = Path.GetFileName(archivo).ToLower();
                    string extensionArchivo = Path.GetExtension(nombreArchivo);

                    // Excluir archivos que coincidan con las exclusiones de extensión o nombres específicos
                    if (ExcluirArchivo(nombreArchivo, extensionArchivo, exclusiones))
                         continue;

                    string rutaArchivoDestino = Path.Combine(rutaRelativa, nombreArchivo);
                    using (FileStream fs = new FileStream(archivo, FileMode.Open, FileAccess.Read))
                    {
                         ZipArchiveEntry entry = zip.CreateEntry(rutaArchivoDestino, CompressionLevel.Optimal);
                         using (Stream entryStream = entry.Open())
                         {
                              fs.CopyTo(entryStream);
                         }
                    }
               }

               foreach (string carpeta in Directory.GetDirectories(rutaDirectorio))
               {
                    string nombreCarpeta = Path.GetFileName(carpeta).ToLower();

                    // Excluir carpetas y subcarpetas que coincidan con las exclusiones
                    if (ExcluirCarpeta(nombreCarpeta,rutaDirectorio, exclusiones))
                         continue;

                    ComprimirDirectorio(zip, carpeta, Path.Combine(rutaRelativa, nombreCarpeta), exclusiones);
               }
          }

          private bool ExcluirCarpeta(string nombreCarpeta, string rutaCompletaDirectorio, string[] exclusiones)
          {
               List<string> exclusionList = new List<string>();
               foreach (string exclusion in exclusiones)
               {
                    string[] exclusionParts = exclusion.Split(',');
                    exclusionList.AddRange(exclusionParts);
               }
               foreach (string exclusion in exclusionList)
               {
                    if (Path.Combine(rutaCompletaDirectorio, $"\\{nombreCarpeta}") == Path.Combine(rutaCompletaDirectorio, $"\\{exclusion}"))
                         return true;
               }

               return false; // No se encontró ninguna coincidencia de exclusión
          }

          private bool ExcluirArchivo(string nombreArchivo, string extensionArchivo, string[] exclusiones)
          {
               List<string> exclusionList = new List<string>();
               foreach (string exclusion in exclusiones)
               {
                    string[] exclusionParts = exclusion.Split(',');
                    exclusionList.AddRange(exclusionParts);
               }

               foreach (string exclusion in exclusionList)
               {
                    if (exclusion.StartsWith("*."))
                    {
                         // Si la exclusión tiene un * al principio, comprobamos la extensión del archivo
                         string exclusionExtension = exclusion.Substring(1).ToLower();
                         if (extensionArchivo == exclusionExtension)
                              return true;
                    }
                    else
                    {
                         // Si no tiene *, comparamos el nombre completo del archivo
                         if (nombreArchivo == exclusion)
                              return true;
                    }
               }

               return false; // No se encontró ninguna coincidencia de exclusión
          }

          private void btn_grabar_Click(object sender, EventArgs e)
          {
               TablaDatosManager tablaManager = new TablaDatosManager();
               
               int ultimoId = 0;
               if (cmbSistema.Items.Count > 0)
               {
                    string sistemaSeleccionado = cmbSistema.Text.ToString();
                    // Leer todos los registros
                    List<TablaDatos> registros = tablaManager.LeerRegistros();
                    // Obtener el último id
                    foreach (var registro in registros)
                    {
                         if (registro.Sistema == sistemaSeleccionado)
                         {
                              //Si el Sistema Existe lo editamos
                              registro.RutaOrigen = txtRutaOrigen.Text;
                              registro.RutaSalida = txtRutaSalida.Text;
                              registro.Criterios = txtcriterios.Text;
                              tablaManager.ModificarRegistro(registro);
                              CargarComboBoxSistema();
                              string successMessage1 = $"Exito al modificar registro";
                              ShowAndCloseMessageBox(successMessage1, "Éxito", 3000);
                              return;
                         }

                         if (registro.Id > ultimoId)
                         {
                              ultimoId = registro.Id;
                         }
                    }
               }           
               // Incrementar el id en 1 para obtener el nuevo id
               int nuevoId = ultimoId + 1;

               // Crear el registro con el nuevo id
               TablaDatos nuevoRegistro = new TablaDatos
               {
                    Id = nuevoId,
                    Sistema = cmbSistema.Text,
                    RutaOrigen = txtRutaOrigen.Text,
                    RutaSalida = txtRutaSalida.Text,
                    Criterios = txtcriterios.Text
               };
               // Guardar el registro con el nuevo id
               tablaManager.InsertarRegistro(nuevoRegistro);
               CargarComboBoxSistema();
               string successMessage = $"Exito al grabar nuevo registro";           
               ShowAndCloseMessageBox(successMessage, "Exito", 3000);
          }

          private void cmbSistema_SelectedIndexChanged(object sender, EventArgs e)
          {
               if (cmbSistema.SelectedItem != null)
               {
                    string sistemaSeleccionado = cmbSistema.SelectedItem.ToString();

                    // Buscar el registro correspondiente al sistema seleccionado          
                    TablaDatosManager tablaManager = new TablaDatosManager();
                    List<TablaDatos> registros = tablaManager.LeerRegistros();
                    TablaDatos registroSeleccionado = registros.Find(registro => registro.Sistema == sistemaSeleccionado);
                    if (registroSeleccionado != null)
                    {
                         // Rellenar los campos de texto con los valores del registro seleccionado
                         txtRutaOrigen.Text = registroSeleccionado.RutaOrigen;
                         txtRutaSalida.Text = registroSeleccionado.RutaSalida;
                         txtcriterios.Text = registroSeleccionado.Criterios;
                    }
               }
          }         
          private void Form1_Load(object sender, EventArgs e)
          {
               CargarComboBoxSistema();
          }

          private void CargarComboBoxSistema()
          {
               TablaDatosManager tablaManager = new TablaDatosManager();
               List<TablaDatos> registros = tablaManager.LeerRegistros();
               cmbSistema.Items.Clear();

               foreach (var registro in registros)
               {
                    cmbSistema.Items.Add(registro.Sistema);
               }

               if (cmbSistema.Items.Count > 0)
               {
                    cmbSistema.SelectedIndex = 0;
               }
          }

          private void btnRutaSalida_Click(object sender, EventArgs e)
          {
               DialogResult result = folderBrowserDialog1.ShowDialog();
               if (result == DialogResult.OK)
               {
                    txtRutaSalida.Text = folderBrowserDialog1.SelectedPath;
               }
          }         
          private void btnEliminar_Click(object sender, EventArgs e)
          {
               if (cmbSistema.SelectedItem != null)
               {
                    string sistemaSeleccionado = cmbSistema.SelectedItem.ToString();

                    // Buscar el registro correspondiente al sistema seleccionado
                    TablaDatosManager tablaManager = new TablaDatosManager();
                    List<TablaDatos> registros = tablaManager.LeerRegistros();
                    TablaDatos registroSeleccionado = registros.Find(registro => registro.Sistema == sistemaSeleccionado);

                    if (registroSeleccionado != null)
                    {
                         int id = registroSeleccionado.Id;

                         // Eliminar el registro con el ID encontrado
                         bool eliminado = tablaManager.EliminarRegistroPorId(id);
                         if (eliminado)
                         {
                              CargarComboBoxSistema();
                              string successMessage = $"Éxito al eliminar registro";
                              ShowAndCloseMessageBox(successMessage, "Éxito", 3000);
                         }
                         else
                         {
                              string errorMessage = $"Error al eliminar registro";
                              ShowAndCloseMessageBox(errorMessage, "Error", 3000);
                         }
                    }
               }
          }
          private void ShowAndCloseMessageBox(string message, string caption, int closeDelay)
          {
               CustomMessageBox customMessageBox = new CustomMessageBox(message, caption, closeDelay);
               customMessageBox.ShowDialog();
          }

     }
}


