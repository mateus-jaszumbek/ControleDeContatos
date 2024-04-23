using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly DataBaseContext _dataBaseContext;
        public ContatoRepositorio(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public ContatoModel ListarPorId(int id)
        {
            return _dataBaseContext.tbcontatos.FirstOrDefault(x => x.Id == id);
        }

        List<ContatoModel> IContatoRepositorio.BuscarTodos()
        {
            return _dataBaseContext.tbcontatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            // Gravar no banco de dados
            _dataBaseContext.tbcontatos.Add(contato);
            _dataBaseContext.SaveChanges();
            return contato;
        }
        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _dataBaseContext.tbcontatos.Update(contatoDB);
            _dataBaseContext.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel ContatoDB = ListarPorId(id);

            if (ContatoDB == null) throw new System.Exception($"Houve um problema ao APAGAR o contato {id}");

            _dataBaseContext.tbcontatos.Remove(ContatoDB);
            _dataBaseContext.SaveChanges();

            return true;


        }
    }
}
