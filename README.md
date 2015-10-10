C# SQL Tower Search Program

The Tower Search C# program (name still pending) is a program designed to make the management of the parts towers easier and cleaner. Once all the data of parts and their location is submitter, one will be capable of searching for the location of a part, checking the quantity, and finding the name of a part based on coordinates. Users will also be able to log which parts are borrowed by whom, as well as in what quantities. The simplistic design of the program allows for an efficient and streamlined lab process, especially for the lab managers.

The goal of the program is to learn how to program using the language of C#. A MS SQL database is attached to the program, and so learning SQL commands is also a part of the process. The visual design is created through a combination of Windows Presentation Foundation and Windows Forms. By the completion of the initial phase of the application, designers will be fluent in all of these aspects of programming. 

A list of desired goals to accomplish with this program that have yet to be done is as follows:
•	Release an initial version of the program that works on all computer, not just the development machine
•	Add a queue system, so that when an individual or group would like to borrow a part that is already borrowed to the fullest capacity, the individual or group is added to a first in first out queue. Once parts are returned to the towers, only the user that is next in line will be able to borrow the aforementioned part. Users will only be able to take the part out in the mentioned manner until the queue has been depleted. 
•	Include a learning system which auto-suggests parts for a specific class in a specific marking period, based on parts taken out that marking period by prior classes.
•	Include a reporting system which will print a list of parts that need to be ordered based on a specified threshold - perhaps weekly or monthly
•	Include an about window - displays all developers, designers, contributors, as well as the revision number
•	Improve method of backing up the database - currently creates a backup file every time the program is closed (backs up all databases on computer - this needs to be fixed)
•	If an error or exception occurs, or if program crashes for any reason, dump file should be generated with error message, inner exception, and stack trace
