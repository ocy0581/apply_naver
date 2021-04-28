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
	
	if(isset($_GET["foodid"])){	
		$foodIdList = explode("_",$_GET["foodid"]) ;
		$tmp = 0;
		$tmpstr = "";
		for ($i=1; $i < count($foodIdList); $i++) { 
			$food[$i] = $_GET[$foodIdList[$i]];
			if($food[$i] != 0){
				$out[$tmp] = $foodIdList[$i];
				$foodcount[$tmp] = $food[$i];
				$tmp +=1;
				$tmpstr = $tmpstr."$foodIdList[$i]"."_"."$food[$i]"."-";
			}
			
			// echo "$i : $foodIdList[$i] : $food[$i] | $tmpstr<br>";	
		}
		// setcookie("foodid",$tmpstr);
	}
	else{
		
		echo("
					<script>
					alert('음식 선택 입력오류');
					history.go(-1)
					</script>
		");
	}

    $num = $_GET["num"];

	// $regist_day = date("Y-m-d (H:i)");  // 현재의 '년-월-일-시-분'을 저장

	$con = mysqli_connect("localhost", "user1", "12345", "sample");
    $sql = "select * from board where num = $num";
    $result = mysqli_query($con, $sql);  // $sql 에 저장된 명령 실행
    $row = mysqli_fetch_array($result);
    $x = $row["locationX"];
    $y = $row["locationY"];
    $store = $row["store"];
    
	$sql = "insert into order_sheet (user,food,locationX,locationY,store) ";
    $sql .= "values('$userid', '$tmpstr', '$x', '$y',$store) ";
    // echo $sql;

	mysqli_query($con, $sql);  // $sql 에 저장된 명령 실행

    $hostfood = $row["food"];
    // echo "$hostfood <br>";
    $hostid = $row["id"];
    $sql = "insert into order_sheet (user,food,locationX,locationY,store) ";
	$sql .= "values('$hostid', '$hostfood', '$x', '$y',$store) ";

    // echo $sql;
	mysqli_query($con, $sql);  // $sql 에 저장된 명령 실행
    // 가져올 레코드로 위치(포인터) 이동	

    $sql = "delete from board where num =$num";
	mysqli_query($con, $sql);  // $sql 에 저장된 명령 실행
	mysqli_close($con);                // DB 연결 끊기

	echo "
       <script>
       alert('수행완료');
	    location.href = 'board_list.php';
	   </script>
	";
?>

  
