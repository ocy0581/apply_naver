CREATE TABLE members (
  num int(11) NOT NULL AUTO_INCREMENT,
  id char(15) NOT NULL,
  pass char(15) NOT NULL,
  name char(10) NOT NULL,
  email char(80) DEFAULT NULL,
  regist_day char(20) DEFAULT NULL,
  level int(11) DEFAULT NULL,
  point int(11) DEFAULT NULL,
  phone varchar(45) DEFAULT NULL,
  PRIMARY KEY (num)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
