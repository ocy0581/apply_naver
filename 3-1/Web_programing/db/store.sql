CREATE TABLE store (
  idstore int(11) NOT NULL AUTO_INCREMENT,
  name varchar(45) NOT NULL,
  type varchar(20) NOT NULL,
  locationX varchar(45) DEFAULT NULL,
  locationY varchar(45) DEFAULT NULL,
  left_location_X varchar(45) DEFAULT NULL,
  left_location_Y varchar(45) DEFAULT NULL,
  right_location_X varchar(45) DEFAULT NULL,
  right_location_Y varchar(45) DEFAULT NULL,
  deliveryTip varchar(10) DEFAULT '0',
  min_price varchar(10) DEFAULT '0',
  regist datetime DEFAULT current_timestamp(),
  host char(15) NOT NULL,
  picture varchar(100) DEFAULT NULL,
  PRIMARY KEY (idstore)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
