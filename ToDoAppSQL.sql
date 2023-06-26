USE todo;

DROP TABLE todos;
GO

CREATE TABLE todos
(
	Id UNIQUEIDENTIFIER default newid(),
    Todo VARCHAR(255) NOT NULL,
    Done VARCHAR(255) NOT NULL,
    PRIMARY KEY(Id)
);
GO

INSERT INTO todos(Todo, Done)
VALUES
('Create API', 'Done');
GO

SELECT * FROM todos;