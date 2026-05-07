Last Update: 4/7/2026 23:42 HRS IST

NOTE: SampleJSON file is the key. This file needs to be clearly given as to make modifications to the API.

TASKS THAT ARE DONE
1. Migrated to .net48 based on Srikanth instructions.
2. Updated the sampleJson file based on new questionnaire. This file is key for the API input structure. Any changes to the questionnaire will be reflected here first and then in the code.
3. Created Dummy Model based on SampleJSON. If input coming in is confirmed, Using this Model will be a better approach than using JObject as parameter both 
   from performance as well as cleanliness perspective.
4. 6 methods based on input Json. Parameters to be changed in future, after understanding. 5 are fairly clear. need clarification on last one. (Not Used Anymore) 
5. GitIgnore now working properly.
6. DB Connection now added in web.config
7. Updated Workflow for README updates. Update will go to Srikanth and Saday everyday.
8. Convert age into DOB in the registerUser method.
9. Made registerUserAPI method which will pass various parameters to input into multiple tables. (Error in PK registerId, I think it should be regId, For now I am using my own Store
   proc temp but after srikanth review can make it proper.)
10.Basic Sanity check of data feasibility and tested it based on some sample forms.
11.Added data entry functionality and entity for Branch(s) and Corporate(s). It will now dynamically add if data is not present in the tables.
12.Added service layer and moved the common SP call method to service layer. This will make the code cleaner and more modular.
13.Added DBContext and Repository pattern for better code structure and maintainability. This may also help in unit testing in the future.

GOOD TO HAVE
1. DataModels for input and output for each method.
2. Swagger Implementation
3. Authentication

NEED INFORMATION
1. What null handles are needed?
2. What is the final data output to be sent?
3. Variable Mapping(s) of questionnaire with with Tables. (Done right now based on what I understood.)

ACTION ITEMS ON SRIKANTH/ SADAY
1. Why is the Vape variable NOT used in usp_registeruserAPI (or) usp_registeruser storedproc.
	Srikanth: We need to update one of the stored procedures to include the vape variable. Once he updates the stored procedure, we can modify the API to include it as well.
	This will ensure that we are capturing all relevant information from the questionnaire and storing it in the database correctly.
2. Awaiting document which tells which questions from the questionnaire is linked with what column of tables.
3. Review the storedproc usp_registeruserAPI as dataentry not working. I created a storedproc usp_registeruserAPITemp for it to work temporarily.
4. Hosting of the API in server. Already published and shared with Srikanth.
5. How would we differentiate between different users? (Case: If the client API is faulty and they keep sending samedata repeatedly, how do we identify that?) 

NEXT STEPS/ CURRENTLY WORKING ON
Awaiting instructions.