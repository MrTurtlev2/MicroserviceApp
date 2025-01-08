-- Tworzenie danych przyk³adowych dla tabeli trainers
INSERT INTO trainers (id, name, email, password) VALUES
(1, 'Mike Johnson', 'mike.johnson@example.com', 'password123'),
(2, 'Sarah Lee', 'sarah.lee@example.com', 'password456');

-- Tworzenie danych przyk³adowych dla tabeli pupils
INSERT INTO pupils (id, name, email, password, trainer_id) VALUES
(1, 'John Doe', 'john.doe@example.com', 'password789', 1),
(2, 'Jane Smith', 'jane.smith@example.com', 'password321', 2);
