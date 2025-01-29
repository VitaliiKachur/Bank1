namespace Bank
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cardNumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pinTextBox = new System.Windows.Forms.TextBox();
            this.authenticateButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBalanceButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.withdrawButton = new System.Windows.Forms.Button();
            this.withdrawAmountTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.transferButton = new System.Windows.Forms.Button();
            this.recipientCardTextBox = new System.Windows.Forms.TextBox();
            this.transferAmountTextBox = new System.Windows.Forms.TextBox();
            this.messagesListBox = new System.Windows.Forms.ListBox();
            this.logoutButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(75, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ведіть номер картки ";
            // 
            // cardNumberTextBox
            // 
            this.cardNumberTextBox.Location = new System.Drawing.Point(79, 62);
            this.cardNumberTextBox.Name = "cardNumberTextBox";
            this.cardNumberTextBox.Size = new System.Drawing.Size(203, 20);
            this.cardNumberTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(474, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ведіть PIN";
            // 
            // pinTextBox
            // 
            this.pinTextBox.Location = new System.Drawing.Point(478, 62);
            this.pinTextBox.Name = "pinTextBox";
            this.pinTextBox.Size = new System.Drawing.Size(192, 20);
            this.pinTextBox.TabIndex = 3;
            // 
            // authenticateButton
            // 
            this.authenticateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.authenticateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authenticateButton.ForeColor = System.Drawing.Color.AliceBlue;
            this.authenticateButton.Location = new System.Drawing.Point(318, 86);
            this.authenticateButton.Name = "authenticateButton";
            this.authenticateButton.Size = new System.Drawing.Size(144, 33);
            this.authenticateButton.TabIndex = 4;
            this.authenticateButton.Text = "Увійти";
            this.authenticateButton.UseVisualStyleBackColor = false;
            this.authenticateButton.Click += new System.EventHandler(this.authenticateButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(75, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Перевірити баланс";
            // 
            // checkBalanceButton
            // 
            this.checkBalanceButton.BackColor = System.Drawing.Color.Yellow;
            this.checkBalanceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBalanceButton.ForeColor = System.Drawing.Color.Navy;
            this.checkBalanceButton.Location = new System.Drawing.Point(306, 152);
            this.checkBalanceButton.Name = "checkBalanceButton";
            this.checkBalanceButton.Size = new System.Drawing.Size(166, 36);
            this.checkBalanceButton.TabIndex = 6;
            this.checkBalanceButton.Text = "Перевірити баланс";
            this.checkBalanceButton.UseVisualStyleBackColor = false;
            this.checkBalanceButton.Click += new System.EventHandler(this.checkBalanceButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(75, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Зняття коштів";
            // 
            // withdrawButton
            // 
            this.withdrawButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.withdrawButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.withdrawButton.ForeColor = System.Drawing.Color.Navy;
            this.withdrawButton.Location = new System.Drawing.Point(518, 215);
            this.withdrawButton.Name = "withdrawButton";
            this.withdrawButton.Size = new System.Drawing.Size(134, 37);
            this.withdrawButton.TabIndex = 8;
            this.withdrawButton.Text = "Зняти кошти";
            this.withdrawButton.UseVisualStyleBackColor = false;
            this.withdrawButton.Click += new System.EventHandler(this.withdrawButton_Click);
            // 
            // withdrawAmountTextBox
            // 
            this.withdrawAmountTextBox.Location = new System.Drawing.Point(277, 225);
            this.withdrawAmountTextBox.Name = "withdrawAmountTextBox";
            this.withdrawAmountTextBox.Size = new System.Drawing.Size(187, 20);
            this.withdrawAmountTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(75, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Переказ коштів";
            // 
            // transferButton
            // 
            this.transferButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.transferButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.transferButton.ForeColor = System.Drawing.Color.Navy;
            this.transferButton.Location = new System.Drawing.Point(518, 316);
            this.transferButton.Name = "transferButton";
            this.transferButton.Size = new System.Drawing.Size(134, 51);
            this.transferButton.TabIndex = 11;
            this.transferButton.Text = "Перерахувати кошти";
            this.transferButton.UseVisualStyleBackColor = false;
            this.transferButton.Click += new System.EventHandler(this.transferButton_Click);
            // 
            // recipientCardTextBox
            // 
            this.recipientCardTextBox.Location = new System.Drawing.Point(276, 310);
            this.recipientCardTextBox.Name = "recipientCardTextBox";
            this.recipientCardTextBox.Size = new System.Drawing.Size(187, 20);
            this.recipientCardTextBox.TabIndex = 12;
            // 
            // transferAmountTextBox
            // 
            this.transferAmountTextBox.Location = new System.Drawing.Point(276, 370);
            this.transferAmountTextBox.Name = "transferAmountTextBox";
            this.transferAmountTextBox.Size = new System.Drawing.Size(186, 20);
            this.transferAmountTextBox.TabIndex = 13;
            // 
            // messagesListBox
            // 
            this.messagesListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.messagesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messagesListBox.ForeColor = System.Drawing.Color.Blue;
            this.messagesListBox.FormattingEnabled = true;
            this.messagesListBox.ItemHeight = 16;
            this.messagesListBox.Location = new System.Drawing.Point(704, 35);
            this.messagesListBox.Name = "messagesListBox";
            this.messagesListBox.Size = new System.Drawing.Size(513, 340);
            this.messagesListBox.TabIndex = 14;
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logoutButton.ForeColor = System.Drawing.Color.White;
            this.logoutButton.Location = new System.Drawing.Point(489, 411);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(153, 54);
            this.logoutButton.TabIndex = 15;
            this.logoutButton.Text = "Завершити операції";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(252, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(248, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Введіть карту для переказу";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(272, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Введіть суму переказу";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1278, 477);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.messagesListBox);
            this.Controls.Add(this.transferAmountTextBox);
            this.Controls.Add(this.recipientCardTextBox);
            this.Controls.Add(this.transferButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.withdrawAmountTextBox);
            this.Controls.Add(this.withdrawButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBalanceButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.authenticateButton);
            this.Controls.Add(this.pinTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cardNumberTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cardNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pinTextBox;
        private System.Windows.Forms.Button authenticateButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button checkBalanceButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button withdrawButton;
        private System.Windows.Forms.TextBox withdrawAmountTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button transferButton;
        private System.Windows.Forms.TextBox recipientCardTextBox;
        private System.Windows.Forms.TextBox transferAmountTextBox;
        private System.Windows.Forms.ListBox messagesListBox;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

