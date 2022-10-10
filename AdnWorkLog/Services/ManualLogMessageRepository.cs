using AdnWorkLog.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdnWorkLog.Services
{
    public class ManualLogMessageRepository
    {
        string _dbPath;

        private SQLiteAsyncConnection conn;

        public int TitleId { get; set; }

        public string StatusMessage { get; set; }

        async Task Init()
        {
            if (conn != null)
            {
                return;
            }
            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<ManualLogMessage>();
        }

        public ManualLogMessageRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        // Insert
        public async Task<int> AddNewLogMessage(string logMessage)
        {
            int result = -1;
            var insertingLogMessage = new ManualLogMessage()
            {
                Created = DateTime.Now,
                TitleId = this.TitleId,
                Message = logMessage,
            };
            try
            {
                await Init();
                if(insertingLogMessage.TitleId == 0)
                {
                    StatusMessage = "Fail to Add this Log. Lack TitleId";
                    return result;
                }
                result = await conn.InsertAsync(insertingLogMessage);
                result = insertingLogMessage.Id;
                StatusMessage = $"Add Log Message #{result}";
            }
            catch(Exception ex)
            {
                StatusMessage = $"Failed to add this Log Message. Error: {ex.Message}";
            }
            return result;
        }

        // Get All Records By Id
        public async Task<List<ManualLogMessage>> GetLogMessagesById(int titleId)
        {
            List<ManualLogMessage> manualLogMessages = new();
            try
            {
                await Init();
                manualLogMessages = await conn.Table<ManualLogMessage>().Where(m=>m.TitleId == titleId).ToListAsync();
                if(manualLogMessages.Count > 0)
                {
                    manualLogMessages = manualLogMessages.OrderByDescending(m => m.Id).ToList();
                    StatusMessage = $"Successfully pulled {manualLogMessages.Count} Tasks";
                }
                else
                {
                    StatusMessage = $"Welcome 🤗, please insert some data now";
                }
                this.TitleId = titleId;
            }
            catch(Exception ex)
            {
                StatusMessage = $"Failed to retrieve the data: {ex.Message}";
            }
            return manualLogMessages;
        }






    }
}
