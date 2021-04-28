CREATE TABLE board (
  num int(11) NOT NULL AUTO_INCREMENT,
  id char(15) NOT NULL,
  name char(10) NOT NULL,
  subject char(200) NOT NULL,
  content text NOT NULL,
  regist_day char(20) NOT NULL,
  hit int(11) NOT NULL,
  locationX varchar(45) NOT NULL,
  locationY varchar(45) NOT NULL,
  store int(11) NOT NULL,
  price int(11) NOT NULL,
  food varchar(100) DEFAULT NULL,
  PRIMARY KEY (num)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;\