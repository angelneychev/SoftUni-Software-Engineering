

namespace MilitaryElite.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using MilitaryElite.Contracts;
    using MilitaryElite.Exceptions;
    using MilitaryElite.Models;
    public class Engine
    {
        private readonly List<ISoldier> army;

        public Engine()
        {
            this.army = new List<ISoldier>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command
                    .Split(" ")
                    .ToArray();
                string type = tokens[0];
                string id = tokens[1];
                string firstName = tokens[2];
                string lastName = tokens[3];
                decimal salary = decimal.Parse(tokens[4]);

                if (type == "Private")
                {
                    Private soldier = new Private(id,firstName,lastName,salary);
                    this.army.Add(soldier);
                    
                }
                else if (type == "LieutenantGeneral")
                {
                   LieutenantGeneral general = new LieutenantGeneral(
                        id,firstName,lastName,salary);
                    string[] privatesCommand = tokens.Skip(5).ToArray();
                    foreach (var pid in privatesCommand)
                    {
                        ISoldier soldierToAdd = this.army
                            .First(x => x.Id == pid);

                        general.AddPrivate(soldierToAdd);
                    }
                    this.army.Add(general);
                }
                else if (type == "Engineer")
                {
                    try
                    {
                        string corps = tokens[5];

                        IEngineer engineer = new Engineer(id,firstName,lastName,salary,corps);

                        string[] repearTokens = tokens.Skip(6).ToArray();

                        AddPepairs(engineer, repearTokens);

                        this.army.Add(engineer);
                    }
                    catch (InvalidCorpsExceptions ice)
                    {
                        //continue;
                    }
                }
                else if (type == "Commando")
                {
                    try
                    {
                        string corps = tokens[5];

                        ICommando commando = new Commando
                            (id, firstName, lastName, salary, corps);

                        string[] missingTokens = tokens
                            .Skip(6)
                            .ToArray();

                        for (int i = 0; i < missingTokens.Length; i+=2)
                        {
                            try
                            {
                                string codeName = missingTokens[i];
                                string state = missingTokens[i + 1];

                                IMissions mission = new Mission(codeName,state);

                                commando.AddMissions(mission);
                            }
                            catch (InvalidStateExceptions ise)
                            {
                                continue;
                            }
                        }
                        this.army.Add(commando);
                    }
                    catch (InvalidCorpsExceptions ice)
                    {
                        
                    }
                }
                else if (type == "Spy")
                {
                    int codeNumber = (int) salary;

                    ISpy spy = new Spy(id,firstName,lastName,codeNumber);

                    this.army.Add(spy);
                }

                command = Console.ReadLine();
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var soldier in this.army)
            {
                Type type = soldier.GetType();

                Object actual = Convert.ChangeType(soldier, type);

                Console.WriteLine(actual.ToString());

            }
        }

        private static void AddPepairs(IEngineer engineer, string[] repearTokens)
        {
            for (int i = 0; i < repearTokens.Length; i += 2)
            {
                string partName = repearTokens[i];
                int hoursWorked = int.Parse(repearTokens[i+1]);

                IRepair repair = new Repair(partName, hoursWorked);

                engineer.AddRepair(repair);
            }
        }
    }
}
