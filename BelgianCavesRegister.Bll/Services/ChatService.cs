using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using BelgianCavesRegister.Bll.BllInterfaces;

namespace BelgianCavesRegister.Bll.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public void AddChat(string newMessage, string author)
        {
            try
            {
                _chatRepository.AddChat(newMessage, author);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool Create(Chat chat)
        {
            try
            {
                _chatRepository.Create(chat);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating chat: {ex.ToString}");
            }
            return true;
        }

        public Chat? Delete(int chat_Id)
        {
            try
            {
                return _chatRepository.Delete(chat_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting chat: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Chat?> GetAll()
        {
            try
            {
                return _chatRepository.GetAll();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting all bibliographies: {ex.ToString}");
            }
            return Enumerable.Empty<Chat?>();
        }

        public Chat? GetById(int chat_Id)
        {
            try
            {
                return _chatRepository.GetById(chat_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting chat: {ex.ToString}");
            }
            return new Chat();
        }
    }
}
