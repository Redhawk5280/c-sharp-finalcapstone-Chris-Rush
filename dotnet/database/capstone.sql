USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	email varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE Animal(
	animal_id INT IDENTITY(1,1) NOT NULL,
	[name] varchar(50) Not Null,
	age int Not Null,
	breed varchar(50),
	species varchar(50),
	medical_needs bit ,
	color varchar(50),
	sex varchar(50),
	weight int not null,
	is_adopted bit,
	owner_name varchar(50),
	about_me varchar (250),
	is_good bit
	CONSTRAINT PK_animal PRIMARY KEY(animal_id)
)

CREATE TABLE images (

	image_id INT IDENTITY(1,1) NOT NULL,
	image_string VARCHAR(MAX) NOT NULL,
	animal_id INT NOT NULL

	CONSTRAINT PK_image PRIMARY KEY(image_id)
	CONSTRAINT FK_image_animal FOREIGN KEY (animal_id) REFERENCES Animal(animal_id)

)

CREATE TABLE volunteer_apps (

	app_id INT IDENTITY(1,1) NOT NULL,
	applicant_name VARCHAR(256) NOT NULL,
	applicant_email VARCHAR(256) NOT NULL,
	weekday_available BIT NOT NULL,
	weekend_available BIT NOT NULL,
	interest VARCHAR(MAX),

	CONSTRAINT PK_applicant PRIMARY KEY(app_id),
	UNIQUE (applicant_email)
	)

--populate default data
INSERT INTO users (email, password_hash, salt, user_role) VALUES ('llabuda32@gmail.com','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (email, password_hash, salt, user_role) VALUES ('christopherrush5280@gmail.com','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (email, password_hash, salt, user_role) VALUES ('ikirenohs@gmail.com','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (email, password_hash, salt, user_role) VALUES ('macadamchris@gmail.com','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (email, password_hash, salt, user_role) VALUES ('lorisomerville@gmail.com','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (email, password_hash, salt, user_role) VALUES ('tori@gmail.com','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (email, password_hash, salt, user_role) VALUES ('ben@gmail.com','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (email, password_hash, salt, user_role) VALUES ('chelsea@gmail.com','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (email, password_hash, salt, user_role) VALUES ('preston@gmail.com','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (email, password_hash, salt, user_role) VALUES ('beaver@gmail.com','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (email, password_hash, salt, user_role) VALUES ('wayne@gmail.com','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (email, password_hash, salt, user_role) VALUES ('admin@gmail.com','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');


-- Animal 1
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Fluffy', 3, 'Maine Coon', 'Cat', 0, 'Gray', 'Male', 15, 0, NULL, 'Fluffy is a playful and affectionate cat with a luxurious coat!', 1);

-- Animal 2
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Max', 2, 'Golden Retriever', 'Dog', 1, 'Golden', 'Male', 30, 1, 'John', 'Max is a friendly and loyal dog, great with kids!', 1);

-- Animal 3
INSERT INTO Animal ([name],age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Whiskers', 4, 'Siamese', 'Cat', 0, 'Cream', 'Female', 12, 0, NULL, 'Whiskers loves to nap in sunny spots and enjoys chin scratches!', 1);

-- Animal 4
INSERT INTO Animal ([name],age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Rocky', 5, 'Bulldog', 'Dog', 1, 'Brindle', 'Male', 25, 0, NULL, 'Rocky is a strong and energetic dog who loves outdoor activities!', 1);

-- Animal 5
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Sasha', 2, 'Persian', 'Cat', 0, 'White', 'Female', 10, 1, 'Emily', 'Sasha enjoys lounging around and has a calm demeanor.', 1);

-- Animal 6
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Buddy', 3, 'Dachshund', 'Dog', 0, 'Red', 'Male', 18, 0, NULL, 'Buddy is a small dog with a big heart, always ready to play!', 1);

-- Animal 7
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Luna', 1, 'Ragdoll', 'Cat', 1, 'Blue Bicolor', 'Female', 14, 1, 'David', 'Luna is a sweet and gentle cat who loves cuddles.', 1);

-- Animal 8
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Charlie', 4, 'Labrador Retriever', 'Dog', 0, 'Chocolate', 'Male', 32, 0, NULL, 'Charlie is a water-loving dog who enjoys fetching balls.', 1);

-- Animal 9
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Misty', 2, 'Scottish Fold', 'Cat', 0, 'Silver Tabby', 'Female', 8, 1, 'Sophie', 'Misty has a playful personality and loves chasing toys.', 1);

-- Animal 10
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Cooper', 3, 'Beagle', 'Dog', 1, 'Tricolor', 'Male', 20, 0, NULL, 'Cooper is a friendly and curious dog with a keen sense of smell.', 1);

-- Animal 11
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Simba', 2, 'Siberian Husky', 'Dog', 0, 'Gray and White', 'Male', 28, 1, 'Sarah', 'Simba is a playful and adventurous husky who loves the snow.', 1);

-- Animal 12
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Mittens', 5, 'Calico', 'Cat', 1, 'Calico', 'Female', 11, 1, 'Alex', 'Mittens is a sweet and affectionate cat with a unique coat pattern.', 1);

-- Animal 13
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)VALUES ('Maximus', 3, 'Boxer', 'Dog', 0, 'Fawn', 'Male', 26, 0, NULL, 'Maximus is a high-energy dog who loves to play fetch.', 1);

-- Animal 14
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Lily', 4, 'Persian', 'Cat', 1, 'Cream', 'Female', 9, 1, 'Mike', 'Lily enjoys lounging in sunny spots and being pampered.', 1);

-- Animal 15
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Bailey', 2, 'Shih Tzu', 'Dog', 0, 'White and Brown', 'Female', 16, 1, 'Rachel', 'Bailey is a friendly and sociable dog who loves attention.', 1);

-- Animal 16
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Oreo', 1, 'Domestic Shorthair', 'Cat', 0, 'Black and White', 'Male', 13, 0, NULL, 'Oreo is a playful kitten with a love for toys.', 1);

-- Animal 17
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Bella', 3, 'Chihuahua', 'Dog', 1, 'Tan', 'Female', 6, 1, 'Chris', 'Bella may be small, but she has a big heart and loves to cuddle.', 1);

-- Animal 18
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Leo', 4, 'Rottweiler', 'Dog', 0, 'Black and Tan', 'Male', 35, 0, NULL, 'Leo is a loyal and protective dog with a calm demeanor.', 1);

-- Animal 19
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Cleo', 2, 'Bengal', 'Cat', 1, 'Spotted Rosetted', 'Female', 12, 1, 'Taylor', 'Cleo is a playful and energetic cat who loves climbing.', 1);

-- Animal 20
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Daisy', 3, 'Poodle', 'Dog', 0, 'Apricot', 'Female', 18, 0, NULL, 'Daisy is a friendly and intelligent dog with a curly coat.', 1);

-- Animal 21
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Shadow', 2, 'Russian Blue', 'Cat', 0, 'Blue', 'Male', 11, 1, 'Eva', 'Shadow is a calm and gentle cat who enjoys quiet moments.', 1);

-- Animal 22
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Zeus', 5, 'Great Dane', 'Dog', 1, 'Brindle', 'Male', 40, 0, NULL, 'Zeus is a giant dog with a heart as big as his size!', 1);

-- Animal 23
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Mocha', 1, 'Sphynx', 'Cat', 0, 'Chocolate', 'Female', 7, 0, NULL, 'Mocha is a hairless cat who loves warm laps and cozy blankets.', 1);

-- Animal 24
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Teddy', 4, 'Cavalier King Charles Spaniel', 'Dog', 0, 'Blenheim', 'Male', 14, 1, 'Linda', 'Teddy is a sweet and gentle dog who loves to be pampered.', 1);

-- Animal 25
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Cupcake', 2, 'Himalayan', 'Cat', 1, 'Seal Point', 'Female', 10, 1, 'Mark', 'Cupcake is a beautiful cat with a calm and serene personality.', 1);

-- Animal 26
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Harley', 3, 'Dalmatian', 'Dog', 0, 'Black and White', 'Male', 28, 0, NULL, 'Harley is a spotty dog who loves to run and play.', 1);

-- Animal 27
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Lulu', 1, 'Exotic Shorthair', 'Cat', 1, 'Blue Tabby', 'Female', 9, 1, 'Michael', 'Lulu is a playful and curious cat with a cute round face.', 1);

-- Animal 28
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)VALUES ('Oliver', 2, 'Border Collie', 'Dog', 0, 'Black and White', 'Male', 22, 0, NULL, 'Oliver is a highly intelligent dog who loves to learn new tricks.', 1);

-- Animal 29
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Mimi', 4, 'Persian', 'Cat', 1, 'Silver', 'Female', 11, 1, 'Jessica', 'Mimi has a regal appearance and enjoys lounging in style.', 1);

-- Animal 30
INSERT INTO Animal ([name], age, breed, species, medical_needs, color,sex, weight, is_adopted, owner_name, about_me, is_good)
VALUES ('Rusty', 3, 'Australian Shepherd', 'Dog', 0, 'Red Merle', 'Male', 32, 0, NULL, 'Rusty is a smart and energetic dog who loves outdoor adventures.', 1);

INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo1.jpg', 1)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo2.jpg', 2)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo3.jpg', 3)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo4.jpg', 4)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo5.jpg', 5)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo6.jpg', 6)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo7.jpg', 7)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo8.jpg', 8)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo9.jpg', 9)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo10.jpg', 10)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo11.jpg', 11)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo12.jpg', 12)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo13.jpg', 13)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo14.jpg', 14)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo15.jpg', 15)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo16.jpg', 16)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo17.jpg', 17)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo18.jpg', 18)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo19.jpg', 19)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo20.jpg', 20)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo21.jpg', 21)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo22.jpg', 22)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo23.jpg', 23)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo24.jpg', 24)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo25.jpg', 25)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo26.jpg', 26)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo27.jpg', 27)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo28.jpg', 28)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo29.jpg', 29)
INSERT INTO images (image_string, animal_id) VALUES ('\src\PetPics - Copy\photo30.jpg', 30)




GO