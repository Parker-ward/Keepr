CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    keep(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        creatorId VARCHAR(255) NOT NULL,
        name VARCHAR(255) NOT NULL,
        description VARCHAR(1000) NOT NULL,
        img VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

DROP TABLE keep;

INSERT INTO
    keep(
        name,
        description,
        img,
        creatorId
    )
VALUES (
        "Space",
        "The great UNKNOWN",
        'https://images.unsplash.com/photo-1679542501404-5f994a2ecb4d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHx0b3BpYy1mZWVkfDE1fDZzTVZqVExTa2VRfHxlbnwwfHx8fA%3D%3D&auto=format&fit=crop&w=800&q=60',
        '63ff7a1cba75a11b4a016f8b'
    );

CREATE TABLE
    vault(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        creatorId VARCHAR(255) NOT NULL,
        name VARCHAR(255) NOT NULL,
        description VARCHAR(1000) NOT NULL,
        img VARCHAR(255) NOT NULL,
        isPrivate BOOLEAN NOT NULL DEFAULT false,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

DROP TABLE vault;

INSERT INTO
    vault(
        name,
        img,
        description,
        creatorId
    )
VALUES (
        "trees",
        "such tall trees",
        'https://images.unsplash.com/photo-1462143338528-eca9936a4d09?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8dHJlZXN8ZW58MHx8MHx8&auto=format&fit=crop&w=500&q=60',
        '64056596b253fcef8a1f4da0'
    );

CREATE TABLE
    vaultKeeps(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        creatorId VARCHAR(255) NOT NULL,
        vaultId INT NOT NULL,
        keepId INT NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
        FOREIGN KEY (vaultId) REFERENCES vault(id) ON DELETE CASCADE,
        FOREIGN KEY (keepId) REFERENCES keep(id) ON DELETE CASCADE,
        UNIQUE (creatorId, vaultId)
    ) default charset utf8 COMMENT '';

INSERT INTO
    vaultKeeps(creatorId, vaultId, keepId)
VALUES (
        '64056596b253fcef8a1f4da0',
        1,
        1
    );

SELECT vk.*, k.*, creator.*
FROM vaultKeeps vk
    JOIN keep k ON vk.keepId = k.id
    JOIN accounts creator ON k.creatorId = creator.id
WHERE
    vk.vaultId = @vaultId;

SELECT k.* creator.*
FROM keep k
    JOIN accounts creator ON k.creatorId = creator.id
WHERE
    k.creatorId = @creatorId;