using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace BelgianCavesRegister.Dal.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly SqlConnection _connection;
        public ChatRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public void AddChat(string newMessage, string author)
        {
            string sql = "INSERT INTO Chat (Content, Author, NUser_Id) VALUES " +
                "(@content, @author, @nUser_Id)";
            var param = new { newMessage, author };
            _connection.Query(sql, param);
        }

        public bool Create(Chat chat)
        {
            string sql = "INSERT INTO Chat (Content, Author, NUser_Id)";
            var param = new { chat };
            return _connection.Execute(sql, param) > 0;
        }

        public Chat? Delete(int chat_Id)
        {
            string sql = "DELETE FROM Chat WHERE Chat_Id = @chat_Id";
            var param = new { chat_Id };
            return _connection.QueryFirst<Chat>(sql, param);
        }

        public IEnumerable<Chat> GetAll()
        {
            string sql = "SELECT * FROM Chat";
            return _connection.Query<Chat>(sql);
        }

        public Chat? GetById(int chat_Id)
        {
            string sql = "SELECT * FROM Chat WHERE Chat_Id = @chat_Id";
            var param = new { chat_Id };
            return _connection.QueryFirst<Chat>(sql, param);
        }
    }
}
