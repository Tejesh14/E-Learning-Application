using E_Learning.BLL.Interface;
using E_Learning.DAL.Interface;
using E_Learning.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BLL.Service
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<List<Chat>> GetMessages(string sender, string reciever)
        {
            return await _chatRepository.GetMessages(sender, reciever);
        }

        public Task<Chat> SendMessage(Chat chat)
        {
            return _chatRepository.SendMessage(chat);
        }

        public Task<Chat> DeleteMessage(string id, string username)
        {
            return _chatRepository.DeleteMessage(id, username);
        }
    }
}
