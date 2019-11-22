CFA Puzzle Application
----------------------

This is an ASP.Net Core v3 solution that consists of the following projects:

	CFA.Service 
	
	- class library intended to contain all services to be made available
	- currently PuzzleService available for dependency injection
	- also contains static Puzzle class which are used to recursively traverse a stream and produce a Puzzle Tree which is used to produce a Puzzle Score.
	
	CFA.Test 
	
	- xUnit project intended to contain all unit tests and perhaps other types of tests
	- contains Unit Tests for the Puzzles Service
	  (note that future-state could include tests for the static methods in the Puzzle class)

	CFA.Web 
	
	- ASP.Net Core website 
	- utilize dependency injection to make the PuzzleService available
	- hosts a Web Api used to expose Puzzles functionality
	- Puzzles controller contains Get() method which returns an integer value indicating the calculated score.  
	  (note that future-state could make this asynchronous and return a PuzzleResult object.)
	- hosts a static Home.html page used to test the API via jQuery ajax calls.


Definitions

	Puzzle - this refers to the the puzzle described in the assignment (refer to http://adventofcode.com/2017/day/9 for details).  
	         It accepts a Stream input and calculates a Puzzle Score based on those rules.  

	Stream - string input to a Puzzle.  

	Puzzle Tree - this refers to the tree data structure that is created when a Stream is parsed.  

	Puzzle Score - this is value calculated for a specified Stream.  

Notes

	* When the solution is opened in Visual Studio 2019, "blue screen of death" has been encountered when trying to execute the debugger.  
	  Resolution involved updating NuGet packages with latest versions.  
	* Visual Studio creates a subfolder to the solution.  After the app runs the first time, an 'applicationHosts.config' file created.  Scenarios, such as renaming the website
	  project, have led to "blue screen of death" situations.  The resolution was to delete this file and let Visual Studio rebuild it.