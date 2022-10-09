using AdnWorkLog.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdnWorkLog.Services
{
    public class ManualTaskRepository
    {
        string _dbPath;

        private SQLiteAsyncConnection conn;
        
        public string StatusMessage { get; set; }

        async Task Init()
        {
            if(conn != null)
            {
                return;
            }
            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<ManualTask>();
        }

        public ManualTaskRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        // Insert 
        public async Task<int> AddNewManualTask(string taskName)
        {
            int result = -1;
            var insertingManualTask = new ManualTask()
            {
                Name = taskName,
                Created = DateTime.Now
            };
            try
            {
                await Init();
                if (string.IsNullOrEmpty(taskName))
                    throw new Exception("Valid Name is Required");    
                result = await conn.InsertAsync(insertingManualTask);
                result = insertingManualTask.Id;
                StatusMessage = $"Added Manual Task #{result}";
            }
            catch(Exception ex)
            {
                StatusMessage = $"Failed to add this Manual Task. Error: {ex.Message}";
            }
            return result;
        }

        // Delete a record
        public async Task<int> DeleteManualTask(int id)
        {
            int result = -1;
            try
            {
                await Init();
                await conn.DeleteAsync<ManualTask>(id);
                result = id;
                StatusMessage = $"Successfully Deleted Task #{result}";
            }
            catch(Exception ex)
            {
                StatusMessage = $"Failed to delete this MaunalTask. Error: {ex.Message}";
            }
            return result;
        }


        // Get All records
        public async Task<List<ManualTask>> GetAllManualTasks()
        {
            List<ManualTask> allManualTasks = new();
            try
            {
                await Init();
                allManualTasks = await conn.Table<ManualTask>().ToListAsync();
                if (allManualTasks.Count > 0)
                {
                    StatusMessage = $"Successfully pulled {allManualTasks.Count} Tasks";
                }
                else
                {
                    StatusMessage = $"Welcome 🤗, please insert some data now";
                }
            }
            catch(Exception ex)
            {
                StatusMessage = $"Failed to retrieve the data: {ex.Message}";
            }
            return allManualTasks;
        }

    }
}
