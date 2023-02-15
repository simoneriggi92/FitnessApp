-- SQLite
INSERT INTO Plans(user_id, creation_date, start_date,end_date) VALUES 
(1, '10-10-2020', '12-10-2020', '12-11-2020'),
(2, '09-10-2020', '13-10-2020', '12-12-2020'),
(3, '08-10-2020', '14-10-2020', '12-13-2020')


dotnet ef dbcontext scaffold "Data Source=Data/gymApp.db" Microsoft.EntityFrameworkCore.Sqlite --output-dir Models/Entities --context-dir Models/Services/Insfrastructure --context GymAppDbContext


