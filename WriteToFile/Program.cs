/*
 * Write to File
 * Pawelski
 * 11/15/2023
 * Developing Desktop Applications
 * 
 * Instructions:
 * Before running the program, we will need to update the file
 * paths! Otherwise, this program will not work as intended.
 * How is this program similar to programs that read from a file?
 * How is it different? What line of code actually writes text
 * to the file? What happens if you delete the following lines of
 * code?
 * 
 * writer.Close();
 * file.Close();
 * 
 * How is the code for reading and writing to a file similar to the
 * code for interacting with the console?
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            // Opening the file to write to.
            const string FILE_PATH = @"GroceryList.txt";
            FileStream file = new FileStream(FILE_PATH, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);

            // Prompt the user to enter items to add to the list.
            string item, repeat;
            do
            {
                Console.Write("Enter an item to add to the list >> ");
                item = Console.ReadLine();
                writer.WriteLine(item);
                Console.Write("Do you want to add another item? (Y/N) >> ");
                repeat = Console.ReadLine();
                Console.WriteLine();
            } while (repeat == "Y");

            // Closes the stream and file.
            writer.Close();
            file.Close();
        }
    }
}
