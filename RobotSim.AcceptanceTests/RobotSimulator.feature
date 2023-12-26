Feature: Robot Simulator

Background:
	Given the surface is a table with dimensions:
		| width | height |
		| 5     | 5      |


Scenario: Move command
	Given the robot is off the table
	When I issue the commands:
		| command         |
		| PLACE 0,0,NORTH |
		| MOVE            |
		| REPORT          |
	Then I see '0,1,NORTH' on the screen


Scenario Outline: Turn command
	Given the robot is off the table
	When I issue the commands:
		| command         |
		| PLACE 0,0,NORTH |
		| <turn command>  |
		| REPORT          |
	Then I see '0,0,<direction>' on the screen

Examples:
	| turn command | direction |
	| LEFT         | WEST      |
	| RIGHT        | EAST      |


Scenario: Driving around
	Given the robot is off the table
	When I issue the commands:
		| command        |
		| PLACE 1,2,EAST |
		| MOVE           |
		| MOVE           |
		| LEFT           |
		| MOVE           |
		| REPORT         |
	Then I see '3,3,NORTH' on the screen


Scenario: Invalid PLACE command
	Given the robot is off the table
	When I issue the commands:
		| command         |
		| PLACE 6,6,NORTH |
		| MOVE            |
		| REPORT          |
	Then I see nothing on the screen


Scenario: Replacing the robot
	Given the robot is off the table
	When I issue the commands:
		| command         |
		| PLACE 1,2,NORTH |
		| REPORT          |
		| PLACE 3,4,SOUTH |
		| REPORT          |
	Then I see the following output:
		| report    |
		| 1,2,NORTH |
		| 3,4,SOUTH |



Scenario Outline: Moving out of bounds
	Given the robot is off the table
	When I issue the commands:
		| command               |
		| PLACE 3,3,<direction> |
		| MOVE                  |
		| MOVE                  |
		| MOVE                  |
		| MOVE                  |
		| REPORT                |
	Then I see '<expected X>,<expected Y>,<direction>' on the screen

Examples:
	| direction | expected X | expected Y |
	| NORTH     | 3          | 4          |
	| SOUTH     | 3          | 0          |
	| EAST      | 4          | 3          |
	| WEST      | 0          | 3          |


Scenario: Ignore bad commands
	Given the robot is off the table
	When I issue the commands:
		| command          |
		| PLACE -1,3,NORTH |
		| REPORT           |
		| PLACE 7,3,NORTH  |
		| REPORT           |
		| PLACE 3,3,NORTH  |
		| REPORT           |
		| PLACE 3,3        |
		| REPORT           |
		| MOVE             |
		| PLACE 3,3,OOPS   |
		| LELELELE         |
		| LEFT             |
		| REPORT           |
	Then I see the following output:
		| report    |
		| 3,3,NORTH |
		| 3,3,NORTH |
		| 3,4,WEST  |
