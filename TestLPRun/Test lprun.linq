<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Dynamic.dll</Reference>
</Query>



// Set up a results file
var riResults = new { OP = 0, IP = 10, RunDate = DateTime.Now };
var path = @"D:\Workspaces\_projects\ClinicSessions\LINQPad4\data\RI_Results.json";
riResults.WriteJson(path);

// Add new info to results
dynamic json = path.ReadJsonToExpando();
json.Test_lprun = "test lprun 1";
json.RunDate = DateTime.Now;
path.WriteJson((object)json);

// Show the new results
var json2 = path.ReadJsonToExpando();
json2.Dump();

"Test lprun 1".Dump("Test lprun 1");

"Test lprun".Dump2Html("Test lprun", @"D:\Workspaces\_projects\ClinicSessions\LINQPad4\results");

// -------------------------------------------------------------------------------------------------