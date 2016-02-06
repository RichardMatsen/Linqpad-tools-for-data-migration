<Query Kind="Statements">
  <Reference>&lt;ProgramFilesX86&gt;\Reference Assemblies\Microsoft\WindowsPowerShell\3.0\System.Management.Automation.dll</Reference>
  <Namespace>System.Management.Automation</Namespace>
  <Namespace>System.Management.Automation.Runspaces</Namespace>
</Query>

// Invoke lprun with script

var runspaceConfiguration = RunspaceConfiguration.Create();
var runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
runspace.Open();
RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);
Pipeline pipeline = runspace.CreatePipeline();
Command myCommand = new Command(@"D:\Workspaces\_projects\ClinicSessions\LINQPad4\lprun.exe");
myCommand.Parameters.Add(@"D:\Workspaces\_projects\ClinicSessions\LINQPad4\queries\Test lprun.linq");
pipeline.Commands.Add(myCommand);
pipeline.Invoke().Select (pso => pso.BaseObject).Dump(true);
