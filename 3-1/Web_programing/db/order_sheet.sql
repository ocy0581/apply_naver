  CREATE TABLE order_sheet (
    num int(11) NOT NULL AUTO_INCREMENT,
    user varchar(45) NOT NULL,
    food varchar(45) NOT NULL,
    regist datetime DEFAULT current_timestamp(),
    locationX varchar(45) DEFAULT NULL,
    locationY varchar(45) DEFAULT NULL,
    store int(11) NOT NULL,
    PRIMARY KEY (num)
  ) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
