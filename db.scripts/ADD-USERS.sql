-- SQLite
INSERT INTO Users(name, surname, username, password, email, birth_day, country, state_region, phone_number, plans_completed, image_path) VALUES 
('Simone', 'Riggi', 'simo92', '577183', 'simone.riggi92@gmail.com', '14-10-1992', 'Italy','Sicily', '+393202795763', 1, '/profile.jpeg'),
('Luca', 'Riggi', 'luca92', '577183', 'luca.riggi92@gmail.com', '14-10-1992', 'Italy','Sicily', '+393202795764', 1, '/logo2.png'),
('Marta', 'Riggi', 'marta2', '577183', 'marta.riggi92@gmail.com', '16-10-1992', 'Italy','Sicily', '+393202795753', 1, '/profile.jpeg')



update AspNetUsers
set ImagePath = "/profile.jpeg"
where Id = 'c5ff26db-62fe-4f00-90e2-141a8f234d75'