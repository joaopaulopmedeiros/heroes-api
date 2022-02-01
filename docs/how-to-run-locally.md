# How to run this project on localhost?

## Prereqs
- Docker installed;

## Step-by-step
1. Run docker container for MySQL
```
docker run -e MYSQL_ROOT_PASSWORD=root --name mysql-docker-example -d -p 3306:3306 mysql:8.0.27
```

2. Use DDL for creating database and tables with data
```
CREATE TABLE IF NOT EXISTS comics (
  id smallint NOT NULL AUTO_INCREMENT,
  name varchar(100) NOT NULL,
  PRIMARY KEY (id),
  UNIQUE KEY comics_name (name)
);

INSERT INTO comics (name)
VALUES
('DC'),
('MARVEL');

CREATE TABLE IF NOT EXISTS heroes(
	id int(11) NOT NULL AUTO_INCREMENT,
	comics_id smallint NOT NULL,
	name varchar(50) NOT NULL,
	power smallint NOT NULL,
	PRIMARY KEY(id),
	CONSTRAINT fk_heroes_comics FOREIGN KEY (comics_id) REFERENCES comics (id)
);

INSERT INTO heroes(name, power, comics_id) VALUES ('Superman', 100, 1);
```

3. Run docker container for Redis
```
docker run -p 6379:6379 redis
```