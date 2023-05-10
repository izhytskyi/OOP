using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // 1) Створення каталогу на диску E:
        string directoryPath = @"E:\OOP_lab08";
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            Console.WriteLine($"Каталог {directoryPath} створено успішно.");
        }

        // 2) Створення каталогів в середині каталогу OOP_lab08:
        string[] subdirectories = { "kn1b21", "Izhytskyi", "Sources", "Reports", "Texts" };
        foreach (string subdirectory in subdirectories)
        {
            string path = Path.Combine(directoryPath, subdirectory);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine($"Каталог {path} створено успішно.");
            }
        }

        // 3) Копіювання каталогів Texts, Sources та Reports до каталогу Izhytskyi:
        string sourceDirectoryPath = Path.Combine(directoryPath, "Texts");
        string destinationDirectoryPath = Path.Combine(directoryPath, "Izhytskyi");
        string[] directoriesToCopy = { "Texts", "Sources", "Reports" };
        foreach (string directoryToCopy in directoriesToCopy)
        {
            string sourcePath = Path.Combine(directoryPath, directoryToCopy);
            string destinationPath = Path.Combine(destinationDirectoryPath, directoryToCopy);
            if (Directory.Exists(sourcePath))
            {
                Directory.CreateDirectory(destinationPath);
                foreach (string file in Directory.GetFiles(sourcePath))
                {
                    string destinationFile = Path.Combine(destinationPath, Path.GetFileName(file));
                    File.Copy(file, destinationFile, true);
                }
                Console.WriteLine($"Каталог {directoryToCopy} скопійовано до {destinationDirectoryPath}.");
            }
            else
            {
                Console.WriteLine($"Каталог {sourcePath} не існує.");
            }
        }

        // 4) Переміщення каталогу Izhytskyi до каталогу kn1b21:
        string source = Path.Combine(directoryPath, "Izhytskyi");
        string destination = Path.Combine(directoryPath, "kn1b21", "Izhytskyi");
        if (Directory.Exists(source))
        {
            Directory.Move(source, destination);
            Console.WriteLine($"Каталог {source} переміщено до {destination}.");
        }
        else
        {
            Console.WriteLine($"Каталог {source} не існує.");
        }

        // 5) Створення текстового файлу dirinfo.txt у каталозі Texts з інформацією про каталог:
        string directoryInfoPath = Path.Combine(directoryPath, "Texts", "dirinfo.txt");
        using (StreamWriter writer = new StreamWriter(directoryInfoPath))
        {
            writer.WriteLine($"Інформація про каталог {directoryPath}:");
            writer.WriteLine($"Кількість файлів: {Directory.GetFiles(directoryPath).Length}");
            writer.WriteLine($"Кількість підкаталогів: {Directory.GetDirectories(directoryPath).Length}");
            writer.WriteLine($"Дата створення: {Directory.GetCreationTime(directoryPath)}");
            writer.WriteLine($"Дата зміни: {Directory.GetLastWriteTime(directoryPath)}");
            Console.WriteLine($"Файл {directoryInfoPath} створено успішно.");
        }
        Console.ReadLine();
    }
}
