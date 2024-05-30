-- Create a database named 'lp_db'
CREATE DATABASE IF NOT EXISTS lp_db;

-- Use the 'lp_db' database
USE lp_db;

-- Create a user table
CREATE TABLE `User` (
    `Id` INT NOT NULL AUTO_INCREMENT,
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
    type ENUM('MULTIPLECHOICE', 'FILLINTHEBLANK', 'QUIZ', 'INSTRUCTION') NOT NULL,
    module_id INT NOT NULL,
    FOREIGN KEY (module_id) REFERENCES LearningModule(id)
);

-- Insert Learning Activities for Each Learning Module
-- Learning Activities for Math Basics (id=1)
INSERT INTO LearningActivity (name, description, type, module_id)
VALUES
    ('Basic Addition', 'Learn how to add numbers.', 'QUIZ', 1),
    ('Subtraction Basics', 'Learn how to subtract numbers.', 'FILLINTHEBLANK', 1),
    ('Multiplication Introduction', 'Introduction to multiplication.', 'MULTIPLECHOICE', 1),
    ('Division Basics', 'Learn how to divide numbers.', 'INSTRUCTION', 1);

-- Learning Activities for History 101 (id=2)
INSERT INTO LearningActivity (name, description, type, module_id)
VALUES
    ('Ancient Civilizations', 'Overview of ancient civilizations.', 'QUIZ', 2),
    ('Medieval History', 'Key events from the medieval period.', 'FILLINTHEBLANK', 2),
    ('Modern History', 'Important events of modern history.', 'MULTIPLECHOICE', 2),
    ('World Wars', 'Detailed study of World Wars.', 'INSTRUCTION', 2);

-- Learning Activities for Science Fundamentals (id=3)
INSERT INTO LearningActivity (name, description, type, module_id)
VALUES
    ('Physics Basics', 'Introduction to basic physics concepts.', 'QUIZ', 3),
    ('Chemistry Fundamentals', 'Basic chemistry concepts.', 'FILLINTHEBLANK', 3),
    ('Biology Overview', 'Study of basic biology.', 'MULTIPLECHOICE', 3),
    ('Earth Science', 'Overview of earth science.', 'INSTRUCTION', 3),
    ('Environmental Science', 'Introduction to environmental science.', 'QUIZ', 3);

-- Create a table for progress with the new Date property
CREATE TABLE Progress (
    id INT AUTO_INCREMENT PRIMARY KEY,
    progress_type ENUM('LEARNINGACTIVITY', 'ASSESMENT', 'MODULE', 'PROJECT') NOT NULL,
    status ENUM('NOT_STARTED', 'IN_PROGRESS', 'COMPLETED') NOT NULL,
    progressDetails VARCHAR(255) NOT NULL,
    user_id INT NOT NULL,
    learningActivity_id INT NOT NULL,
    date DATE NOT NULL,  -- New date property
    FOREIGN KEY (user_id) REFERENCES `User`(Id),
    FOREIGN KEY (learningActivity_id) REFERENCES LearningActivity(id)
);

-- Insert Progress Records for Sample Users with dates

-- User: John Doe (id=1)
INSERT INTO Progress (progress_type, status, progressDetails, user_id, learningActivity_id, date)
VALUES
    ('LEARNINGACTIVITY', 'IN_PROGRESS', 'Working on basic addition.', 1, 1, '2023-05-01'),
    ('LEARNINGACTIVITY', 'NOT_STARTED', 'Not started subtraction basics.', 1, 2, '2023-05-02'),
    ('LEARNINGACTIVITY', 'COMPLETED', 'Completed multiplication introduction.', 1, 3, '2023-05-03');

-- User: Michael Johnson (id=3)
INSERT INTO Progress (progress_type, status, progressDetails, user_id, learningActivity_id, date)
VALUES
    ('LEARNINGACTIVITY', 'IN_PROGRESS', 'Studying ancient civilizations.', 3, 5, '2023-05-04'),
    ('LEARNINGACTIVITY', 'COMPLETED', 'Finished medieval history.', 3, 6, '2023-05-05'),
    ('LEARNINGACTIVITY', 'NOT_STARTED', 'Modern history not started.', 3, 7, '2023-05-06'),
    ('LEARNINGACTIVITY', 'IN_PROGRESS', 'Studying world wars.', 3, 8, '2023-05-07');

-- User: Emily Williams (id=4)
INSERT INTO Progress (progress_type, status, progressDetails, user_id, learningActivity_id, date)
VALUES
    ('LEARNINGACTIVITY', 'COMPLETED', 'Completed physics basics.', 4, 9, '2023-05-08'),
    ('LEARNINGACTIVITY', 'NOT_STARTED', 'Chemistry fundamentals not started.', 4, 10, '2023-05-09'),
    ('LEARNINGACTIVITY', 'IN_PROGRESS', 'Studying biology overview.', 4, 11, '2023-05-10'),
    ('LEARNINGACTIVITY', 'NOT_STARTED', 'Earth science not started.', 4, 12, '2023-05-11'),
    ('LEARNINGACTIVITY', 'IN_PROGRESS', 'Working on environmental science.', 4, 13, '2023-05-12');
