-- SQLite

CREATE TABLE Users(

Id INTEGER NOT NULL CONSTRAINT PK_Users PRIMARY KEY AUTOINCREMENT,
name TEXT(100) NOT NULL,
surname TEXT(100) NOT NULL,
username TEXT(100) NOT NULL,
email TEXT(100) NOT NULL,
birth_day DATETIME,
password TEXT(100) NOT NULL,
phone_number TEXT(100),
country TEXT(100),
state_region TEXT(100),
plans_completed NUMERIC NOT NULL DEFAULT(0),
image_path TEXT(500)
)




