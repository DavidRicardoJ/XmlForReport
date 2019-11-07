using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace XmlForReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnLerXml_Click(object sender, EventArgs e)
        {
            string path = LocalArquivo();
            if (path != null)
            {
                DataTable dt = LoadXml(path);
                CarregarRelatorio(dt);
            }
        }
        private string LocalArquivo()
        {
            string path = null;
            openFileDialog.Title = "Localizar Arquivo XML";
            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "XML Files |*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }
            return path;
        }
        private DataTable LoadXml(string path)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds.ReadXml(path);
            dt = ds.Tables[0];
            return dt;
        }
        private void CarregarRelatorio(DataTable dt)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetAlunos", dt));
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.RefreshReport();
        }
    }
}
/*Arquivo XML 
 
<? xml version="1.0" encoding="UTF-8" standalone="yes"?>
<data-set xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
	<record>
		<NomedoAluno>Pedro Silva</NomedoAluno>
		<CPF>111.111.111-1</CPF>
		<Curso>Engenharia Computação</Curso>
		<AnoConclusão>2020</AnoConclusão>
	</record>
	<record>
		<NomedoAluno>João Silveira</NomedoAluno>
		<CPF>222.222.222-2</CPF>
		<Curso>Direito</Curso>
		<AnoConclusão>2021</AnoConclusão>
	</record>
	<record>
		<NomedoAluno>Amanda Cruz</NomedoAluno>
		<CPF>333.333.333-3</CPF>
		<Curso>Biologia</Curso>
		<AnoConclusão>2022</AnoConclusão>
	</record>
	<record>
		<NomedoAluno>Leticia Carvalho</NomedoAluno>
		<CPF>444.444.444-4</CPF>
		<Curso>Pedagogia</Curso>
		<AnoConclusão>2023</AnoConclusão>
	</record>
	<record>
		<NomedoAluno>Antonio Moraes</NomedoAluno>
		<CPF>555.555.555-5</CPF>
		<Curso>Matemática</Curso>
		<AnoConclusão>2024</AnoConclusão>
	</record>
</data-set>

    */
