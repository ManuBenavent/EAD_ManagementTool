namespace TimeManagementAndReportingTool
{
    partial class EventWeeklyView
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
            this.EventName = new System.Windows.Forms.Label();
            this.DateTimeLabel = new System.Windows.Forms.Label();
            this.EventTypeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EventName
            // 
            this.EventName.AutoSize = true;
            this.EventName.Location = new System.Drawing.Point(3, 0);
            this.EventName.Name = "EventName";
            this.EventName.Size = new System.Drawing.Size(85, 17);
            this.EventName.TabIndex = 0;
            this.EventName.Text = "Event Name";
            // 
            // DateTimeLabel
            // 
            this.DateTimeLabel.AutoSize = true;
            this.DateTimeLabel.Location = new System.Drawing.Point(3, 19);
            this.DateTimeLabel.Name = "DateTimeLabel";
            this.DateTimeLabel.Size = new System.Drawing.Size(105, 17);
            this.DateTimeLabel.TabIndex = 1;
            this.DateTimeLabel.Text = "01/01/20-00:00";
            // 
            // EventTypeLabel
            // 
            this.EventTypeLabel.AutoSize = true;
            this.EventTypeLabel.Location = new System.Drawing.Point(3, 39);
            this.EventTypeLabel.Name = "EventTypeLabel";
            this.EventTypeLabel.Size = new System.Drawing.Size(87, 17);
            this.EventTypeLabel.TabIndex = 2;
            this.EventTypeLabel.Text = "Appointment";
            // 
            // EventWeeklyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.EventTypeLabel);
            this.Controls.Add(this.DateTimeLabel);
            this.Controls.Add(this.EventName);
            this.Name = "EventWeeklyView";
            this.Size = new System.Drawing.Size(110, 65);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EventName;
        private System.Windows.Forms.Label DateTimeLabel;
        private System.Windows.Forms.Label EventTypeLabel;
    }
}
