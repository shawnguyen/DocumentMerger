using System;
using System.IO;

namespace DocumentMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            //Application Title
            Console.WriteLine("Document Merger");

            //Operation
            do
            {
                //First File Operation
                Console.WriteLine("Enter name of 1st file:");
                string input1 = Console.ReadLine();
                string f1;

                //When First File is FALSE
                while (File.Exists(input1) == false)
                {
                    Console.WriteLine("File does not exsist, please enter a valid file:");
                    input1 = Console.ReadLine();
                }

                //When First File is TRUE
                if (File.Exists(input1) == true)
                {
                    try
                    {
                        //Writes out First File
                        StreamReader sr1 = new StreamReader(input1);
                        f1 = sr1.ReadLine();
                        while (f1 != null)
                        {
                            Console.WriteLine(f1);
                            f1 = sr1.ReadLine();
                        }
                        sr1.Close();
                        Console.ReadLine();
                    }
                    finally
                    {
                        Console.WriteLine("File has been opened.");
                    }
                }

                Console.WriteLine("\n");

                //Second File Operation
                Console.WriteLine("Enter name of 2nd file:");
                string input2 = Console.ReadLine();
                string f2;

                //When Second File is FALSE
                while (File.Exists(input2) == false)
                {
                    Console.WriteLine("File does not exsist, please enter a valid file:");
                    input2 = Console.ReadLine();
                }

                //When Second File is TRUE
                if (File.Exists(input2) == true)
                {
                    try
                    {
                        //Writes out Second File
                        StreamReader sr2 = new StreamReader(input2);
                        f2 = sr2.ReadLine();
                        while (f2 != null)
                        {
                            Console.WriteLine(f2);
                            f2 = sr2.ReadLine();
                        }
                        sr2.Close();
                        Console.ReadLine();
                    }
                    finally
                    {
                        Console.WriteLine("File has been opened.");
                    }
                }

                Console.WriteLine("\n");

                //Merging Operation
                string docMerge = input1 + input2 + ".txt";
                Console.WriteLine("Documents Being Merged: {0} & {1}", input1, input2);
                Console.WriteLine("New Merged Document Name: {0}", docMerge);

                string path1 = File.ReadAllText(input1);
                string path2 = File.ReadAllText(input2);

                Console.WriteLine("\n");

                //Character Count
                string Content = path1 + path2;
                int charCount = 0;
                foreach (char c in Content)
                {
                    if (char.IsLetter(c))
                    {
                        charCount++;
                    }
                }

                //Writing of Merged Documents
                StreamWriter doc = null;
                try
                {
                    doc = new StreamWriter(docMerge);
                    doc.WriteLine(path1);
                    doc.WriteLine(path2);
                    Console.WriteLine("{0} was successfully saved in the current directory. The document contains {1} characters.", docMerge, charCount);
                    doc.Close();
                }
                catch (Exception e1)
                {
                    Console.WriteLine("Exception: " + e1.Message);
                }
                finally
                {
                    if (doc != null)
                    {
                        doc.Close();
                    }
                }
                Console.WriteLine("Would you like to merge another set of documents? (Yes or No): ");
            } while (Console.ReadLine().ToLower().Equals("yes"));
        }
    }
}