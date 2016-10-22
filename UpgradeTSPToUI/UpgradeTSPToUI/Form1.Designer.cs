namespace UpgradeTSPToUI
{
    partial class frmMain
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblSoDiaDiem = new System.Windows.Forms.Label();
            this.lblDiaDiem = new System.Windows.Forms.Label();
            this.lstResultPath = new System.Windows.Forms.ListView();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.lstPlace = new System.Windows.Forms.ListView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnStartRoute = new System.Windows.Forms.Button();
            this.lblFinish = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.txtFinish = new System.Windows.Forms.TextBox();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.GMapView = new GMap.NET.WindowsForms.GMapControl();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Controls.Add(this.lblSoDiaDiem);
            this.pnlContent.Controls.Add(this.lblDiaDiem);
            this.pnlContent.Controls.Add(this.lstResultPath);
            this.pnlContent.Controls.Add(this.btnRemoveAll);
            this.pnlContent.Controls.Add(this.button2);
            this.pnlContent.Controls.Add(this.btnUp);
            this.pnlContent.Controls.Add(this.btnRemove);
            this.pnlContent.Controls.Add(this.btnFind);
            this.pnlContent.Controls.Add(this.lstPlace);
            this.pnlContent.Controls.Add(this.btnAdd);
            this.pnlContent.Controls.Add(this.btnSearch);
            this.pnlContent.Controls.Add(this.txtSearch);
            this.pnlContent.Controls.Add(this.btnStartRoute);
            this.pnlContent.Controls.Add(this.lblFinish);
            this.pnlContent.Controls.Add(this.lblStart);
            this.pnlContent.Controls.Add(this.txtFinish);
            this.pnlContent.Controls.Add(this.txtStart);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(200, 561);
            this.pnlContent.TabIndex = 0;
            // 
            // lblSoDiaDiem
            // 
            this.lblSoDiaDiem.AutoSize = true;
            this.lblSoDiaDiem.Location = new System.Drawing.Point(65, 534);
            this.lblSoDiaDiem.Name = "lblSoDiaDiem";
            this.lblSoDiaDiem.Size = new System.Drawing.Size(13, 13);
            this.lblSoDiaDiem.TabIndex = 17;
            this.lblSoDiaDiem.Text = "0";
            // 
            // lblDiaDiem
            // 
            this.lblDiaDiem.AutoSize = true;
            this.lblDiaDiem.Location = new System.Drawing.Point(0, 533);
            this.lblDiaDiem.Name = "lblDiaDiem";
            this.lblDiaDiem.Size = new System.Drawing.Size(70, 13);
            this.lblDiaDiem.TabIndex = 16;
            this.lblDiaDiem.Text = "Số địa điểm: ";
            // 
            // lstResultPath
            // 
            this.lstResultPath.Location = new System.Drawing.Point(3, 395);
            this.lstResultPath.Name = "lstResultPath";
            this.lstResultPath.Size = new System.Drawing.Size(188, 127);
            this.lstResultPath.TabIndex = 15;
            this.lstResultPath.UseCompatibleStateImageBehavior = false;
            this.lstResultPath.View = System.Windows.Forms.View.Tile;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(3, 366);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAll.TabIndex = 13;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(116, 366);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Down";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(116, 337);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 11;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(3, 337);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(116, 528);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 9;
            this.btnFind.Text = "Find Path";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lstPlace
            // 
            this.lstPlace.Location = new System.Drawing.Point(3, 181);
            this.lstPlace.Name = "lstPlace";
            this.lstPlace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstPlace.Size = new System.Drawing.Size(190, 150);
            this.lstPlace.TabIndex = 8;
            this.lstPlace.UseCompatibleStateImageBehavior = false;
            this.lstPlace.View = System.Windows.Forms.View.Tile;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(3, 152);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(118, 152);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(3, 126);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(190, 20);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            // 
            // btnStartRoute
            // 
            this.btnStartRoute.Location = new System.Drawing.Point(118, 94);
            this.btnStartRoute.Name = "btnStartRoute";
            this.btnStartRoute.Size = new System.Drawing.Size(75, 23);
            this.btnStartRoute.TabIndex = 4;
            this.btnStartRoute.Text = "Find";
            this.btnStartRoute.UseVisualStyleBackColor = true;
            this.btnStartRoute.Click += new System.EventHandler(this.btnStartRoute_Click);
            // 
            // lblFinish
            // 
            this.lblFinish.AutoSize = true;
            this.lblFinish.Location = new System.Drawing.Point(2, 45);
            this.lblFinish.Name = "lblFinish";
            this.lblFinish.Size = new System.Drawing.Size(84, 13);
            this.lblFinish.TabIndex = 3;
            this.lblFinish.Text = "Tọa độ kết thúc";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(4, 4);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(85, 13);
            this.lblStart.TabIndex = 2;
            this.lblStart.Text = "Tọa độ bắt đầu ";
            // 
            // txtFinish
            // 
            this.txtFinish.Location = new System.Drawing.Point(3, 68);
            this.txtFinish.Name = "txtFinish";
            this.txtFinish.Size = new System.Drawing.Size(190, 20);
            this.txtFinish.TabIndex = 1;
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(3, 23);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(190, 20);
            this.txtStart.TabIndex = 0;
            // 
            // GMapView
            // 
            this.GMapView.Bearing = 0F;
            this.GMapView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GMapView.CanDragMap = true;
            this.GMapView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GMapView.EmptyTileColor = System.Drawing.Color.Navy;
            this.GMapView.GrayScaleMode = false;
            this.GMapView.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.GMapView.LevelsKeepInMemmory = 5;
            this.GMapView.Location = new System.Drawing.Point(200, 0);
            this.GMapView.MarkersEnabled = true;
            this.GMapView.MaxZoom = 18;
            this.GMapView.MinZoom = 2;
            this.GMapView.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.GMapView.Name = "GMapView";
            this.GMapView.NegativeMode = false;
            this.GMapView.PolygonsEnabled = true;
            this.GMapView.RetryLoadTile = 0;
            this.GMapView.RoutesEnabled = true;
            this.GMapView.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.GMapView.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.GMapView.ShowTileGridLines = false;
            this.GMapView.Size = new System.Drawing.Size(584, 561);
            this.GMapView.TabIndex = 1;
            this.GMapView.Zoom = 5D;
            this.GMapView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GMapView_MouseClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.GMapView);
            this.Controls.Add(this.pnlContent);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Genetic Algorithm - TSP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private GMap.NET.WindowsForms.GMapControl GMapView;
        private System.Windows.Forms.TextBox txtFinish;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label lblFinish;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Button btnStartRoute;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lstPlace;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.ListView lstResultPath;
        private System.Windows.Forms.Label lblSoDiaDiem;
        private System.Windows.Forms.Label lblDiaDiem;
    }
}

