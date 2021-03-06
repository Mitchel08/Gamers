﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Interfaz_de_usuario.Class_
{
    public class Factura
    {
        int idFactura;
        string fecha;
        bool disponible;
        int idVenta;

        public Factura(int idFactura, string Fecha, bool disponible, int idVenta)
        {
            this.idFactura = idFactura;
            this.fecha = Fecha;
            this.disponible = disponible;
            this.idVenta = idVenta;
        }

        public int ID
        {
            get { return idFactura; }
            set { idFactura = value; }
        }

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public bool Disponible
        {
            get { return disponible; }
            set { disponible = value; }
        }

        public int ID_Venta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }

        public static int AgregarFactura(MySqlConnection Connection, Factura factura)
        {
            MySqlCommand command = new MySqlCommand(String.Format("INSERT INTO factura (fFecha, fDisponible, venta_IdVenta) VALUES ('{0}', true, {1})", factura.Fecha, factura.idVenta), Connection);
            int retorno = command.ExecuteNonQuery();
            return retorno;
        }

        public static IList<Factura> MostrarFacturas(MySqlConnection Connection)
        {
            List<Factura> Nfactura = new List<Factura>();
            MySqlCommand command = new MySqlCommand(String.Format("SELECT * FROM factura WHERE fDisponible = true"), Connection);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Factura factura = new Factura(reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2), reader.GetInt32(3));
                Nfactura.Add(factura);
            }
            return Nfactura;
        }

        public static IList<Factura> MostrarFacturasCancel(MySqlConnection Connection)
        {
            List<Factura> Nfactura = new List<Factura>();
            MySqlCommand command = new MySqlCommand(String.Format("SELECT * FROM factura WHERE fDisponible = false"), Connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Factura factura = new Factura(reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2), reader.GetInt32(3));
                Nfactura.Add(factura);
            }
            return Nfactura;
        }

        public static MySqlDataReader BuscarFactura(MySqlConnection Connection, string idFactura)
        {
            MySqlCommand command = new MySqlCommand(String.Format("SELECT * FROM factura WHERE idFactura = '{0}'", idFactura), Connection);
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public static int CancelarFactura(MySqlConnection Connection, string idfactura)
        {
            MySqlCommand command = new MySqlCommand(String.Format("UPDATE factura SET fDisponible = false WHERE idFactura = {0}", idfactura), Connection);
            int retorno = command.ExecuteNonQuery();
            return retorno;
        }
    }
}
