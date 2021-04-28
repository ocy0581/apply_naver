<meta charset="utf-8">
<?php

	session_start();
	if (isset($_SESSION["userid"])) $userid = $_SESSION["userid"];
	else $userid = "";
	if (isset($_SESSION["username"])) $username = $_SESSION["username"];
	else $username = "";

	if ( !$userid )
	{
		echo("
					<script>
					alert('게시판 글쓰기는 로그인 후 이용해 주세요!');
					location.href='/index.php';
					</script>
		");
				exit;
	}

	if(isset($_COOKIE["loX"]) && isset($_COOKIE["loY"])){
		$locationX = $_COOKIE["loX"];
		$locationY = $_COOKIE["loY"];
	}
	else{
		echo("
					<script>
					alert('매장 좌표 입력 오류');
					location.href='/store_location.php';
					</script>
		");
				exit;
	}
	
	if(isset($_COOKIE["swX"]) && isset($_COOKIE["swY"]) && isset($_COOKIE["neY"]) && isset($_COOKIE["neY"])){
		$left_locationX = $_COOKIE["swX"];
		$left_locationY = $_COOKIE["swY"];
		$right_locationX = $_COOKIE["neX"];
		$right_locationY = $_COOKIE["neY"];
	}
	else{
		echo("
					<script>
					alert('배달범위 좌표 입력 오류');
					location.href='/store_distance.php';
					</script>
		");
				exit;
	}

    $name = $_POST["name"];
	$type = $_POST["type"];
	$deliveryTip = $_POST["deliveryTip"];
	$minprice = $_POST["minprice"];

	$name = htmlspecialchars($name, ENT_QUOTES);
	$type = htmlspecialchars($type, ENT_QUOTES);
	$deliveryTip = htmlspecialchars($deliveryTip, ENT_QUOTES);
	$minprice = htmlspecialchars($minprice, ENT_QUOTES);
	$locationX = htmlspecialchars($locationX, ENT_QUOTES);
	$locationY = htmlspecialchars($locationY, ENT_QUOTES);
	$left_locationX = htmlspecialchars($left_locationX, ENT_QUOTES);
	$left_locationY = htmlspecialchars($left_locationY, ENT_QUOTES);
	$right_locationX = htmlspecialchars($right_locationX, ENT_QUOTES);
	$right_locationY = htmlspecialchars($right_locationY, ENT_QUOTES);


	// $regist_day = date("Y-m-d (H:i)");  // 현재의 '년-월-일-시-분'을 저장

	$upload_dir = './data/store/'.$type.'/';

	$upfile_name	 = $_FILES["upfile"]["name"];
	$upfile_tmp_name = $_FILES["upfile"]["tmp_name"];
	$upfile_type     = $_FILES["upfile"]["type"];
	$upfile_size     = $_FILES["upfile"]["size"];
	$upfile_error    = $_FILES["upfile"]["error"];

	if ($upfile_name && !$upfile_error)
	{
		$file = explode(".", $upfile_name);
		$file_name = $file[0];
		$file_ext  = $file[1];

		$new_file_name = $name.date("Y_m_d_H_i_s");
		// $new_file_name = $new_file_name;
		$copied_file_name = $new_file_name.".".$file_ext;      
		$uploaded_file = $upload_dir.$copied_file_name;

		if( $upfile_size  > 10000000 ) {
				echo("
				<script>
				alert('업로드 파일 크기가 지정된 용량(10MB)을 초과합니다!<br>파일 크기를 체크해주세요! ');
				history.go(-1)
				</script>
				");
				exit;
		}

		if (!move_uploaded_file($upfile_tmp_name, $uploaded_file) )
		{
				echo("
					<script>
					alert('파일을 지정한 디렉토리에 복사하는데 실패했습니다.');
					history.go(-1)
					</script>
				");
				exit;
		}

	}
	else 
	{
		$upfile_name      = "";
		$upfile_type      = "";
		$copied_file_name = " ";
	}
	
	$con = mysqli_connect("localhost", "user1", "12345", "sample");
	mysqli_query($con,"use sample");
	// echo "
	//    <script>
	//    alert('디버깅 입력 직전:');
	//    </script>
	//    <br>
	//    ";		
	$sql = "INSERT INTO store (host,name, type, deliveryTip, min_price,picture,";
	$sql .= "locationX,locationY,left_location_X,left_location_Y,right_location_X,right_location_Y)";
	$sql .= " VALUES ('$userid','$name', '$type', '$deliveryTip', '$minprice','$copied_file_name',";
	$sql .=	"'$locationX','$locationY','$left_locationX','$left_locationY','$right_locationX','$right_locationY')";
	// echo "<br>".$sql;
	mysqli_query($con, $sql);  // $sql 에 저장된 명령 실행


	// // 포인트 부여하기
  	// $point_up = 100;

	// $sql = "select point from members where id='$userid'";
	// $result = mysqli_query($con, $sql);
	// $row = mysqli_fetch_array($result);
	// $new_point = $row["point"] + $point_up;
	
	// $sql = "update members set point=$new_point where id='$userid'";
	// mysqli_query($con, $sql);

	mysqli_close($con);                // DB 연결 끊기
	
	echo "
	   <script>
	   alert('입력 완료!');
	    location.href = 'index.php';
	   </script>
	";
?>

  
