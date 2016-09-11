﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HáziKöltségNyilvántartó.DataLayer;
using HáziKöltségNyilvántartó.ViewModels;
using HáziKöltségNyilvántartó.Exceptions;

namespace HáziKöltségNyilvántartó.Forms
{
    public partial class LoginForm : Form
    {
        private LoginViewModel _viewModel;
        private string hash;
        public LoginForm(LoginViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void regisztráció_Click(object sender, EventArgs e)
        {
            try
            {
                _viewModel.Registration(usernameBox.Text, passwordBox.Text, hash);
            }
            catch(RegistrationException re)
            {
                MessageBox.Show(re.Message);
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                try
                {
                    _viewModel.Login(passwordBox.Text, hash);
                }
                catch (LoginException le)
                {
                    MessageBox.Show(le.Message);
                    e.Cancel = true;
                }
            }
        }

        private void usernameBox_Validated(object sender, EventArgs e)
        {
            hash = _viewModel.GetCorrectPasswordHash(usernameBox.Text);
        }
    }
}
