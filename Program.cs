using NLog.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace midterm
{
class Program
    {   

        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {

            logger.Info("Program Started.");

            string file = null;
            string choice;

            do
            {
                // ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Add data to file.");
                Console.WriteLine("3) Search files.");
                Console.WriteLine("Enter any other key to exit.");
                choice = Console.ReadLine();
                
                if (choice == "1")
                {
                    do
                    {
                        Console.WriteLine("Select the file to be read:");
                        Console.WriteLine("1) Tickets.csv");
                        Console.WriteLine("2) Task.csv");
                        Console.WriteLine("3) Enhancements.csv");
                        Console.WriteLine("Enter any other key to exit.");
                        choice = Console.ReadLine();

                        if(choice == "1") {
                            file = "Tickets.csv";
                        } else if(choice == "2") {
                            file = "Task.csv";
                        } else if(choice == "3") {
                            file = "Enhancements.csv";
                        }
                            // read data from file
                            if (File.Exists(file))
                            {
                                StreamReader sr = new StreamReader(file);
                                logger.Info($"Reading {file}");
                                Console.WriteLine($"Reading from file {file}. \n" );
                                while (!sr.EndOfStream)
                                {
                                    string line = sr.ReadLine();
                                    Console.WriteLine(line);   
                                }
                                sr.Close();
                                Console.WriteLine($"\n{file} read.");
                                logger.Info($"\n{file} read.");

                            }
                            else
                            {
                                Console.WriteLine("File does not exist");
                                logger.Error("File does not exist.");
                            }

                    } while (choice == "1" || choice == "2" || choice == "3");

                }

                else if (choice == "2")
                {

                    Console.WriteLine("Select the type of ticket to create:");
                    Console.WriteLine("1) Bug/Defect");
                    Console.WriteLine("2) Task");
                    Console.WriteLine("3) Enhancements");
                    Console.WriteLine("Enter any other key to exit.");
                    choice = Console.ReadLine();

                    // create file from data
                        if(choice == "1") {
                            file = "Tickets.csv";
                            Bug ticket = new Bug();
                            StreamWriter sw = new StreamWriter(file, true);
                                for (int i = 0; i < 8; i++)
                                {
                                    // ask a question
                                    Console.WriteLine("Enter a ticket (Y/N)?");
                                    // input the response
                                    string resp = Console.ReadLine().ToUpper();
                                    // if the response is anything other than "Y", stop asking
                                    if (resp != "Y") {
                                        break; 
                                    } else {
                                    Console.WriteLine("Enter Ticket ID (numbers)");
                                    ticket.ticketID = Convert.ToInt16(Console.ReadLine());

                                    Console.WriteLine("Enter Ticket Summary:");
                                    ticket.summary = Console.ReadLine();
                                
                                    Console.WriteLine("Enter Ticket Status (Open, Closed):");
                                    ticket.status = Console.ReadLine();

                                    Console.WriteLine("Enter Ticket Priority:");
                                    ticket.priority = Console.ReadLine();

                                    Console.WriteLine("Enter Your Name (Ticket Submitter, First and Last Name):");
                                    ticket.submitter = Console.ReadLine();

                                    Console.WriteLine("Enter who has been assigned the Ticket (Seperate Multiple Entries with comma, include First and Last name):");
                                    ticket.assigned = Console.ReadLine();

                                    Console.WriteLine("Enter who is watching the ticket (Seperate Multiple Entries with |, include First and Last name):");
                                    ticket.watching = Console.ReadLine();

                                    Console.WriteLine("Enter the severity of the bug:");
                                    ticket.severity = Console.ReadLine();
                                    
                                    sw.WriteLine($"{ticket.Display()}\n");
                                    }

                                }
                                sw.Close();
                        } else if(choice == "2") {
                            file = "Task.csv";
                            Task task = new Task();
                            StreamWriter sw = new StreamWriter(file, true);
                                for (int i = 0; i < 9; i++)
                                {
                                    // ask a question
                                    Console.WriteLine("Enter a ticket (Y/N)?");
                                    // input the response
                                    string resp = Console.ReadLine().ToUpper();
                                    // if the response is anything other than "Y", stop asking
                                    if (resp != "Y") {
                                        break; 
                                    } else {
                                    Console.WriteLine("Enter Ticket ID (numbers)");
                                    task.ticketID = Convert.ToInt16(Console.ReadLine());

                                    Console.WriteLine("Enter Ticket Summary:");
                                    task.summary = Console.ReadLine();
                                
                                    Console.WriteLine("Enter Ticket Status (Open, Closed):");
                                    task.status = Console.ReadLine();

                                    Console.WriteLine("Enter Ticket Priority:");
                                    task.priority = Console.ReadLine();

                                    Console.WriteLine("Enter Your Name (Ticket Submitter, First and Last Name):");
                                    task.submitter = Console.ReadLine();

                                    Console.WriteLine("Enter who has been assigned the Ticket (Seperate Multiple Entries with comma, include First and Last name):");
                                    task.assigned = Console.ReadLine();

                                    Console.WriteLine("Enter who is watching the ticket (Seperate Multiple Entries with |, include First and Last name):");
                                    task.watching = Console.ReadLine();

                                    Console.WriteLine("Enter the project name:");
                                    task.projectName = Console.ReadLine();

                                    Console.WriteLine("Enter the due date formated as DAY/MONTH/YEAR.");
                                    task.dueDate = Console.ReadLine();
                                    
                                    sw.WriteLine($"{task.Display()}\n");
                                    }

                                }
                                sw.Close();

                        } else if(choice == "3") {
                            file = "Enhancements.csv";
                            Enhancement enhancement = new Enhancement();
                            StreamWriter sw = new StreamWriter(file, true);
                                for (int i = 0; i < 11; i++)
                                {
                                    // ask a question
                                    Console.WriteLine("Enter a ticket (Y/N)?");
                                    // input the response
                                    string resp = Console.ReadLine().ToUpper();
                                    
                                    // if the response is anything other than "Y", stop asking
                                    if (resp != "Y") {
                                        break; 
                                    } else {
                                    Console.WriteLine("Enter Ticket ID (numbers)");
                                    enhancement.ticketID = Convert.ToInt16(Console.ReadLine());

                                    Console.WriteLine("Enter Ticket Summary:");
                                    enhancement.summary = Console.ReadLine();
                                
                                    Console.WriteLine("Enter Ticket Status (Open, Closed):");
                                    enhancement.status = Console.ReadLine();

                                    Console.WriteLine("Enter Ticket Priority:");
                                    enhancement.priority = Console.ReadLine();

                                    Console.WriteLine("Enter Your Name (Ticket Submitter, First and Last Name):");
                                    enhancement.submitter = Console.ReadLine();

                                    Console.WriteLine("Enter who has been assigned the Ticket (Seperate Multiple Entries with comma, include First and Last name):");
                                    enhancement.assigned = Console.ReadLine();

                                    Console.WriteLine("Enter who is watching the ticket (Seperate Multiple Entries with |, include First and Last name):");
                                    enhancement.watching = Console.ReadLine();

                                    Console.WriteLine("Enter the software that is going to be enhanced:");
                                    enhancement.software = Console.ReadLine();
                                    
                                    Console.WriteLine("Enter the cost of the enhancement:");
                                    enhancement.cost = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Enter the reason for the enhancement:");
                                    enhancement.reason = Console.ReadLine();

                                    Console.WriteLine("Enter the estimate of time for the enhancement:");
                                    enhancement.estimate = Console.ReadLine();
                                    
                                    sw.WriteLine($"{enhancement.Display()}\n");
                                    }
                                }
                                sw.Close();
                        } 
                }
                else if(choice == "3") {          
                    List<string> TicketList = new List<string>();
                    List<string> TaskList = new List<string>();
                    List<string> EnhancementList = new List<string>();

                    foreach (string line in File.ReadLines(@"Tickets.csv")) 
                        {
                            TicketList.Add(line);
                        }
                    foreach (string line in File.ReadLines(@"Enhancements.csv")) 
                        {
                            EnhancementList.Add(line);
                        }
                    foreach (string line in File.ReadLines(@"Task.csv")) 
                        {
                            TaskList.Add(line);
                        }    

                    Console.WriteLine("What would you like to search?:");
                    Console.WriteLine("1) Search Status");
                    Console.WriteLine("2) Search Priority");
                    Console.WriteLine("3) Search Submitter");
                    Console.WriteLine("Enter any other key to exit.");
                    choice = Console.ReadLine();

                    if(choice == "1") {

                        Console.WriteLine("Input the status you want to search(OPEN or CLOSED):");
                        choice = Console.ReadLine();
                            var SearchTicketList = TicketList.Where(m => m.Contains(choice)).Select(m => m);
                            var SearchEnhancementList = EnhancementList.Where(m => m.Contains(choice)).Select(m => m);
                            var SearchTaskList = TaskList.Where(m => m.Contains(choice)).Select(m => m);
                            
                            Console.WriteLine("Found entrys:");
                            Console.WriteLine("Entry's in Tickets.csv");
                            foreach(string m in SearchTicketList)
                                {
                                    Console.WriteLine($"  {m}");
                                }
                            Console.WriteLine("Entry's in Enhancements.csv");
                            foreach(string m in SearchEnhancementList)
                                {
                                    Console.WriteLine($"  {m}");
                                }
                            Console.WriteLine("Entry's in Tasks.csv");
                            foreach(string m in SearchTaskList)
                                {
                                    Console.WriteLine($"  {m}");
                                }        

                    } else if(choice == "2") {
                        Console.WriteLine("Input the Priority you want to search(Low, Medium or High):");
                        choice = Console.ReadLine();
                            var SearchTicketList = TicketList.Where(m => m.Contains(choice)).Select(m => m);
                            var SearchEnhancementList = EnhancementList.Where(m => m.Contains(choice)).Select(m => m);
                            var SearchTaskList = TaskList.Where(m => m.Contains(choice)).Select(m => m);

                            Console.WriteLine("Found entrys:");
                            Console.WriteLine("Entry's in Tickets.csv");
                            foreach(string m in SearchTicketList)
                                {
                                    Console.WriteLine($"  {m}");
                                }
                            Console.WriteLine("Entry's in Enhancements.csv");
                            foreach(string m in SearchEnhancementList)
                                {
                                    Console.WriteLine($"  {m}");
                                }
                            Console.WriteLine("Entry's in Tasks.csv");
                            foreach(string m in SearchTaskList)
                                {
                                    Console.WriteLine($"  {m}");
                                } 

                    } else if(choice == "2") {
                        Console.WriteLine("Input the submitter you want to search('FirstName LastName'):");
                        choice = Console.ReadLine();
                            var SearchTicketList = TicketList.Where(m => m.Contains(choice)).Select(m => m);
                            var SearchEnhancementList = EnhancementList.Where(m => m.Contains(choice)).Select(m => m);
                            var SearchTaskList = TaskList.Where(m => m.Contains(choice)).Select(m => m);

                            Console.WriteLine("Found entrys:");
                            Console.WriteLine("Entry's in Tickets.csv");
                            foreach(string m in SearchTicketList)
                                {
                                    Console.WriteLine($"  {m}");
                                }
                            Console.WriteLine("Entry's in Enhancements.csv");
                            foreach(string m in SearchEnhancementList)
                                {
                                    Console.WriteLine($"  {m}");
                                }
                            Console.WriteLine("Entry's in Tasks.csv");
                            foreach(string m in SearchTaskList)
                                {
                                    Console.WriteLine($"  {m}");
                                } 

                    }

                }

                logger.Info("User choice: {Choice}", choice);
            } while (choice == "1" || choice == "2" || choice == "3");

            logger.Info("Program Ended.");
        }
    }
}
