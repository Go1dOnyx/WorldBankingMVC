# WorldBankDBMVC


Changes you need to make 

1.) Run the Sql script in SSMS to create the database & table with all the records 

2.) Change Connection string from the visual studio project
  
  a.)Inside the WorldBankDBMVC in the appsettings.json 
  
  b.)Inside the WorldBankDBMVC.Database.EF in Context folder and in the WorldBankDBMVC context file change the connection string
     under the OnConfiguring method
     
3.) Example on how you should change the Connection String:  Server=* change to local machine location*;Database=WorldBankDB;Trusted_Connection=True;
