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
        public bool Create(Chat chat)
        {
            string sql = "INSERT INTO Chat (Content, Author, NUser_Id)";
            //var param = chat;
            return _connection.Execute(sql, chat) > 0;
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error encoding Chat: {ex.ToString}");
            //}
            //return false;
        }

        //public void CreateChat(Chat chat)
        //{
        //    string sql = "INSERT INTO Chat (Content, Author, NUser_Id) " +
        //        "VALUES (@content, @author, @nUser_Id)";
        //    //var param = chat;
        //    _connection.Query(sql, chat);
        //}

        public Chat? Delete(int chat_Id)
        {
            string sql = "DELETE FROM Chat WHERE Chat_Id = @chat_Id";
            var param = new { chat_Id };
            return _connection.QueryFirst<Chat>(sql, param);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error deleting Chat: {ex.ToString}");
            //}
            //return null;
        }

        public IEnumerable<Chat> GetAll()
        {
            string sql = "SELECT * FROM Chat";
            return _connection.Query<Chat>(sql);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error geting Chats : {ex.ToString}");
            //}
            //return new List<Chat>();
        }

        public Chat? GetById(int chat_Id)
        {
            string sql = "SELECT * FROM Chat WHERE Chat_Id = @chat_Id";
            var param = new { chat_Id };
            return _connection.QueryFirst<Chat>(sql, param);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error geting Chat: {ex.ToString}");
            //}
            //return new Chat();
        }
    }
}
