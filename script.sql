CREATE TABLE `Users` (
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

INSERT INTO `Users` (`FirstName`, `MiddleName`, `LastName`, `DateOfBirth`, `Email`, `Password`, `Username`, `Role`)
VALUES 
('John', '', 'Doe', '1990-01-01', 'john.doe@example.com', 'password123', 'johndoe', 'User'),
('Jane', 'A.', 'Smith', '1985-02-02', 'jane.smith@example.com', 'password123', 'janesmith', 'Admin'),
('Michael', 'B.', 'Johnson', '1979-03-03', 'michael.johnson@example.com', 'password123', 'michaeljohnson', 'User'),
('Emily', '', 'Williams', '1992-04-04', 'emily.williams@example.com', 'password123', 'emilywilliams', 'User'),
('David', 'C.', 'Brown', '1988-05-05', 'david.brown@example.com', 'password123', 'davidbrown', 'User'),
('Jessica', '', 'Jones', '1991-06-06', 'jessica.jones@example.com', 'password123', 'jessicajones', 'Admin'),
('Daniel', '', 'Garcia', '1984-07-07', 'daniel.garcia@example.com', 'password123', 'danielgarcia', 'User'),
('Sarah', 'D.', 'Martinez', '1993-08-08', 'sarah.martinez@example.com', 'password123', 'sarahmartinez', 'User'),
('Chris', '', 'Lee', '1986-09-09', 'chris.lee@example.com', 'password123', 'chrislee', 'User'),
('Laura', 'E.', 'Hernandez', '1995-10-10', 'laura.hernandez@example.com', 'password123', 'laurahernandez', 'User');

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