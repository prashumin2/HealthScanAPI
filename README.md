NOTE: SampleJSON file is the key. This file needs to be clearly given as to make modifications to the API.

TASKS THAT ARE DONE
1. Migrated to .net48 based on Srikanth instructions.
2. Created a sampleJson file which may be changed in future. For now, code done assuming this as the input.
3. Created Common SP Call Method which can be reused in every function.
4. Created Dummy Model based on SampleJSON. If Confirmed input coming in Using this Model will be a better approach than using JObject as parameter both 
   from performance as well as cleanliness perspective.
5. 6 methods based on input Json. Parameters to be changed in future, after understanding. 2 are fairly clear. need clarification on the other 4.
6. Sample ConnectionString added in web.config.
7. GitIgnore now working properly.


GOOD TO HAVE
1. DataModels for input and output for each method.
2. Swagger Implementation
3. Authentication


NEXT STEPS/ CURRENTLY WORKING ON
None

NEED INFORMATION
1. DB Connection string
2. Need Understanding as to what is the InsertPO, InsertPPS, InsertPLS and InsertMT stored procedures do. Coding done on assumption that everything will be
   in JSON input which may not be the case.
3. What null handles are needed?