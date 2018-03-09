namespace ProjetIA
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxArriveeX = new System.Windows.Forms.ComboBox();
            this.comboBoxDepartX = new System.Windows.Forms.ComboBox();
            this.comboBoxDepartY = new System.Windows.Forms.ComboBox();
            this.comboBoxArriveeY = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Envoyer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxArriveeX
            // 
            this.comboBoxArriveeX.FormattingEnabled = true;
            this.comboBoxArriveeX.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19"});
            this.comboBoxArriveeX.Location = new System.Drawing.Point(231, 6);
            this.comboBoxArriveeX.Name = "comboBoxArriveeX";
            this.comboBoxArriveeX.Size = new System.Drawing.Size(40, 21);
            this.comboBoxArriveeX.TabIndex = 1;
            // 
            // comboBoxDepartX
            // 
            this.comboBoxDepartX.CausesValidation = false;
            this.comboBoxDepartX.FormattingEnabled = true;
            this.comboBoxDepartX.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19"});
            this.comboBoxDepartX.Location = new System.Drawing.Point(63, 6);
            this.comboBoxDepartX.MaxDropDownItems = 19;
            this.comboBoxDepartX.Name = "comboBoxDepartX";
            this.comboBoxDepartX.Size = new System.Drawing.Size(40, 21);
            this.comboBoxDepartX.TabIndex = 2;
            // 
            // comboBoxDepartY
            // 
            this.comboBoxDepartY.FormattingEnabled = true;
            this.comboBoxDepartY.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19"});
            this.comboBoxDepartY.Location = new System.Drawing.Point(109, 6);
            this.comboBoxDepartY.Name = "comboBoxDepartY";
            this.comboBoxDepartY.Size = new System.Drawing.Size(40, 21);
            this.comboBoxDepartY.TabIndex = 3;
            // 
            // comboBoxArriveeY
            // 
            this.comboBoxArriveeY.FormattingEnabled = true;
            this.comboBoxArriveeY.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19"});
            this.comboBoxArriveeY.Location = new System.Drawing.Point(277, 6);
            this.comboBoxArriveeY.Name = "comboBoxArriveeY";
            this.comboBoxArriveeY.Size = new System.Drawing.Size(40, 21);
            this.comboBoxArriveeY.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Arrivée :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Départ :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(424, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Changer Form";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 635);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxArriveeY);
            this.Controls.Add(this.comboBoxDepartY);
            this.Controls.Add(this.comboBoxDepartX);
            this.Controls.Add(this.comboBoxArriveeX);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxArriveeX;
        private System.Windows.Forms.ComboBox comboBoxDepartX;
        private System.Windows.Forms.ComboBox comboBoxDepartY;
        private System.Windows.Forms.ComboBox comboBoxArriveeY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}

