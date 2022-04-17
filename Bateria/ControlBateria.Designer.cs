
namespace Bateria
{
    partial class ControlBateria
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ControlBateria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ControlBateria";
            this.Size = new System.Drawing.Size(150, 300);
            this.Load += new System.EventHandler(this.ControlBateria_Load);
            this.DoubleClick += new System.EventHandler(this.ControlBateria_DoubleClick);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.ControlBateria_Layout);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlBateria_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlBateria_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlBateria_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
