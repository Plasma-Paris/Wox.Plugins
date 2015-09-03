using System;
using System.IO;
using System.Linq;
using System.Text;
using Wox.Plugin.Common;
using System.Diagnostics;
using Wox.Plugin.Jrnl.Settings;
using System.Collections.Generic;

namespace Wox.Plugin.Jrnl
{
    public class JrnlService
    {
        private readonly SettingElements _settings;
        
        public JrnlService(SettingElements settings, PluginInitContext context)
        {
            if (settings == null)
                throw new ArgumentNullException("settings", "settings is null.");
            if (context == null)
                throw new ArgumentNullException("context", "context is null.");

            _settings = settings;
        }

        public string TranformQueryToCommandLine(string queryString)
        {
            if (String.IsNullOrEmpty(queryString))
                return "-n 999";

            var split = queryString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (queryString.Length == 0)
                return "-n 999";

            return "-and -n 999 @" + String.Join(" @", split);
        }

        public List<JrnlElem> ExecuteCommandLine(string commandLine)
        {
            const string K_SEPARATOR = "¤_#SEPARATOR#_¤";

            if (String.IsNullOrEmpty(commandLine))
                throw new ArgumentException("commandLine is null or empty.", "commandLine");

            var output = new StringBuilder();
            ExecuteJrnlCommandLine(commandLine, 
                (process) =>
                {
                    process.OutputDataReceived += (sender, args) =>
                    {
                        if (String.IsNullOrEmpty(args.Data))
                            output.Append(K_SEPARATOR);
                        else output.Append(args.Data + " ");
                    };
                },
                (process) => process.BeginOutputReadLine(), true);

            var results = new List<JrnlElem>();
            foreach (string jrnlStr in output.ToString().Split(new string[] { K_SEPARATOR }, StringSplitOptions.RemoveEmptyEntries))
                results.Add(new JrnlElem(jrnlStr.Trim()));
            return results;
        }

        private void AddToDefaultJournal(string str)
        {
            ExecuteJrnlCommandLine(JrnlElem.CreateId() + str, null, null, false);
        }

        private void ExecuteJrnlCommandLine(string commandLine, Action<Process> beforeStartAction, Action<Process> afterStartAction, bool redirectStandardOutputAndDoNotUseShellExecute)
        {
            var currentDirectory = Environment.CurrentDirectory;
            var home = Environment.GetEnvironmentVariable("USERPROFILE");
            if (!string.IsNullOrEmpty(home) && Directory.Exists(home))
                Environment.CurrentDirectory = home;

            var process = new Process();

            process.StartInfo.UseShellExecute = !redirectStandardOutputAndDoNotUseShellExecute;
            process.StartInfo.RedirectStandardOutput = redirectStandardOutputAndDoNotUseShellExecute;
            process.StartInfo.FileName = _settings.JrnlPath;
            process.StartInfo.Arguments = commandLine;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            if (beforeStartAction != null)
                beforeStartAction(process);

            process.Start();

            if (afterStartAction != null)
                afterStartAction(process);
            
            process.WaitForExit();

            Environment.CurrentDirectory = currentDirectory;
        }

        private void UseExternalEditor(string id)
        {
            var idFormat = id == null ? String.Empty : "@" + id;
            ExecuteJrnlCommandLine(idFormat + " --edit", null, null, false);
        }

        public List<Result> TransformCommandLineResponseToResults(List<JrnlElem> response, string query)
        {
            if (response == null)
                throw new ArgumentNullException("response", "response is null.");

            var results = new List<Result>(response.Count);
            if (response.Count == 0 & !String.IsNullOrEmpty(query))
                results.Add(new CustomResult()
                {
                    Action = (c) => { AddToDefaultJournal(query); return true; },
                    Title = "Add this to your default journal"
                });

            response.Reverse();
            foreach (var item in response)
                results.Add(new CustomResult()
                {
                    Title = item.Text,
                    SubTitle = String.Format("Date : {0} - Click for editing - item ID : {1}", item.Date, item.Id),
                    Action = (c) => { UseExternalEditor(item.Id); return true; },
                });

            return results;
        }
    }
}
