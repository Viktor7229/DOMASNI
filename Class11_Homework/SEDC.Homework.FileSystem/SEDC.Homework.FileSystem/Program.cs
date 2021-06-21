using System;
using System.Collections.Generic;
using System.IO;


namespace SEDC.Homework.FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi user! Choose what do you want to do!");
            Console.WriteLine("1) Create a directory\n2) Create a new .txt file\n3) Delete Folder/File");
            int userChoise = Convert.ToInt32(Console.ReadLine());
            string relativApplicationPath = @"..\..\..\";
            if (userChoise == 1)
            {
                Console.Write("Please enter a valid name for your folder: ");
                string folderName = Console.ReadLine();
                string fullPath = string.Format(@"{0}\{1}", relativApplicationPath, folderName);

                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"New directory with name {folderName} created successfully!");
                    Console.ResetColor();
                }
            }
            else if (userChoise == 2)
            {
                Console.WriteLine("Please enter a valid name for your file!");
                string fileName = Console.ReadLine();

                string fullFilePath = string.Format(@"{0}\{1}", relativApplicationPath, fileName);

                if (!File.Exists(fullFilePath))
                {
                    File.Create(fullFilePath).Close();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"New file with name {fileName} created successfully!");
                    Console.ResetColor();
                }

                Console.WriteLine("Do you want to input some text in your file - Enter Y/N");
                string userTextInput = Console.ReadLine();

                if (userTextInput.ToLower() == "y")
                {
                    Console.WriteLine("Enter your text that you want to be stored in the file: ");
                    string textContent = Console.ReadLine();
                    if (File.Exists(fullFilePath))
                    {
                        File.WriteAllText(fullFilePath, textContent);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("The text was successfully entered! Please check your file!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Something went wrong! The file probably doesn't exist!");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.WriteLine("Okey! Have a good day!");
                }
            }
            else if (userChoise == 3)
            {
                string[] folders = Directory.GetDirectories(relativApplicationPath);
                string[] files = Directory.GetFiles(relativApplicationPath);

                Console.WriteLine("---------------------------------");
                Console.WriteLine("Delete:\n1) File\n2) Folder");
                Console.WriteLine("---------------------------------");
                int deleteChoise = Convert.ToInt32(Console.ReadLine());
                if(deleteChoise == 1)
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Available Files:");
                    foreach (string file in files)
                    {
                        string fileName = file.Substring(9);
                        Console.WriteLine(fileName);
                    }
                    Console.WriteLine("-------------------------------");
                    Console.Write("Insert the name of the file you would like to delete: ");
                    string deleteFile = Console.ReadLine();
                    bool fileDeleted = false;

                    foreach (string file in files)
                    {
                        string fileName = file.Substring(9);
                        if(fileName.ToLower() == deleteFile.ToLower())
                        {
                            File.Delete($@"{relativApplicationPath}\{fileName}");
                            fileDeleted = true;
                        }
                    }

                    ConsoleColor fileMessageColor = fileDeleted == true ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed;
                    string deletedFileMessage = fileDeleted == true ? "Successfully Deleted File!" : "No Such File Name!";
                    
                    Console.ForegroundColor = fileMessageColor;
                    Console.WriteLine(deletedFileMessage);
                    Console.ResetColor();

                } else if(deleteChoise == 2)
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Available Folders:");
                    foreach (string folder in folders)
                    {
                        string folderName = folder.Substring(9);
                        Console.WriteLine(folderName);
                    }
                    Console.WriteLine("-------------------------------");
                    Console.Write("Insert the name of the folder you would like to delete: ");
                    string deleteFolder = Console.ReadLine();
                    bool folderDeleted = false;

                    foreach (string folder in folders)
                    {
                        string folderName = folder.Substring(9);
                        if (folderName.ToLower() == deleteFolder.ToLower())
                        {
                            Directory.Delete($@"{relativApplicationPath}\{folderName}");
                            folderDeleted = true;
                        }
                    }

                    ConsoleColor folderMessageColor = folderDeleted == true ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed;
                    string deletedFolderMessage = folderDeleted == true ? "Successfully Deleted Folder!" : "No Such Folder Name!";

                    Console.ForegroundColor = folderMessageColor;
                    Console.WriteLine(deletedFolderMessage);
                    Console.ResetColor();
                } else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input!");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid Input!");
                Console.ResetColor();
            }
            Console.ReadLine();
        }
    }
}
