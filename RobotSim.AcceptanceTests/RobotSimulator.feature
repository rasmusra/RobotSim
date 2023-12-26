Feature: Robot Simulator

Background: The robot is on a 5x5 table. The table is square and has 5 columns and 5 rows. The robot is free to roam around the surface of the table, but must be prevented from falling to destruction. Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed.

@wip
Scenario: Valid PLACE command
Given the robot is off the table
When I issue the commands:
| command         |
| PLACE 0,0,NORTH |
| MOVE            |
| REPORT          |
Then I see '0,1,NORTH' on the screen

@todo
Scenario: Invalid PLACE command
Given the robot is off the table
When I issue the command "PLACE 6,6,NORTH"
Then the robot should still be off the table

@todo
Scenario: MOVE command
Given the robot is on the table at position 1,1 facing NORTH
When I issue the command "MOVE"
Then the robot is on the table at position 1,2 facing NORTH

@todo
Scenario: LEFT command
Given the robot is on the table at position 1,1 facing NORTH
When I issue the command "LEFT"
Then the robot is on the table at position 1,1 facing WEST

@todo
Scenario: RIGHT command
Given the robot is on the table at position 1,1 facing NORTH
When I issue the command "RIGHT"
Then the robot is on the table at position 1,1 facing EAST

@todo
Scenario: REPORT command
Given the robot is on the table at position 1,1 facing NORTH
When I issue the command "REPORT"
Then the output is "1,1,NORTH"

@todo
Scenario: Ignore commands when off the table
Given the robot is off the table
When I issue the command "MOVE"
And I issue the command "LEFT"
And I issue the command "RIGHT"
And I issue the command "REPORT"
Then the robot should still be off the table
And there is no output