CREATE DATABASE IF NOT EXISTS junkdb;

CREATE TABLE IF NOT EXISTS junkdb.junk_location (
    id VARCHAR(36),
    location POINT
);