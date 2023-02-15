-- SQLite
INSERT INTO Users(name, surname, username, password, email, birth_day, country, state_region, phone_number, plans_completed, image_path) VALUES 
('Simone', 'Riggi', 'simo92', '511783', 'simone.riggi92@gmail.com', '14-10-1992', 'Italy','Sicily', '+393202795763', 1, '/logo.png'),
('Luca', 'Riggi', 'luca92', '511783', 'luca.riggi92@gmail.com', '14-10-1992', 'Italy','Sicily', '+393202795764', 1, '/logo2.png'),
('Marta', 'Riggi', 'marta2', '511783', 'marta.riggi92@gmail.com', '16-10-1992', 'Italy','Sicily', '+393202795753', 1, '/logo3.png')



update Users
set image_path = "/profile.jpeg"