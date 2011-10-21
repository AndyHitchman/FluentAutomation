﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentAutomation.RemoteCommands.Commands
{
    [CommandArgumentsType(typeof(WaitArguments))]
    public class Wait : ICommand
    {
        public void Execute(API.CommandManager manager, ICommandArguments arguments)
        {
            var args = (WaitArguments)arguments;

            if (args.Seconds > 0)
            {
                manager.Wait(TimeSpan.FromSeconds(args.Seconds));
            }
            else if (args.Milliseconds > 0)
            {
                manager.Wait(TimeSpan.FromMilliseconds(args.Milliseconds));
            }
            else
            {
                throw new InvalidCommandException<Wait>();
            }
        }
    }

    public class WaitArguments : ICommandArguments
    {
        public int Seconds { get; set; }
        public int Milliseconds { get; set; }
    }
}
