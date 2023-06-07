using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SeventhPractice
{
    public interface Int {
        public static int i = 10;
    }


    public delegate Task<string?> GetString(string s);
    public static class InfoGetter
    {
        
        public static async Task<string?> GetStringFromFile(string path)
        {
            // byte[] bytes = File.ReadAllBytes(path);
            try
            {
                using (var file = File.OpenText(path))
                {
                    return await file.ReadLineAsync();
                }
            }
            catch { MessageBox.Show("Ошибка при чтении файла"); }
            return null;
        }

        public static async Task<string?> GetStringFromDb(string dbConnectionString)
        {
            SQLiteAsyncConnection database;
            database = new SQLiteAsyncConnection(dbConnectionString);
            try
            {
                var line = await database.Table<TrafficLight>().FirstAsync();
                return line?.ToString();
            } catch { MessageBox.Show("Ошибка при подключении к БД"); }
            return null;
        }

        public static async Task<string?> GetStringFromSite(string url)
        {
            HttpClient client = new HttpClient();
            // определяем данные запроса
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            // выполняем запрос
            using HttpResponseMessage answer = await client.SendAsync(request);
            MessageBox.Show(answer.ToString());
            //var answer = await client.GetAsync(url);
            //answer = await client.GetAsync(url);
            if (answer.IsSuccessStatusCode)
            {
                return await answer.Content.ReadAsStringAsync();
            }
            MessageBox.Show("Ошибка при подключении к сайту");
            return null;
        }
    }
}
