using System;
using System.Drawing;
using System.Windows.Forms;

namespace Compilacion
{
     public partial class CustomMessageBox : Form
     {
          private Timer closeTimer = new Timer();

          public CustomMessageBox(string message, string caption, int closeDelay)
          {
               InitializeComponent();
               lblMessage.Text = message;
               Text = caption;
               ControlBox = false;
               MinimizeBox = false;
               MaximizeBox = false;

               // Calcular el tamaño del mensaje y ajustar el tamaño del formulario
               int messageWidth = TextRenderer.MeasureText(message, lblMessage.Font).Width;
               int messageHeight = TextRenderer.MeasureText(message, lblMessage.Font).Height;
               int padding = 30; // Espacio de relleno
               this.Size = new Size(messageWidth + padding, messageHeight + padding + 50); // Ajusta el tamaño del formulario

               // Establecer el color de fondo a un gris claro
               this.BackColor = Color.LightGray;
               //this.TransparencyKey = Color.Magenta;


               closeTimer.Interval = closeDelay;
               closeTimer.Tick += CloseTimer_Tick;
               closeTimer.Start();
          }

          private void CloseTimer_Tick(object sender, EventArgs e)
          {
               closeTimer.Stop();
               this.Close();
          }

          private void CustomMessageBox_Load(object sender, EventArgs e)
          {

          }
     }
}
