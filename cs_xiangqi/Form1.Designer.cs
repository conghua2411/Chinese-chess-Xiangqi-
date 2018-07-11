namespace cs_xiangqi
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.picBox_Board = new System.Windows.Forms.PictureBox();
            this.pb_piecesSelected = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_new = new System.Windows.Forms.Button();
            this.lb_turn = new System.Windows.Forms.Label();
            this.btn_restart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Board)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_piecesSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.picBox_Board);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.btn_restart);
            this.splitContainer.Panel2.Controls.Add(this.lb_turn);
            this.splitContainer.Panel2.Controls.Add(this.pb_piecesSelected);
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Panel2.Controls.Add(this.btn_new);
            this.splitContainer.Size = new System.Drawing.Size(576, 428);
            this.splitContainer.SplitterDistance = 431;
            this.splitContainer.TabIndex = 0;
            // 
            // picBox_Board
            // 
            this.picBox_Board.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox_Board.Image = global::cs_xiangqi.Properties.Resources.chinese_chess_board_2;
            this.picBox_Board.Location = new System.Drawing.Point(0, 0);
            this.picBox_Board.Name = "picBox_Board";
            this.picBox_Board.Size = new System.Drawing.Size(431, 428);
            this.picBox_Board.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_Board.TabIndex = 1;
            this.picBox_Board.TabStop = false;
            this.picBox_Board.Paint += new System.Windows.Forms.PaintEventHandler(this.picBox_Board_Paint);
            this.picBox_Board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picBox_Board_MouseClick);
            // 
            // pb_piecesSelected
            // 
            this.pb_piecesSelected.Location = new System.Drawing.Point(37, 150);
            this.pb_piecesSelected.Name = "pb_piecesSelected";
            this.pb_piecesSelected.Size = new System.Drawing.Size(60, 56);
            this.pb_piecesSelected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_piecesSelected.TabIndex = 2;
            this.pb_piecesSelected.TabStop = false;
            this.pb_piecesSelected.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_piecesSelected_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pieces selected";
            // 
            // btn_new
            // 
            this.btn_new.Enabled = false;
            this.btn_new.Location = new System.Drawing.Point(37, 49);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(75, 23);
            this.btn_new.TabIndex = 0;
            this.btn_new.Text = "new";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // lb_turn
            // 
            this.lb_turn.AutoSize = true;
            this.lb_turn.ForeColor = System.Drawing.Color.Red;
            this.lb_turn.Location = new System.Drawing.Point(34, 241);
            this.lb_turn.Name = "lb_turn";
            this.lb_turn.Size = new System.Drawing.Size(48, 13);
            this.lb_turn.TabIndex = 3;
            this.lb_turn.Text = "Red turn";
            // 
            // btn_restart
            // 
            this.btn_restart.Location = new System.Drawing.Point(37, 88);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(75, 23);
            this.btn_restart.TabIndex = 4;
            this.btn_restart.Text = "restart";
            this.btn_restart.UseVisualStyleBackColor = true;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 428);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Xiangqi";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Board)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_piecesSelected)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PictureBox picBox_Board;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.PictureBox pb_piecesSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_turn;
        private System.Windows.Forms.Button btn_restart;
    }
}

