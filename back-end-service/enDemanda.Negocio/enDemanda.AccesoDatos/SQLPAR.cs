using enDemanda.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASB.AccesoDatos
{

    public class SQLPAR : IDisposable
    {
        /// <summary>
        /// sTransaccionAbierta
        /// </summary>
        private const string sTransaccionAbierta = "Usted debe cerrar la transacción que se encuentra abierta.";
        private const string sTransaccionCommit = "Usted intentó hacer Commit sobre una transacción que no estaba abierta.";
        private const string sTransaccionRollback = "Usted intentó hacer Rollback sobre una transacción que no estaba abierta.";

        /// <summary>
        /// Acceso al Modelo
        /// </summary>
        public Entities ModeloCASB { get; set; }

        /// <summary>
        /// Internal Connection
        /// </summary>
        internal IDbConnection _SqlConnection = null;

        /// <summary>
        /// Cadena de conexion en String
        /// </summary>
        internal string _SQLStringConnection = null;

        /// <summary>
        /// Internal del Transaction
        /// </summary>         
        internal System.Data.Common.DbTransaction _SqlTransaction = null;

        /// <summary>
        /// Bool Para Encolar Transacciones
        /// </summary>
        internal bool _EncolaTransacciones = false;

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="Password"></param>
        public SQLPAR(string ConnectionString)
        {
            ModeloCASB = new Entities(Entities.GetConnectionString(ConnectionString));
            ModeloCASB.Database.CommandTimeout = 2400;
            _SqlConnection = ModeloCASB.Database.Connection;
        }


        /// <summary>
        /// Inicio de la Transaccion
        /// </summary>
        public void TransactionBegin()
        {
            //Si Encola Transacciones, no Inica la transaccion
            if (!_EncolaTransacciones)
            {
                if (_SqlTransaction != null)
                {
                    throw new InvalidOperationException(sTransaccionAbierta);
                }

                //Abro la Conexion
                if (this._SqlConnection.State != ConnectionState.Open)
                {
                    this._SqlConnection.Open();
                }

                //Inicializo la Transaccion
                _SqlTransaction = ModeloCASB.Database.Connection.BeginTransaction();

                //Asigno la Transaccion
                ModeloCASB.Database.UseTransaction(_SqlTransaction);
            }
        }

        /// <summary>
        /// Inicio de la Transaccion
        /// </summary>
        public void TransactionBegin(bool EncolaTransacciones)
        {
            //Asigno la Variable
            _EncolaTransacciones = EncolaTransacciones;

            //Si debe Encolar Transacciones
            if (EncolaTransacciones)
            {
                if (_SqlTransaction == null)
                {
                    //Abro la Conexion
                    if (this._SqlConnection.State != ConnectionState.Open)
                    {
                        this._SqlConnection.Open();
                    }

                    //Inicializo la Transaccion
                    _SqlTransaction = ModeloCASB.Database.Connection.BeginTransaction();

                    //Asigno la Transaccion
                    ModeloCASB.Database.UseTransaction(_SqlTransaction);
                }
            }
            else
            {
                TransactionBegin();
            }
        }


        /// <summary>
        /// Commit de la Transaccion
        /// </summary>
        public void TransactionCommit()
        {
            //Si la Bandera No esta Activa, no realiza Commit
            if (!_EncolaTransacciones)
            {
                //Si realizo Commit sobre una transaccion 
                //No Abierta
                if (_SqlTransaction == null)
                {
                    throw new InvalidOperationException(sTransaccionCommit);
                }

                //Realizo Commit
                _SqlTransaction.Commit();

                //Finalizo la conexion
                if (this._SqlConnection.State == ConnectionState.Open)
                {
                    this._SqlConnection.Close();
                }
                _SqlTransaction = null;
            }
        }

        /// <summary>
        /// Commit de la Transaccion
        /// </summary>
        public void TransactionCommit(bool FinalizaTransaccionesEncoladas)
        {
            if (FinalizaTransaccionesEncoladas && _EncolaTransacciones)
            {
                //Modifico la Bandera
                _EncolaTransacciones = false;

                //Realizo Commit
                _SqlTransaction.Commit();

                //Finalizo la conexion
                if (this._SqlConnection.State == ConnectionState.Open)
                {
                    this._SqlConnection.Close();
                }
                _SqlTransaction = null;
            }
            else
            {
                TransactionCommit();
            }
        }


        /// <summary>
        /// Realiza RollBack de la Transaccion
        /// </summary>
        public void TransactionRollback()
        {
            if (_SqlTransaction == null)
            {
                throw new InvalidOperationException(sTransaccionRollback);
            }

            try
            {
                //Realizo RollBack
                _SqlTransaction.Rollback();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }



            //Finalizo la Conexion
            if (this._SqlConnection.State == ConnectionState.Open)
            {
                this._SqlConnection.Close();
            }

            if (_SqlConnection != null)
            {
                _SqlConnection.Dispose();
            }
            _SqlTransaction = null;
        }


        /// <summary>
        /// Inicio de la Transaccion
        /// </summary>
        public void ConnectionClose()
        {
            //Si Encola Transacciones, no Inica la transaccion
            if (_SqlConnection.State != ConnectionState.Closed)
            {
                _SqlConnection.Close();
            }

            if (_SqlConnection != null)
            {
                _SqlConnection.Dispose();
            }
        }

        #region IDisposable Members 

        /// <summary>
        /// Finalizador
        /// </summary>
        ~SQLPAR()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        /// <summary>
        /// Dispose de la Clase
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose de la Clase
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (ModeloCASB != null)
                {
                    ModeloCASB.Dispose();
                    ModeloCASB = null;
                }

                if (_SqlConnection != null)
                {
                    _SqlConnection.Dispose();
                    _SqlConnection = null;
                }

                if (_SqlTransaction != null)
                {
                    _SqlTransaction.Dispose();
                    _SqlTransaction = null;
                }
            }
        }

        #endregion
    }
}
