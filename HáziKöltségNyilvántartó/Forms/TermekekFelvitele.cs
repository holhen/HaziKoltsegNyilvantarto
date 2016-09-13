using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.IO;
using HáziKöltségNyilvántartó.ViewModels;

namespace HáziKöltségNyilvántartó
{
    public partial class TermekekFelvitele : Form
    {
        private BindingList<ItemCategory> _itemCategoryList = new BindingList<ItemCategory>();
        private TermekekFelviteleViewModel _viewModel; 

        public TermekekFelvitele(TermekekFelviteleViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void TermekekFelvitele_Load(object sender, EventArgs e)
        {
            itemCategoryBindingSource.DataSource = _itemCategoryList;
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            itemCategoryBindingSource.CancelEdit();
            OpenOpenFileDialog();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _itemCategoryList.Clear();
            foreach (var item in _viewModel.LoadDataFromDatabase())
            {
                _itemCategoryList.Add(item);
            }

            OpenSaveFileDialog();           
        }

        private void adatbázisbaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            _viewModel.SaveDataToDatabase(_itemCategoryList.ToList());
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //try
            //{
                List<ItemCategory> icl = _viewModel.ReadCsvFile((string)e.Argument);
                Invoke(new Action(() =>
                  {
                      _itemCategoryList.Clear();
                      foreach (var item in icl)
                          _itemCategoryList.Add(item);
                  }));
                _viewModel.SaveDataToDatabase(_itemCategoryList.ToList());
            //}
            //catch
            //{
            //    MessageBox.Show("Nem megfelelő fájlt adott meg.");
            //}
        }

        private void cSVFájlbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSaveFileDialog();
        }

        private void OpenSaveFileDialog()
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Filter = "Csv fájlok (*.csv)| *.csv|Minden fájl (*.*)|*.*";
                save.OverwritePrompt = true;
                save.AddExtension = true;
                save.DefaultExt = ".csv";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    backgroundWorker2.RunWorkerAsync(save.FileName);
                }
            }
        }

        private void OpenOpenFileDialog()
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.CheckFileExists = true;
                open.Multiselect = false;
                open.Filter = "Csv fájlok (*.csv)|*.csv|Minden fájl (*.*)|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    backgroundWorker1.RunWorkerAsync(open.FileName);
                }
            }
        }

        private void backgroundWorker2_DoWork_1(object sender, DoWorkEventArgs e)
        {
            _viewModel.SaveCsvFile(_itemCategoryList.ToList(), (string)e.Argument);
        }
    }
}

