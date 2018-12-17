Feature: APIApplication

@mytag
Scenario: Get API response for the given end point
	Given I have an end point /endpoint/
	When I call the GET method on this endpoint
	Then the result should be in json format

Scenario Outline: Get API response for the given endpoint
	Given I have a new end point /userinformation/
	When I call the GET method on this endpoint to get the user information <userid>
	Then I need to get the user information in json format

Examples:User Info
| userid    |
| user10001 |

Scenario Outline: Post content for the given end point
	Given I have a resource /maps/api/place/add/json
	When I call the POST method on this endpoint using a key <postkey>
	Then the response should be in json format

Examples:Key Info
| postkey    |
| qaclick123 |

Scenario Outline: Delete content for the given end point
	Given I have a delete resource /maps/api/place/delete/json
	When I call the POST method on this endpoint to delete using a key <deletekey>
	Then the delete response should be in json format

Examples:Key Info
| deletekey  |
| qaclick123 |