using DependencyTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyTest
{
    class Program
    {
        enum Commands
        {
            DEPEND,
            INSTALL,
            REMOVE,
            LIST

        }

        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.init();
        }

        /// <summary>
        /// Initialize the program execution
        /// </summary>
        private void init()
        {
            Component _component = new Component();
            string line = string.Empty;
            while(line != "END")
            {
                var response = RequestCommand();
                if (response.IsSucces)
                {
                    string CommandToExec = response.Message;
                    if(_component.Dependencies.Count == 0 && CommandToExec != "DEPEND")
                    {
                        init();
                    }

                    string command = response.result.ToString();
                    var components = command.Split(' ');

                    for (int i = 0; i < components.Length; i++)
                    {
                        string currentItem = components[i].Trim();
                        string beforeItem = string.Empty;
                        if(i > 1)
                        {
                            beforeItem = components[i - 1].Trim();
                        }
                        if (!string.IsNullOrEmpty(currentItem))
                        {
                            if(i == 0)
                            {
                                _component.addItem(currentItem);
                                Component dependendy = new Component();
                                dependendy.Name = components[i + 1].Trim();
                                _component.Adddependency(dependendy);
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(beforeItem))
                                {
                                    var beforeComponent = _component.Dependencies.FirstOrDefault(e => e.Name == beforeItem);
                                    if (beforeComponent != null)
                                    {
                                        var newDependency = new Component();
                                        newDependency.Name = currentItem;
                                        beforeComponent.Adddependency(newDependency);

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Request Initial inputs for starting the program
        /// </summary>
        /// <returns></returns>
        private Response RequestCommand()
        {
            Console.WriteLine("Waiting for command: ");
            string command = Console.ReadLine();
            if (string.IsNullOrEmpty(command))
            {
                Console.WriteLine("Unrecognized command, use (DEPEND, INSTALL, REMOVE, LIST)...");
                return new Response
                {
                    IsSucces = false,
                    Message = "Incorrect Input",
                    result = null,
                };
            }
            var components = command.Split(' ');
            var Exist = Enum.IsDefined(typeof(Commands), components[0]);
            if (!Exist)
            {
                Console.WriteLine("Unrecognized command, use (DEPEND, INSTALL, REMOVE, LIST)...");
                return new Response
                {
                    IsSucces = false,
                    Message = "Incorrect Input",
                    result = null,
                };
            }

             return new Response
            {
                IsSucces = true,
                Message = components[0].Trim(),
                result = command.Replace(components[0], ""),
            };
        }
    }
}
