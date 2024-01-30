
namespace Compilacion
{
     partial class Form1
     {
          /// <summary>
          /// Variable del diseñador necesaria.
          /// </summary>
          private System.ComponentModel.IContainer components = null;

          /// <summary>
          /// Limpiar los recursos que se estén usando.
          /// </summary>
          /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }

          #region Código generado por el Diseñador de Windows Forms

          /// <summary>
          /// Método necesario para admitir el Diseñador. No se puede modificar
          /// el contenido de este método con el editor de código.
          /// </summary>
          private void InitializeComponent()
          {
               this.btnRuta = new System.Windows.Forms.Button();
               this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
               this.txtRutaOrigen = new System.Windows.Forms.TextBox();
               this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
               this.btnCrearZip = new System.Windows.Forms.Button();
               this.txtRutaSalida = new System.Windows.Forms.TextBox();
               this.btnRutaSalida = new System.Windows.Forms.Button();
               this.cmbSistema = new System.Windows.Forms.ComboBox();
               this.btn_grabar = new System.Windows.Forms.Button();
               this.lblSistema = new System.Windows.Forms.Label();
               this.labelCriterios = new System.Windows.Forms.Label();
               this.txtcriterios = new System.Windows.Forms.TextBox();
               this.btnEliminar = new System.Windows.Forms.Button();
               this.SuspendLayout();
               // 
               // btnRuta
               // 
               this.btnRuta.Location = new System.Drawing.Point(12, 43);
               this.btnRuta.Name = "btnRuta";
               this.btnRuta.Size = new System.Drawing.Size(99, 23);
               this.btnRuta.TabIndex = 0;
               this.btnRuta.Text = "Ruta Origen";
               this.btnRuta.UseVisualStyleBackColor = true;
               this.btnRuta.Click += new System.EventHandler(this.btnRuta_Click);
               // 
               // txtRutaOrigen
               // 
               this.txtRutaOrigen.Location = new System.Drawing.Point(131, 45);
               this.txtRutaOrigen.Name = "txtRutaOrigen";
               this.txtRutaOrigen.Size = new System.Drawing.Size(714, 20);
               this.txtRutaOrigen.TabIndex = 2;
               // 
               // openFileDialog1
               // 
               this.openFileDialog1.FileName = "openFileDialog1";
               // 
               // btnCrearZip
               // 
               this.btnCrearZip.Location = new System.Drawing.Point(476, 347);
               this.btnCrearZip.Name = "btnCrearZip";
               this.btnCrearZip.Size = new System.Drawing.Size(99, 23);
               this.btnCrearZip.TabIndex = 4;
               this.btnCrearZip.Text = "Procesar";
               this.btnCrearZip.UseVisualStyleBackColor = true;
               this.btnCrearZip.Click += new System.EventHandler(this.btnCrearZip_Click);
               // 
               // txtRutaSalida
               // 
               this.txtRutaSalida.Location = new System.Drawing.Point(131, 77);
               this.txtRutaSalida.Name = "txtRutaSalida";
               this.txtRutaSalida.Size = new System.Drawing.Size(714, 20);
               this.txtRutaSalida.TabIndex = 6;
               // 
               // btnRutaSalida
               // 
               this.btnRutaSalida.Location = new System.Drawing.Point(12, 75);
               this.btnRutaSalida.Name = "btnRutaSalida";
               this.btnRutaSalida.Size = new System.Drawing.Size(99, 23);
               this.btnRutaSalida.TabIndex = 5;
               this.btnRutaSalida.Text = "Ruta Salida";
               this.btnRutaSalida.UseVisualStyleBackColor = true;
               this.btnRutaSalida.Click += new System.EventHandler(this.btnRutaSalida_Click);
               // 
               // cmbSistema
               // 
               this.cmbSistema.FormattingEnabled = true;
               this.cmbSistema.Location = new System.Drawing.Point(131, 12);
               this.cmbSistema.Name = "cmbSistema";
               this.cmbSistema.Size = new System.Drawing.Size(229, 21);
               this.cmbSistema.TabIndex = 7;
               this.cmbSistema.SelectedIndexChanged += new System.EventHandler(this.cmbSistema_SelectedIndexChanged);
               // 
               // btn_grabar
               // 
               this.btn_grabar.Location = new System.Drawing.Point(324, 347);
               this.btn_grabar.Name = "btn_grabar";
               this.btn_grabar.Size = new System.Drawing.Size(99, 23);
               this.btn_grabar.TabIndex = 8;
               this.btn_grabar.Text = "Grabar";
               this.btn_grabar.UseVisualStyleBackColor = true;
               this.btn_grabar.Click += new System.EventHandler(this.btn_grabar_Click);
               // 
               // lblSistema
               // 
               this.lblSistema.AutoSize = true;
               this.lblSistema.Location = new System.Drawing.Point(40, 14);
               this.lblSistema.Name = "lblSistema";
               this.lblSistema.Size = new System.Drawing.Size(44, 13);
               this.lblSistema.TabIndex = 9;
               this.lblSistema.Text = "Sistema";
               // 
               // labelCriterios
               // 
               this.labelCriterios.AutoSize = true;
               this.labelCriterios.Location = new System.Drawing.Point(16, 126);
               this.labelCriterios.Name = "labelCriterios";
               this.labelCriterios.Size = new System.Drawing.Size(199, 13);
               this.labelCriterios.TabIndex = 11;
               this.labelCriterios.Text = "Criterios a excluir (separados por comas):";
               // 
               // txtcriterios
               // 
               this.txtcriterios.Location = new System.Drawing.Point(12, 143);
               this.txtcriterios.Multiline = true;
               this.txtcriterios.Name = "txtcriterios";
               this.txtcriterios.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
               this.txtcriterios.Size = new System.Drawing.Size(833, 198);
               this.txtcriterios.TabIndex = 15;
               // 
               // btnEliminar
               // 
               this.btnEliminar.Location = new System.Drawing.Point(181, 347);
               this.btnEliminar.Name = "btnEliminar";
               this.btnEliminar.Size = new System.Drawing.Size(99, 23);
               this.btnEliminar.TabIndex = 16;
               this.btnEliminar.Text = "Eliminar";
               this.btnEliminar.UseVisualStyleBackColor = true;
               this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
               // 
               // Form1
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(857, 407);
               this.Controls.Add(this.btnEliminar);
               this.Controls.Add(this.txtcriterios);
               this.Controls.Add(this.labelCriterios);
               this.Controls.Add(this.lblSistema);
               this.Controls.Add(this.btn_grabar);
               this.Controls.Add(this.cmbSistema);
               this.Controls.Add(this.txtRutaSalida);
               this.Controls.Add(this.btnRutaSalida);
               this.Controls.Add(this.btnCrearZip);
               this.Controls.Add(this.txtRutaOrigen);
               this.Controls.Add(this.btnRuta);
               this.Name = "Form1";
               this.Text = "Compilacion";
               this.Load += new System.EventHandler(this.Form1_Load);
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.Button btnRuta;
          private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
          private System.Windows.Forms.TextBox txtRutaOrigen;
          private System.Windows.Forms.OpenFileDialog openFileDialog1;
          private System.Windows.Forms.Button btnCrearZip;
          private System.Windows.Forms.TextBox txtRutaSalida;
          private System.Windows.Forms.Button btnRutaSalida;
          private System.Windows.Forms.ComboBox cmbSistema;
          private System.Windows.Forms.Button btn_grabar;
          private System.Windows.Forms.Label lblSistema;
          private System.Windows.Forms.Label labelCriterios;
          private System.Windows.Forms.TextBox txtcriterios;
          private System.Windows.Forms.Button btnEliminar;
     }
}

