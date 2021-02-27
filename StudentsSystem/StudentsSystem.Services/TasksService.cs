using MySql.Data.MySqlClient;
using StudentsSystem.Data;
using StudentsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSystem.Services
{
    public class TasksService
    {
        private readonly MySqlDatabase db;

        public TasksService(MySqlDatabase db)
        {
            this.db = db;
        }

        public async Task<List<Data.Models.Task>> GetAllTasks()
        {
            List<Data.Models.Task> list = new List<Data.Models.Task>();
            var cmd = this.db.connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM test.tasks;";

            using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    var t = new Data.Models.Task()
                    {
                        TaskId = reader.GetFieldValue<int>(0),
                        Text = reader.GetFieldValue<string>(1)
                    };
                    if (!reader.IsDBNull(2))
                        t.Completed = reader.GetFieldValue<DateTime>(2);

                    list.Add(t);
                }

            return list;
        }
    }
}
