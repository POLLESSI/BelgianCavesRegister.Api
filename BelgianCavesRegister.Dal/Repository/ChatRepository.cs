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
            try
            {
                string sql = "INSERT INTO Chat (NewMessage, Author) VALUES " + "(@NewMessage, @Author)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@NewMessage", chat.NewMessage);
                parameters.Add("@Author", chat.Author);
                return _connection.Execute(sql, parameters) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error encoding Chat: {ex.ToString}");
            }
            return false;
        }

        public void CreateChat(Chat chat)
        {
            try
            {
                string sql = "INSERT INTO Chat (NewMessage, Author, NUser_Id) " +
                "VALUES (@newMessage, @author)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@newMessage", chat.NewMessage);
                parameters.Add("@author", chat.Author);
                _connection.Query(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error CreateChat : {ex.ToString}");
            }
            
        }

        public Chat? Delete(int chat_Id)
        {
            try
            {
                string sql = "DELETE FROM Chat WHERE Chat_Id = @chat_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@chat_Id", chat_Id);
                return _connection.QueryFirst<Chat>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting Chat: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Chat> GetAll()
        {
            string sql = "SELECT * FROM Chat";
            return _connection.Query<Chat>(sql);
        }

        public Chat? GetById(int chat_Id)
        {
            try
            {
                string sql = "SELECT * FROM Chat WHERE Chat_Id = @chat_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@chat_Id");
                return _connection.QueryFirst<Chat>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Chat: {ex.ToString}");
            }
            return new Chat();
        }
    }
}
