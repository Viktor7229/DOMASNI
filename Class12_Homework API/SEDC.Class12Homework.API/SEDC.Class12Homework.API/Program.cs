using Newtonsoft.Json;
using SEDC.Class12Homework.API.Entities;
using SEDC.Class12Homework.API.Helpers;
using SEDC.Class12Homework.API.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace SEDC.Class12Homework.API
{
    class Program
    {
        static string folderPath = @"..\..\..\Data";
        static string filePath = folderPath + @"\DataJson.json";
        static string postFilePath = folderPath + @"\PostJsonData.json";
        static string commentFilePath = folderPath + @"\CommentJsonData.json";

        

        public static void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("Successfully created folder!");
            }
        }

        public static void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                Console.WriteLine("Successfully created file!");
            }
        }

        public static void WriteInFile(string path, string data)
        {
            // Mora da se prebrise bidejki vo jsonot izleguva warning
            File.WriteAllText(path, string.Empty);
            if (File.Exists(path))
            {
                
                ReaderWriter.WriteFile(path, data);
            }
        }
        static void Main(string[] args)
        {

            string userUrl = "http://jsonplaceholder.typicode.com/users";
            string userResult = HttpService.GetData(userUrl);

            string postUrl = "https://jsonplaceholder.typicode.com/posts";
            string postResult = HttpService.GetData(postUrl);

            string commentUrl = "https://jsonplaceholder.typicode.com/comments";
            string commentResult = HttpService.GetData(commentUrl);

            CreateFolder(folderPath);

            CreateFile(filePath);
            WriteInFile(filePath, userResult);

            CreateFile(postFilePath);
            WriteInFile(postFilePath, postResult);

            CreateFile(commentFilePath);
            WriteInFile(commentFilePath, commentResult);

            Console.ReadLine();
        }
    }
}
