using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandArgs = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandArgs[0] + "Command";
            commandArgs = commandArgs.Skip(1).ToArray();
            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower());
            if(commandType == null) { throw new ArgumentException("Invalid command type!"); }
            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);
            return commandInstance.Execute(commandArgs);
        }
    }
}
