using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Infra;

namespace myfinance_web_netcore.Models
{
    public class PlanoContaModel
    {
        public int? Id {get; set;}

        public string? Descricao {get; set;}

        public string? Tipo {get; set;}

        public PlanoContaModel()
		{
			Id = 0;
			Descricao = "";
			Tipo = "";
		}
			
        public void Inserir ()
        {
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = $"INSERT INTO ACCOUNT_PLANS(DESCRIPTION, TYPE) VALUES ('{Descricao}','{Tipo}')";
            objDAL.ExecutarComandoSQL(sql);
            objDAL.Desconectar();
        }


        public void Atualizar (int? id)
        {
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = $"UPDATE ACCOUNT_PLANS SET DESCRIPTION = '{Descricao}', TYPE = '{Tipo}' WHERE ID = {id}";

            objDAL.ExecutarComandoSQL(sql);
            objDAL.Desconectar();
        }

        public void Excluir (int id)
        {
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = $"DELETE FROM ACCOUNT_PLANS WHERE ID = {id}";
            objDAL.ExecutarComandoSQL(sql);
            objDAL.Desconectar();
        }

        public List<PlanoContaModel> ListaPlanoContas()
        {
            List<PlanoContaModel> lista = new List<PlanoContaModel>();
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = "SELECT ID, DESCRIPTION, TYPE FROM ACCOUNT_PLANS";
            var dataTable = objDAL.RetornarDataTable(sql);

            for (int i=0; i< dataTable.Rows.Count; i++)
            {
                
				var plano_conta = new PlanoContaModel(){
                    Id = int.Parse (dataTable.Rows[i]["ID"].ToString()),
                    Descricao = dataTable.Rows[i]["DESCRIPTION"].ToString(),
                    Tipo = dataTable.Rows[i]["TYPE"].ToString()                                        
                };
                lista.Add(plano_conta);
            }

            return lista;
        }

        public PlanoContaModel CarregarPlanoContaPorId(int? id)
        {
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = $"SELECT ID, DESCRIPTION, TYPE FROM ACCOUNT_PLANS WHERE ID = {id}";
            var dataTable = objDAL.RetornarDataTable(sql);

                
    		var plano_conta = new PlanoContaModel(){
                    Id = int.Parse (dataTable.Rows[0]["ID"].ToString()),
                    Descricao = dataTable.Rows[0]["DESCRIPTION"].ToString(),
                    Tipo = dataTable.Rows[0]["TYPE"].ToString()                                        
                };

            return plano_conta;
        }


    }
}
