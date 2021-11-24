namespace EmpresaCadetes.DataBase
{
    public interface IIDBSQLite
    {
        RepositorioCadetesSQLite repositorioCadete { get; set; }
        RepositorioPedidosSQLite repositorioPedido { get; set; }
        RepositorioUsuariosSQLite repositorioUsuarios { get; set; }   
    }

    public class IDBSQLite : IIDBSQLite
    {
        public RepositorioCadetesSQLite repositorioCadete { get; set; }
        public RepositorioPedidosSQLite repositorioPedido { get; set; }
        public RepositorioUsuariosSQLite repositorioUsuarios { get; set; }

        public IDBSQLite(string connectionString)
        {
            repositorioCadete = new RepositorioCadetesSQLite(connectionString);
            repositorioPedido = new RepositorioPedidosSQLite(connectionString);
            repositorioUsuarios = new RepositorioUsuariosSQLite(connectionString);
        }
    }
}
