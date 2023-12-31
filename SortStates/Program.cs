﻿/*
 * File Sort
 * Pawelski
 * 11/15/2023
 * Developing Desktop Applications
 * 
 * Instructions:
 * Before running the program, we will need to update the file
 * paths! Otherwise, this program will not work as intended.
 * Once the file paths are updated, what does the program do?
 * How many files are opened in this program? What file is being
 * read from? How many fields does each record have in the file?
 * Which files are being written to? How do you write information
 * to a file?
 * What does the following line of code do?
 * 
 * string[] recordArray = record.Split(DELIMITER);
 * 
 * What happens if you delete the following lines of code?
 * 
 * mnWriter.Close();
 * ilWriter.Close();
 * wiWriter.Close();
 * mnFile.Close();
 * ilFile.Close();
 * wiFile.Close();
 * originalReader.Close();
 * originalFile.Close();
 * 
 * What is the difference between the following FileModes?
 * FileMode.Create
 * FileMode.CreateNew
 * FileMode.Open
 * FileMode.Append
 * 
 * What is the difference between the following FileAccesses?
 * FileAccess.Read
 * FileAccess.Write
 * FileAccess.ReadWrite
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortFile
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ORIGINAL_FILE_PATH = @"SalesData.txt";
            const string WI_FILE_PATH = @"WISales.txt";
            const string IL_FILE_PATH = @"ILSales.txt";
            const string MN_FILE_PATH = @"MNSales.txt";
            const char DELIMITER = ',';
            
            // Open the original file to read from.
            FileStream originalFile = new FileStream(ORIGINAL_FILE_PATH, FileMode.Open, FileAccess.Read);
            StreamReader originalReader = new StreamReader(originalFile);

            // Create three files to sort the entries to.
            FileStream wiFile = new FileStream(WI_FILE_PATH, FileMode.Create, FileAccess.Write);
            StreamWriter wiWriter = new StreamWriter(wiFile);
            FileStream ilFile = new FileStream(IL_FILE_PATH, FileMode.Create, FileAccess.Write);
            StreamWriter ilWriter = new StreamWriter(ilFile);
            FileStream mnFile = new FileStream(MN_FILE_PATH, FileMode.Create, FileAccess.Write);
            StreamWriter mnWriter = new StreamWriter(mnFile);

            // Go through the original file and sort the contents into seperate files.
            while (!originalReader.EndOfStream)
            {
                string record = originalReader.ReadLine();
                string[] recordArray = record.Split(DELIMITER);
                if (recordArray[0] == "WI")
                {
                    wiWriter.WriteLine(record);
                }
                else if (recordArray[0] == "IL")
                {
                    ilWriter.WriteLine(record);
                }
                else if (recordArray[0] == "MN")
                {
                    mnWriter.WriteLine(record);
                }
            }

            mnWriter.Close();
            ilWriter.Close();
            wiWriter.Close();
            mnFile.Close();
            ilFile.Close();
            wiFile.Close();
            originalReader.Close();
            originalFile.Close();
        }
    }
}
