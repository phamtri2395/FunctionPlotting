namespace Function_Plotting
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butt_Plot = new System.Windows.Forms.Button();
            this.txt_Expression = new System.Windows.Forms.TextBox();
            this.bluePrint1 = new Function_Plotting.BluePrint();
            ((System.ComponentModel.ISupportInitialize)(this.bluePrint1)).BeginInit();
            this.SuspendLayout();
            // 
            // butt_Plot
            // 
            this.butt_Plot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butt_Plot.Location = new System.Drawing.Point(466, 683);
            this.butt_Plot.Name = "butt_Plot";
            this.butt_Plot.Size = new System.Drawing.Size(75, 34);
            this.butt_Plot.TabIndex = 5;
            this.butt_Plot.Text = "Plot";
            this.butt_Plot.UseVisualStyleBackColor = true;
            this.butt_Plot.Click += new System.EventHandler(this.butt_Plot_Click);
            // 
            // txt_Expression
            // 
            this.txt_Expression.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Expression.Location = new System.Drawing.Point(12, 653);
            this.txt_Expression.Name = "txt_Expression";
            this.txt_Expression.Size = new System.Drawing.Size(984, 24);
            this.txt_Expression.TabIndex = 6;
            // 
            // bluePrint1
            // 
            this.bluePrint1.BackgroundColor = System.Drawing.Color.White;
            this.bluePrint1.isDrawGrid = true;
            this.bluePrint1.LinesWidth = 1;
            this.bluePrint1.Location = new System.Drawing.Point(12, 12);
            this.bluePrint1.Name = "bluePrint1";
            this.bluePrint1.RootPoint = new System.Drawing.Point(492, 317);
            this.bluePrint1.Size = new System.Drawing.Size(984, 635);
            this.bluePrint1.TabIndex = 7;
            this.bluePrint1.TabStop = false;
            this.bluePrint1.Unit = 20;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.bluePrint1);
            this.Controls.Add(this.txt_Expression);
            this.Controls.Add(this.butt_Plot);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.bluePrint1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butt_Plot;
        private System.Windows.Forms.TextBox txt_Expression;
        private BluePrint bluePrint1;
    }
}

