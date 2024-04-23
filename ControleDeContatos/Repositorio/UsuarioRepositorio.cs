using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DataBaseContext _dataBaseContext;
        public UsuarioRepositorio(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        UsuarioModel IUsuarioRepositorio.BuscarPorLogin(string login)
        {
            return _dataBaseContext.tbusuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }
        public UsuarioModel ListarPorId(int id)
        {
            return _dataBaseContext.tbusuarios.FirstOrDefault(x => x.Id == id);
        }

        List<UsuarioModel> IUsuarioRepositorio.BuscarTodos()
        {
            return _dataBaseContext.tbusuarios.ToList();
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            // Gravar no banco de dados
            usuario.DataCadastro = DateTime.Now;
            _dataBaseContext.tbusuarios.Add(usuario);
            _dataBaseContext.SaveChanges();
            return usuario;
        }
        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do Usuário");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = usuario.DataAtualizacao = DateTime.Now;

            _dataBaseContext.tbusuarios.Update(usuarioDB);
            _dataBaseContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new System.Exception($"Houve um problema ao APAGAR o usuário {id}");

            _dataBaseContext.tbusuarios.Remove(usuarioDB);
            _dataBaseContext.SaveChanges();

            return true;


        }


    }
}
