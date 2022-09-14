using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Models;

using myfinance_web_netcore.Infra;

namespace myfinance_web_netcore.Domain
{
    public class Transacao
    {

            public void Deletar(int id)
        {
            var objDAL = DAL.GetInstancia;
            objDAL.Conectar();
            string sql = $"DELETE FROM TRANSACTIONS WHERE ID = {id}";
            objDAL.ExecutarComandoSQL(sql);
            objDAL.Desconectar();
        }

            public void Atualizar (TransacaoModel formulario)            
        {

            var valor = Decimal.Parse(formulario.Valor.ToString())/100;
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = $"UPDATE TRANSACTIONS SET DATE = '{formulario.Data.ToString("yyyyMMdd")}'," +
                $"VALUE = {valor}, TYPE = '{formulario.Tipo}', HISTORY = '{formulario.Historico}', " +
                $"ACCOUNT_PLAN_ID = {formulario.IdPlanoConta}, " +
                $"PAYMENT_METHOD_ID = {formulario.IdPagamento} WHERE ID = {formulario.Id}";

            objDAL.ExecutarComandoSQL(sql);
            objDAL.Desconectar();
        }
        public void Inserir(TransacaoModel formulario)
        {
            var objDAL = DAL.GetInstancia;
            objDAL.Conectar();

            var sql = "INSERT INTO TRANSACTIONS(DATE, VALUE, TYPE, HISTORY, ACCOUNT_PLAN_ID, PAYMENT_METHOD_ID)  " +
            "VALUES(" +
            $"'{formulario.Data.ToString("yyyyMMdd")}',"+
            $"{formulario.Valor},"+
            $"'{formulario.Tipo}',"+            
            $"'{formulario.Historico}',"+
            $"{formulario.IdPlanoConta},"+
            $"{formulario.IdPagamento})";


            objDAL.ExecutarComandoSQL(sql);
            objDAL.Desconectar();
        }

            public TransacaoModel CarregarTransacaoPorId(int? id)
        {
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();

            var sql = $"SELECT ID, DATE, VALUE, TYPE, HISTORY, ACCOUNT_PLAN_ID, PAYMENT_METHOD_ID FROM TRANSACTIONS WHERE ID = {id}";
            var dataTable = objDAL.RetornarDataTable(sql);

                
    		var transacao = new TransacaoModel(){
                    Id = int.Parse (dataTable.Rows[0]["ID"].ToString()),
                    Historico = dataTable.Rows[0]["HISTORY"].ToString(),
                    Tipo = dataTable.Rows[0]["TYPE"].ToString(),
                    Data = DateTime.Parse(dataTable.Rows[0]["DATE"].ToString()),
                    Valor = decimal.Parse(dataTable.Rows[0]["VALUE"].ToString()),  
                    IdPlanoConta = int.Parse(dataTable.Rows[0]["ACCOUNT_PLAN_ID"].ToString()), 
                    IdPagamento = int.Parse(dataTable.Rows[0]["PAYMENT_METHOD_ID"].ToString())                           
                };

            objDAL.Desconectar();
            return transacao;
        }

        public List<TransacaoModel> ListaTransacoes()
        {
            List<TransacaoModel> lista = new List<TransacaoModel>();
            var objDAL = DAL.GetInstancia;
            objDAL.Conectar();

            var sql = "SELECT ID, DATE, VALUE, TYPE, HISTORY, ACCOUNT_PLAN_ID, PAYMENT_METHOD_ID FROM TRANSACTIONS ORDER BY DATE ASC";
            var dataTable = objDAL.RetornarDataTable(sql);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {

                var transacao = new TransacaoModel()
                {
                    Id = int.Parse(dataTable.Rows[i]["ID"].ToString()),
                    Data = DateTime.Parse(dataTable.Rows[i]["DATE"].ToString()),
                    Valor = decimal.Parse(dataTable.Rows[i]["VALUE"].ToString()),
                    Tipo = dataTable.Rows[i]["TYPE"].ToString(),
                    Historico = dataTable.Rows[i]["HISTORY"].ToString(),
                    IdPlanoConta = int.Parse(dataTable.Rows[i]["ACCOUNT_PLAN_ID"].ToString()),
                    IdPagamento = int.Parse(dataTable.Rows[i]["PAYMENT_METHOD_ID"].ToString())
                };

                lista.Add(transacao);
            }
            objDAL.Desconectar();

            return lista;
        }
    }
}