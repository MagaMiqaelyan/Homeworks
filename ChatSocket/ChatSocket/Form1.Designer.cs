namespace ChatSocket
{
    partial class Chat
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
            this.groupFriend = new System.Windows.Forms.GroupBox();
            this.textPortFriend = new System.Windows.Forms.TextBox();
            this.textIpFriend = new System.Windows.Forms.TextBox();
            this.labelPortFriend = new System.Windows.Forms.Label();
            this.labelIpFriend = new System.Windows.Forms.Label();
            this.listMessage = new System.Windows.Forms.ListBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textSendMessage = new System.Windows.Forms.TextBox();
            this.groupMe = new System.Windows.Forms.GroupBox();
            this.textPortMe = new System.Windows.Forms.TextBox();
            this.textIpMe = new System.Windows.Forms.TextBox();
            this.labelPortMe = new System.Windows.Forms.Label();
            this.labelIpMe = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.groupFriend.SuspendLayout();
            this.groupMe.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupFriend
            // 
            this.groupFriend.Controls.Add(this.textPortFriend);
            this.groupFriend.Controls.Add(this.textIpFriend);
            this.groupFriend.Controls.Add(this.labelPortFriend);
            this.groupFriend.Controls.Add(this.labelIpFriend);
            this.groupFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupFriend.Location = new System.Drawing.Point(388, 17);
            this.groupFriend.Name = "groupFriend";
            this.groupFriend.Size = new System.Drawing.Size(270, 100);
            this.groupFriend.TabIndex = 13;
            this.groupFriend.TabStop = false;
            this.groupFriend.Text = "Friend";
            // 
            // textPortFriend
            // 
            this.textPortFriend.Location = new System.Drawing.Point(108, 57);
            this.textPortFriend.Multiline = true;
            this.textPortFriend.Name = "textPortFriend";
            this.textPortFriend.Size = new System.Drawing.Size(156, 27);
            this.textPortFriend.TabIndex = 6;
            // 
            // textIpFriend
            // 
            this.textIpFriend.Location = new System.Drawing.Point(108, 23);
            this.textIpFriend.Multiline = true;
            this.textIpFriend.Name = "textIpFriend";
            this.textIpFriend.Size = new System.Drawing.Size(156, 28);
            this.textIpFriend.TabIndex = 5;
            // 
            // labelPortFriend
            // 
            this.labelPortFriend.AutoSize = true;
            this.labelPortFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPortFriend.Location = new System.Drawing.Point(6, 60);
            this.labelPortFriend.Name = "labelPortFriend";
            this.labelPortFriend.Size = new System.Drawing.Size(40, 20);
            this.labelPortFriend.TabIndex = 1;
            this.labelPortFriend.Text = "Port";
            // 
            // labelIpFriend
            // 
            this.labelIpFriend.AutoSize = true;
            this.labelIpFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIpFriend.Location = new System.Drawing.Point(6, 23);
            this.labelIpFriend.Name = "labelIpFriend";
            this.labelIpFriend.Size = new System.Drawing.Size(21, 18);
            this.labelIpFriend.TabIndex = 0;
            this.labelIpFriend.Text = "IP";
            // 
            // listMessage
            // 
            this.listMessage.FormattingEnabled = true;
            this.listMessage.ItemHeight = 16;
            this.listMessage.Location = new System.Drawing.Point(22, 150);
            this.listMessage.Name = "listMessage";
            this.listMessage.Size = new System.Drawing.Size(843, 292);
            this.listMessage.TabIndex = 12;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConnect.Location = new System.Drawing.Point(759, 51);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(106, 46);
            this.buttonConnect.TabIndex = 11;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textSendMessage
            // 
            this.textSendMessage.Location = new System.Drawing.Point(22, 473);
            this.textSendMessage.Multiline = true;
            this.textSendMessage.Name = "textSendMessage";
            this.textSendMessage.Size = new System.Drawing.Size(745, 43);
            this.textSendMessage.TabIndex = 10;
            // 
            // groupMe
            // 
            this.groupMe.Controls.Add(this.textPortMe);
            this.groupMe.Controls.Add(this.textIpMe);
            this.groupMe.Controls.Add(this.labelPortMe);
            this.groupMe.Controls.Add(this.labelIpMe);
            this.groupMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupMe.Location = new System.Drawing.Point(22, 17);
            this.groupMe.Name = "groupMe";
            this.groupMe.Size = new System.Drawing.Size(270, 100);
            this.groupMe.TabIndex = 9;
            this.groupMe.TabStop = false;
            this.groupMe.Text = "Me";
            // 
            // textPortMe
            // 
            this.textPortMe.Location = new System.Drawing.Point(108, 57);
            this.textPortMe.Multiline = true;
            this.textPortMe.Name = "textPortMe";
            this.textPortMe.Size = new System.Drawing.Size(156, 27);
            this.textPortMe.TabIndex = 6;
            // 
            // textIpMe
            // 
            this.textIpMe.Location = new System.Drawing.Point(108, 23);
            this.textIpMe.Multiline = true;
            this.textIpMe.Name = "textIpMe";
            this.textIpMe.Size = new System.Drawing.Size(156, 28);
            this.textIpMe.TabIndex = 5;
            // 
            // labelPortMe
            // 
            this.labelPortMe.AutoSize = true;
            this.labelPortMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPortMe.Location = new System.Drawing.Point(6, 60);
            this.labelPortMe.Name = "labelPortMe";
            this.labelPortMe.Size = new System.Drawing.Size(40, 20);
            this.labelPortMe.TabIndex = 1;
            this.labelPortMe.Text = "Port";
            // 
            // labelIpMe
            // 
            this.labelIpMe.AutoSize = true;
            this.labelIpMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIpMe.Location = new System.Drawing.Point(6, 23);
            this.labelIpMe.Name = "labelIpMe";
            this.labelIpMe.Size = new System.Drawing.Size(21, 18);
            this.labelIpMe.TabIndex = 0;
            this.labelIpMe.Text = "IP";
            // 
            // buttonSend
            // 
            this.buttonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSend.Location = new System.Drawing.Point(773, 473);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(92, 43);
            this.buttonSend.TabIndex = 8;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 536);
            this.Controls.Add(this.groupFriend);
            this.Controls.Add(this.listMessage);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textSendMessage);
            this.Controls.Add(this.groupMe);
            this.Controls.Add(this.buttonSend);
            this.Name = "Chat";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Chat_Load);
            this.groupFriend.ResumeLayout(false);
            this.groupFriend.PerformLayout();
            this.groupMe.ResumeLayout(false);
            this.groupMe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupFriend;
        private System.Windows.Forms.TextBox textPortFriend;
        private System.Windows.Forms.TextBox textIpFriend;
        private System.Windows.Forms.Label labelPortFriend;
        private System.Windows.Forms.Label labelIpFriend;
        private System.Windows.Forms.ListBox listMessage;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textSendMessage;
        private System.Windows.Forms.GroupBox groupMe;
        private System.Windows.Forms.TextBox textPortMe;
        private System.Windows.Forms.TextBox textIpMe;
        private System.Windows.Forms.Label labelPortMe;
        private System.Windows.Forms.Label labelIpMe;
        private System.Windows.Forms.Button buttonSend;
    }
}

