-- Creat a database named 'lp_db'
CREATE DATABASE IF NOT EXISTS lp_db;

-- Use the 'lp_db' database
USE lp_db;

-- Create a user table
CREATE TABLE `User` (
    `Id` BIGINT NOT NULL AUTO_INCREMENT,
    `FirstName` VARCHAR(50) NOT NULL,
    `MiddleName` VARCHAR(50) DEFAULT '',
    `LastName` VARCHAR(50) NOT NULL,
    `DateOfBirth` DATE NOT NULL,
    `Email` VARCHAR(100) NOT NULL,
    `Password` VARCHAR(255) NOT NULL,
    `Username` VARCHAR(50) NOT NULL,
    `Role` ENUM('TEACHER', 'STUDENT', 'ADMIN') NOT NULL,
    PRIMARY KEY (`Id`),
    UNIQUE (`Email`),
    UNIQUE (`Username`)
);

-- Insert some sample users
INSERT INTO `User` (`FirstName`, `MiddleName`, `LastName`, `DateOfBirth`, `Email`, `Password`, `Username`, `Role`)
VALUES 
('John', '', 'Doe', '1990-01-01', 'john.doe@example.com', 'password123', 'johndoe', 'STUDENT'),
('Jane', 'A.', 'Smith', '1985-02-02', 'jane.smith@example.com', 'password123', 'janesmith', 'ADMIN'),
('Michael', 'B.', 'Johnson', '1979-03-03', 'michael.johnson@example.com', 'password123', 'michaeljohnson', 'STUDENT'),
('Emily', '', 'Williams', '1992-04-04', 'emily.williams@example.com', 'password123', 'emilywilliams', 'STUDENT'),
('David', 'C.', 'Brown', '1988-05-05', 'david.brown@example.com', 'password123', 'davidbrown', 'STUDENT'),
('Jessica', '', 'Jones', '1991-06-06', 'jessica.jones@example.com', 'password123', 'jessicajones', 'ADMIN'),
('Daniel', '', 'Garcia', '1984-07-07', 'daniel.garcia@example.com', 'password123', 'danielgarcia', 'TEACHER'),
('Sarah', 'D.', 'Martinez', '1993-08-08', 'sarah.martinez@example.com', 'password123', 'sarahmartinez', 'TEACHER'),
('Chris', '', 'Lee', '1986-09-09', 'chris.lee@example.com', 'password123', 'chrislee', 'STUDENT'),
('Laura', 'E.', 'Hernandez', '1995-10-10', 'laura.hernandez@example.com', 'password123', 'laurahernandez', 'STUDENT');

-- Create a table for learning modules
CREATE TABLE IF NOT EXISTS LearningModule (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    description TEXT
);

-- Insert three learning modules
INSERT INTO LearningModule (name, description) VALUES
('Math Basics', 'A module covering basic mathematics concepts.'),
('History 101', 'An introductory module on world history.'),
('Science Fundamentals', 'A module that introduces fundamental concepts in science.');

-- Create a table for learning activities
CREATE TABLE LearningActivity (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    description VARCHAR(255) NOT NULL,
    type ENUM('MULTIPLECHOICE', 'FILLINTHEBLANK', 'TRUEFALSE', 'INSTRUCTION', 'QUIZ') NOT NULL,
    module_id INT NOT NULL,
    FOREIGN KEY (module_id) REFERENCES LearningModule(id)
);

-- Insert Learning Activities for Each Learning Module
-- Learning Activities for Math Basics (id=1)
INSERT INTO LearningActivity (name, description, type, module_id)
VALUES
    ('Basic Addition', 'Learn how to add numbers.', 'MULTIPLECHOICE', 1),
    ('Subtraction Basics', 'Learn how to subtract numbers.', 'FILLINTHEBLANK', 1),
    ('Multiplication Introduction', 'Introduction to multiplication.', 'TRUEFALSE', 1),
    ('Division Basics', 'Learn how to divide numbers.', 'INSTRUCTION', 1);

-- Learning Activities for History 101 (id=2)
INSERT INTO LearningActivity (name, description, type, module_id)
VALUES
    ('Ancient Civilizations', 'Overview of ancient civilizations.', 'MULTIPLECHOICE', 2),
    ('Medieval History', 'Key events from the medieval period.', 'FILLINTHEBLANK', 2),
    ('Modern History', 'Important events of modern history.', 'TRUEFALSE', 2),
    ('World Wars', 'Detailed study of World Wars.', 'INSTRUCTION', 2);

-- Learning Activities for Science Fundamentals (id=3)
INSERT INTO LearningActivity (name, description, type, module_id)
VALUES
    ('Physics Basics', 'Introduction to basic physics concepts.', 'MULTIPLECHOICE', 3),
    ('Chemistry Fundamentals', 'Basic chemistry concepts.', 'FILLINTHEBLANK', 3),
    ('Biology Overview', 'Study of basic biology.', 'TRUEFALSE', 3),
    ('Earth Science', 'Overview of earth science.', 'INSTRUCTION', 3),
    ('Environmental Science', 'Introduction to environmental science.', 'QUIZ', 3);