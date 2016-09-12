using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;

namespace HáziKöltségNyilvántartó.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (var lifetimeScope = Program.Container.BeginLifetimeScope())
            {
                var form = lifetimeScope.Resolve<LoginForm>();
                if (form.ShowDialog() != DialogResult.OK)
                {
                    Close();
                }
            }
        }

        

        private void költségvetésMegjelenítéseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lifetimeScope = Program.Container.BeginLifetimeScope();
            KoltsegvetesMegjelenitese km = lifetimeScope.Resolve<KoltsegvetesMegjelenitese>();
            km.MdiParent = this;
            km.WindowState = FormWindowState.Maximized;
            km.Show();
            km.FormClosed += delegate
            {
                lifetimeScope.Dispose();
            };
        }

        private void termékekFelviteleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lifetimeScope = Program.Container.BeginLifetimeScope();
            TermekekFelvitele tf = lifetimeScope.Resolve<TermekekFelvitele>();
            tf.MdiParent = this;
            tf.WindowState = FormWindowState.Maximized;
            tf.Show();
            tf.FormClosed += delegate
            {
                lifetimeScope.Dispose();
            };
        }

        private void statisztikákToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lifetimeScope = Program.Container.BeginLifetimeScope();
            StatisticsForm st = lifetimeScope.Resolve<StatisticsForm>();
            st.MdiParent = this;
            st.WindowState = FormWindowState.Maximized;
            st.Show();
            st.FormClosed += delegate
            {
                lifetimeScope.Dispose();
            };
        }
    }
}
