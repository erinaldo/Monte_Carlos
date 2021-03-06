﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monte_Carlos
{
    public partial class Login : Form
    {
        IniciarSecion user = new IniciarSecion();
        Conexion conexion = new Conexion();
        public Login()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            btnIniciar.ForeColor = Color.White;

            if (txtContraseña.Text == "" && txtUsuario.Text == "")
            {
                MessageBox.Show("Campos vacios.", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    /*conexion.conectar();
                    this.Hide();
                    Modulos ventana = new Modulos();
                    ventana.Show();
                    */
                    IniciarSecion login = user.BucarUsuario(txtUsuario.Text);

                    if (login.Password == txtContraseña.Text)
                    {
                        MessageBox.Show("Bienvenido al sistema.");

                        conexion.conectar();

                        this.Hide();
                        Menu ventana = new Menu();
                        ventana.Show();

                    }
                    else { MessageBox.Show("DATOS INCORRECTOS"); }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }


        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            txtContraseña.PasswordChar = '●';
        }

        private void txtContraseña_MouseClick(object sender, MouseEventArgs e)
        {
            txtContraseña.Text = "";
            panel2.BackColor = Color.FromArgb(217, 4, 142);
        }

        private void txtUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            txtUsuario.Text = "";
            panel1.BackColor = Color.FromArgb(217, 4, 142);
        }
    }
}
