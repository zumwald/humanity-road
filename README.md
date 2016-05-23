# humanity-road
Donated project to the HumanityRoad.org team.

A web dashboard designed to allow volunteers at [HumanityRoad](http://humanityroad.org) to log and track their activity.

###Promises
 - A volunteer can log in to the app securely using their exising social media account (Google, Facebook, etc.)
 - A volunteer can save their timecard in the app
 - A volunteer can view their activity from the app
 - A HumanityRoad team member can save training records for a volunteer

###Developer's Guide
####Front-end

 - Package Management using [Bower](http://bower.io)
 - AngularJS

####Server

 - Authentication & user roles via OWIN ([see here for help on ASP.NET auth](http://oauthforaspnet.com/))
 - EntityFramework data store for saving volunteer data