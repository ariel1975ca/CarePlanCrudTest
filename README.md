# CarePlanCrudTest
Small web application which will allow a user to record care plans

Exercise

Develop a small web application which will allow a user to record care plans. 

The web application can be a simple single page but must be the point where the user interacts with the API CRUD functions
Communication with server to save, update and returning record will be done via Web APIs. 

As a user I should be able to perform following functions
1.	Create and update care plan record,
2.	Get notified if I break any rules mentioned below. (This also represents the data model)

You do not have to include the actual Database, just the functions that would interact

You do not need to add the API authentication  

The application does not need to be demonstrated but the project and associated files contained with a publicly accessible Git repo

Class & Rules
Care Plan

Field	Type	Mandatory	Rules
Title	Nvarchar(450)	Yes
Patient Name	Nvarchar(450)	Yes	
User Name	Nvarchar(450)	Yes	
Actual Start Date/Time	Date/Time	Yes	
Target Date/Time	Date/Time	Yes	
Reason	Nvarchar(1000)	Yes	
Action	Nvarchar(1000)	Yes	
Completed	Picklist (Yes, No)	No	
End Date/Time	Date/Time	No	Cannot be before Start Date/Time. Visible and mandatory when “Completed” is set to Yes
Outcome	Nvarchar(1000)	No	Visible and mandatory when “Completed” is set to Yes


