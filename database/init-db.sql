CREATE DATABASE JunkiappDB;
GO
USE JunkiappDB;
GO
CREATE TABLE users (
    id INT PRIMARY KEY IDENTITY,
    username NVARCHAR(100) NOT NULL,
    email NVARCHAR(255) NOT NULL,
    password_hash NVARCHAR(255) NOT NULL,
    created_at DATETIME DEFAULT GETDATE()
);
GO
CREATE TABLE junk_items (
    id INT PRIMARY KEY IDENTITY,
    user_id INT NOT NULL,
    title NVARCHAR(255) NOT NULL,
    description NVARCHAR(MAX),
    latitude FLOAT,
    longitude FLOAT,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES users(id)
);
GO
CREATE TABLE junk_pictures (
    id INT PRIMARY KEY IDENTITY,
    junk_item_id INT NOT NULL,
    image_url NVARCHAR(512) NOT NULL,
    uploaded_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (junk_item_id) REFERENCES junk_items(id)
);
GO
