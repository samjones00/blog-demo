Feature: BlogController
	In order to read blog articles
	As a reader of the blog
	I want to access blog posts

@seelistofblogposts
Scenario: So that I can choose which post to read
	Given that I am a reader of the blog
	When I request a list of blog post titles
	Then I should receive a list of blog posts

@seenumberofcomments
Scenario: So that I can get a feel for how intersting the post is
	Given that I am a reader of the blog
	When I request a list of blog post titles
	Then I should see a number of comments

@readfullpost
Scenario: So that I can read the full post
	Given that I am a reader of the blog
	When I request blog article 3
	Then I receive blog article 3