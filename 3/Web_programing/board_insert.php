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
                    history.go(-1)
                    </script>
        ");
                exit;
	}
	
	if(isset($_COOKIE["X"]) && isset($_COOKIE["Y"])){
		$x = $_COOKIE["X"];
		$y = $_COOKIE["Y"];
	}
	else{
		echo("
					<script>
					alert('받는 장소 좌표 입력오류');
					location.href='./delivery_location.php';
					</script>
		");
				exit;
	}
	
	if(isset($_COOKIE["idstore"])){
		$idstore = $_COOKIE["idstore"];
	}
	else{
		
		echo("
					<script>
					alert('매장 선택 입력오류');
					location.href='./delivery_store.php';
					</script>
		");
	}
	
	if(isset($_COOKIE["foodid"])){
		$foodid = $_COOKIE["foodid"];
	}
	else{
		
		echo("
					<script>
					alert('음식 선택 입력오류');
					location.href='./food_select.php';
					</script>
		");
	}

    $subject = $_POST["subject"];
    $content = $_POST["content"];
	$sumprice = $_POST["sumprice"];

	$subject = htmlspecialchars($subject, ENT_QUOTES);
	$content = htmlspecialchars($content, ENT_QUOTES);
	$sumprice = htmlspecialchars($sumprice, ENT_QUOTES);

	$regist_day = date("Y-m-d (H:i)");  // 현재의 '년-월-일-시-분'을 저장

	$con = mysqli_connect("localhost", "user1", "12345", "sample");

	$sql = "insert into board (id, name, subject, content, regist_day, hit, locationX,locationY,store,price,food) ";
	$sql .= "values('$userid', '$username', '$subject', '$content', '$regist_day', 0, ";
	$sql .= "'$x', '$y', '$idstore','$sumprice','$foodid')";
	mysqli_query($con, $sql);  // $sql 에 저장된 명령 실행

	// 포인트 부여하기
  	$point_up = 100;

	$sql = "select point from members where id='$userid'";
	$result = mysqli_query($con, $sql);
	$row = mysqli_fetch_array($result);
	$new_point = $row["point"] + $point_up;
	
	$sql = "update members set point=$new_point where id='$userid'";
	mysqli_query($con, $sql);

	mysqli_close($con);                // DB 연결 끊기

	echo "
	   <script>
	    location.href = 'board_list.php';
	   </script>
	";
?>

  
