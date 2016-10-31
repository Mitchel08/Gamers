﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz_de_usuario
{
    public partial class Menu_Principal_Administrador : Form
    {
        Class_.Empleado Empleado;
        Class_.Connection CConnection;

        public Menu_Principal_Administrador(Class_.Empleado Empleado, Class_.Connection CConnection)
        {
            InitializeComponent();

            labelName.Text = "Bienvenido\n" + Empleado.Nombre + " " + Empleado.Apellido;
            this.Empleado = Empleado;
            this.CConnection = CConnection;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonVenta_Click(object sender, EventArgs e)
        {
            Menu_Venta menu_venta = new Menu_Venta(CConnection, Empleado);
            menu_venta.ShowDialog();
        }

        private void buttonCompra_Click(object sender, EventArgs e)
        {
            Menu_Compra menu_compra = new Menu_Compra(CConnection, Empleado);
            menu_compra.ShowDialog();
        }

        private void buttonInventario_Click(object sender, EventArgs e)
        {
            Menu_Inventario menu_inventario = new Menu_Inventario(CConnection);
            menu_inventario.ShowDialog();
        }

        private void buttonCliente_Click(object sender, EventArgs e)
        {
            Menu_Clientes menu_clientes = new Menu_Clientes(CConnection);
            menu_clientes.ShowDialog();
        }

        private void buttonEmpleado_Click(object sender, EventArgs e)
        {
            Menu_Empleado menu_empleado = new Menu_Empleado(CConnection);
            menu_empleado.ShowDialog();
        }

        private void buttonFactura_Click(object sender, EventArgs e)
        {
            Menu_Factura menu_factura = new Menu_Factura(CConnection);
            menu_factura.ShowDialog();
        }

        private void buttonReportesVentacompra_Click(object sender, EventArgs e)
        {
            ReportesVentaCompra reportesventacompra = new ReportesVentaCompra(CConnection);
            reportesventacompra.ShowDialog();
        }
    }
}
