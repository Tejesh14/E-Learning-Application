using E_Learning.DAL.Authentication;
using E_Learning.DAL.Interface;
using E_Learning.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Repositories
{
    public class ChatRepository : IChatRepository
    {
        public readonly ApplicationDbContext _dbContext;

        public ChatRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Chat>> GetMessages(string sender, string reciever)
        {
            var chats = await _dbContext.Chats.Where(x => (x.SendFrom == sender && x.SendTo == reciever) || (x.SendFrom == reciever && x.SendTo == sender)).OrderBy(x=> x.SendAt).ToListAsync();
            return chats;
        }

        public async Task<Chat> SendMessage(Chat chat)
        {
            chat.Id = Guid.NewGuid().ToString();
            chat.SendAt = DateTime.Now;
            var chatData = await _dbContext.Chats.AddAsync(chat);
            await _dbContext.SaveChangesAsync();
            return chatData.Entity;
        }

        public async Task<Chat> DeleteMessage(string id, string username)
        {
            var findMessage = await _dbContext.Chats.FindAsync(id);
            if(findMessage.SendFrom == username)
            {
                var deletedChat = _dbContext.Chats.Remove(findMessage);
                await _dbContext.SaveChangesAsync();
                return deletedChat.Entity;
            }
            return null; 
        }
    }
}
