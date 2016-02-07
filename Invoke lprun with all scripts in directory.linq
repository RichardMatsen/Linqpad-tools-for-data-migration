<Query Kind="Statements">
  <Reference>&lt;ProgramFilesX86&gt;\Reference Assemblies\Microsoft\WindowsPowerShell\3.0\System.Management.Automation.dll</Reference>
  <Namespace>System.Management.Automation</Namespace>
  <Namespace>System.Management.Automation.Runspaces</Namespace>
</Query>

// Invoke lprun with all scripts in directory

var basePath = @"D:\Workspaces\_projects\ClinicSessions\LINQPad4\";
var queryPath = basePath + @"queries\TestLPRun\";

DirectoryInfo d = new DirectoryInfo(queryPath);
foreach (var file in d.GetFiles("*.linq"))
{
	  runScript(file.FullName);
}

}

public void runScript(string scriptPath)
{
	Util.Run(scriptPath, QueryResultFormat.HtmlFragment).Dump();
}

public void runScriptWithPowerShell(string pathToLPRun, string scriptPath)
{
	var runspaceConfiguration = RunspaceConfiguration.Create();
	var runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
	runspace.Open();
	RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);
	Pipeline pipeline = runspace.CreatePipeline();
	Command myCommand = new Command(pathToLPRun + "lprun.exe");
	myCommand.Parameters.Add(scriptPath);
	pipeline.Commands.Add(myCommand);
	pipeline.Invoke().Select (pso => pso.BaseObject).Dump(true);
}

public void Dummy()
{

// ---------------------------------------------------------------------------------------------------------