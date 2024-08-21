namespace Altalents.Report.Library
{
    partial class Experience
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.entreprise = new Telerik.Reporting.TextBox();
            this.poste = new Telerik.Reporting.TextBox();
            this.panel1 = new Telerik.Reporting.Panel();
            this.debut = new Telerik.Reporting.TextBox();
            this.panel2 = new Telerik.Reporting.Panel();
            this.contexte = new Telerik.Reporting.TextBox();
            this.panel3 = new Telerik.Reporting.Panel();
            this.equipe = new Telerik.Reporting.TextBox();
            this.panel4 = new Telerik.Reporting.Panel();
            this.taches = new Telerik.Reporting.TextBox();
            this.panel5 = new Telerik.Reporting.Panel();
            this.environnement = new Telerik.Reporting.TextBox();
            this.dinamicEnv = new Telerik.Reporting.TextBox();
            this.experienceDso = new Telerik.Reporting.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(14.5D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1,
            this.panel2,
            this.panel3,
            this.panel4,
            this.panel5});
            this.detail.Name = "detail";
            // 
            // entreprise
            // 
            this.entreprise.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.3D));
            this.entreprise.Name = "entreprise";
            this.entreprise.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.3D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.entreprise.Style.Color = System.Drawing.Color.White;
            this.entreprise.Style.Font.Bold = true;
            this.entreprise.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.entreprise.Value = "= Fields.Entreprise";
            // 
            // poste
            // 
            this.poste.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0.9D));
            this.poste.Name = "poste";
            this.poste.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.3D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.poste.Style.Color = System.Drawing.Color.White;
            this.poste.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.poste.Value = "= Fields.IntitulePoste";
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.entreprise,
            this.debut,
            this.poste});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.7D), Telerik.Reporting.Drawing.Unit.Cm(0.4D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.6D), Telerik.Reporting.Drawing.Unit.Cm(1.9D));
            this.panel1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            // 
            // debut
            // 
            this.debut.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.2D), Telerik.Reporting.Drawing.Unit.Cm(0.3D));
            this.debut.Name = "debut";
            this.debut.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.4D), Telerik.Reporting.Drawing.Unit.Cm(1.2D));
            this.debut.Style.BorderColor.Left = System.Drawing.Color.White;
            this.debut.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.debut.Style.Color = System.Drawing.Color.White;
            this.debut.Style.Font.Italic = true;
            this.debut.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.debut.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.debut.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.debut.Value = "= Fields.PlageExperience";
            // 
            // panel2
            // 
            this.panel2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.contexte});
            this.panel2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.7D), Telerik.Reporting.Drawing.Unit.Cm(2.3D));
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.6D), Telerik.Reporting.Drawing.Unit.Cm(2.7D));
            this.panel2.Style.BorderColor.Bottom = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.panel2.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.panel2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // contexte
            // 
            this.contexte.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.contexte.Name = "contexte";
            this.contexte.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.3D), Telerik.Reporting.Drawing.Unit.Cm(2.7D));
            this.contexte.Style.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.contexte.Style.Color = System.Drawing.Color.Black;
            this.contexte.Style.Font.Bold = true;
            this.contexte.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.contexte.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.contexte.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.contexte.Value = "Contexte";
            // 
            // panel3
            // 
            this.panel3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.equipe});
            this.panel3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.7D), Telerik.Reporting.Drawing.Unit.Cm(5D));
            this.panel3.Name = "panel3";
            this.panel3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.6D), Telerik.Reporting.Drawing.Unit.Cm(1.1D));
            this.panel3.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.panel3.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // equipe
            // 
            this.equipe.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.equipe.Name = "equipe";
            this.equipe.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.3D), Telerik.Reporting.Drawing.Unit.Cm(1.1D));
            this.equipe.Style.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.equipe.Style.Color = System.Drawing.Color.Black;
            this.equipe.Style.Font.Bold = true;
            this.equipe.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.equipe.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.equipe.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.equipe.Value = "Equipe";
            // 
            // panel4
            // 
            this.panel4.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.taches});
            this.panel4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.7D), Telerik.Reporting.Drawing.Unit.Cm(6.1D));
            this.panel4.Name = "panel4";
            this.panel4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.6D), Telerik.Reporting.Drawing.Unit.Cm(2.7D));
            this.panel4.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.panel4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // taches
            // 
            this.taches.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.taches.Name = "taches";
            this.taches.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.3D), Telerik.Reporting.Drawing.Unit.Cm(2.7D));
            this.taches.Style.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.taches.Style.Color = System.Drawing.Color.Black;
            this.taches.Style.Font.Bold = true;
            this.taches.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.taches.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.taches.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.taches.Value = "Tâches";
            // 
            // panel5
            // 
            this.panel5.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.environnement,
            this.dinamicEnv});
            this.panel5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.7D), Telerik.Reporting.Drawing.Unit.Cm(8.8D));
            this.panel5.Name = "panel5";
            this.panel5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(19.6D), Telerik.Reporting.Drawing.Unit.Cm(1.7D));
            this.panel5.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.panel5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // environnement
            // 
            this.environnement.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.environnement.Name = "environnement";
            this.environnement.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.3D), Telerik.Reporting.Drawing.Unit.Cm(1.7D));
            this.environnement.Style.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.environnement.Style.Color = System.Drawing.Color.Black;
            this.environnement.Style.Font.Bold = true;
            this.environnement.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.environnement.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.environnement.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.environnement.Value = "Environnement Technique";
            // 
            // dinamicEnv
            // 
            this.dinamicEnv.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.9D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.dinamicEnv.Name = "dinamicEnv";
            this.dinamicEnv.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(11.7D), Telerik.Reporting.Drawing.Unit.Cm(1.699D));
            this.dinamicEnv.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.dinamicEnv.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.dinamicEnv.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.dinamicEnv.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.dinamicEnv.Value = "= Fields.FormatedEnvironnement";
            // 
            // experienceDso
            // 
            this.experienceDso.DataSource = typeof(Altalents.Report.Library.DSO.ExperienceDso);
            this.experienceDso.Name = "experienceDso";
            // 
            // Experience
            // 
            this.DataSource = this.experienceDso;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "Experience";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(20D), Telerik.Reporting.Drawing.Unit.Mm(20D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(21D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.DetailSection detail;
        public Telerik.Reporting.ObjectDataSource experienceDso;
        private Telerik.Reporting.TextBox entreprise;
        private Telerik.Reporting.TextBox poste;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox debut;
        private Telerik.Reporting.Panel panel2;
        private Telerik.Reporting.TextBox contexte;
        private Telerik.Reporting.Panel panel3;
        private Telerik.Reporting.TextBox equipe;
        private Telerik.Reporting.Panel panel4;
        private Telerik.Reporting.TextBox taches;
        private Telerik.Reporting.Panel panel5;
        private Telerik.Reporting.TextBox environnement;
        private Telerik.Reporting.TextBox dinamicEnv;
    }
}