This directory contains SQL scripts for reverting the test database to be completely empty. When
a test run finishes, the SQL scripts in this directory will be executed to revert the database.
The database is initialized with the scripts in the Initialize directory.

See the README.txt file in the Initialize directory for more details about script execution. The
only real difference between how initialization scripts are run vs. revert scripts is that the
revert scripts in this directory are sorted in descending order for execution.