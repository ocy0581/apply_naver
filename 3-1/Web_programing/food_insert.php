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
    
    $idstore = $_POST["idstore"];
	$price = $_POST["price"];
	$name = $_POST["name"];

	$idstore = htmlspecialchars($idstore, ENT_QUOTES);
	$price = htmlspecialchars($price, ENT_QUOTES);
	$name = htmlspecialchars($name, ENT_QUOTES);
	
    $con = mysqli_connect("localhost", "user1", "12345", "sample");
    $sql = "insert into food (idfood ,name, store, price) values (NULL,'$name', '$idstore', '$price')";   
	// echo $sql;
	mysqli_query($con, $sql);
    mysqli_close($con);       
    
	// echo "$sql";
	
	echo "
	   <script>
	   alert('음식 입력 완료');
	   history.go(-2);
	   </script>
	";
?>

  
