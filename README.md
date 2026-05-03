Last Update: 4/5/2026 03:45 HRS IST

NOTE: SampleJSON file is the key. This file needs to be clearly given as to make modifications to the API.

TASKS THAT ARE DONE
1. Migrated to .net48 based on Srikanth instructions.
2. Updated the sampleJson file based on new questionnaire. This is the key file for the API. Any changes to the questionnaire will be reflected here and then in the code.
   (Check about Alcohol/ Vape Question, as it is not clear in the questionnaire if it is a single question or two separate questions.)
3. Created Common SP Call Method which can be reused in every function.
4. Created Dummy Model based on SampleJSON. If input coming in is confirmed, Using this Model will be a better approach than using JObject as parameter both 
   from performance as well as cleanliness perspective.
5. 6 methods based on input Json. Parameters to be changed in future, after understanding. 5 are fairly clear. need clarification on last one. 
6. Sample ConnectionString added in web.config.
7. GitIgnore now working properly.
8. DB Connection now added in web.config
9. Updated Workflow for README updates. Update will go to two people from now.
10.Convert age into DOB in the register method. 
11.Test for 1 method (registerUser) completed.
12.Made main method which will pass various parameters to input into multiple tables. (Error in PK registerId, I think it should  be regId, For now I am using my own Store
   proc temp but after srikanth review can make it proper.)
13.Check data feasibility and test it based on some test forms.

GOOD TO HAVE
1. DataModels for input and output for each method.
2. Swagger Implementation
3. Authentication

NEED INFORMATION
1. Need the link values document between the stored procedure(s) and questionnaire.
2. What null handles are needed?
3. What is the final data output to be sent?

NEXT STEPS/ CURRENTLY WORKING ON
NA