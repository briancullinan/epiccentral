This directory contains SQL scripts for initializing the test database. When a test run starts,
the SQL scripts in this directory will be executed to initialize the database for testing. When
the test run completes, the script in the Revert directory will be run to drop all the database
objects so the database is empty again.

Only files with .sql extension are read and executed. Thus, any other files, such as this README,
will be ignored. The .sql files are sorted alphabetically in ascending order and executed in that
order. By convention, the file names start with two digits, e.g. "01 xxx.sql", "02 yyy.sql", etc.
This makes it easy to order the files according to function.

Each script file is processed and separated into individual commands at each "GO" statement. GO
statements cannot be executed by SQL Server and are used for batching of commands. GO statements
can be of mixed case, but each must be by itself on a line in the script file, nothing before it
or after it, except for whitespace.