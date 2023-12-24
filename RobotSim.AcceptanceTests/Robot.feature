Feature: Robot Simulator

@wip
Scenario: Valid PLACE command
Given the robot is off the table
When I issue the command "PLACE 1,1,NORTH"
Then the robot should be on the table at position 1,1 facing NORTH

@todo
Scenario: Invalid PLACE command
Given the robot is off the table
When I issue the command "PLACE 6,6,NORTH"
Then the robot should still be off the table

@todo
Scenario: MOVE command
Given the robot is on the table at position 1,1 facing NORTH
When I issue the command "MOVE"
Then the robot should be on the table at position 1,2 facing NORTH

@todo
Scenario: LEFT command
Given the robot is on the table at position 1,1 facing NORTH
When I issue the command "LEFT"
Then the robot should be on the table at position 1,1 facing WEST

@todo
Scenario: RIGHT command
Given the robot is on the table at position 1,1 facing NORTH
When I issue the command "RIGHT"
Then the robot should be on the table at position 1,1 facing EAST

@todo
Scenario: REPORT command
Given the robot is on the table at position 1,1 facing NORTH
When I issue the command "REPORT"
Then the output should be "1,1,NORTH"

@todo
Scenario: Ignore commands when off the table
Given the robot is off the table
When I issue the command "MOVE"
And I issue the command "LEFT"
And I issue the command "RIGHT"
And I issue the command "REPORT"
Then the robot should still be off the table
And there should be no output