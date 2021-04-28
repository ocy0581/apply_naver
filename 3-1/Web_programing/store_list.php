<!DOCTYPE html>
<html>
<head> 
<meta charset="utf-8">
<title>PHP 프로그래밍 입문</title>
<link rel="stylesheet" type="text/css" href="./css/common.css">
<link rel="stylesheet" type="text/css" href="./css/board.css?ver=2">
<link rel="stylesheet" type="text/css" href="./css/member.css?ver=2">
</head>
<body> 
<header>
    <?php include "header.php";?>
</header>  
<section>
	<div id="main_img_bar">
        <img src="./img/main_img.png">
    </div>  
   	<div id="board_box">
	    <h3>
	    	음식 추가하기 > 매장 선택
		</h3>
	    <ul id="board_list">
				<li>
					<span class="col1">번호</span>
					<span class="col2">가게이름</span>
					<span class="col3">가게 종류</span>
					<span class="col4">최수 주문가격</span>
					<span class="col5">배달팁</span>
					<span class="col6">등록일자</span>


				</li>
<?php
	if (isset($_SESSION["userid"])) $userid = $_SESSION["userid"];
	else $userid = "";
	if (isset($_SESSION["username"])) $username = $_SESSION["username"];
	else $username = "";

	if ( !$userid )
	{
		echo("
					<script>
					alert('음식 추가하기 로그인 후 이용해 주세요!');
					location.href='/index.php';
					</script>
		");
				exit;
    }
    
	if (isset($_GET["page"]))
		$page = $_GET["page"];
	else
		$page = 1;

	$con = mysqli_connect("localhost", "user1", "12345", "sample");
	$sql = "select * from store where host = '$userid'";
	// echo $sql;
	$result = mysqli_query($con, $sql);
	$total_record = mysqli_num_rows($result); // 전체 글 수

	$scale = 10;

	// 전체 페이지 수($total_page) 계산 
	if ($total_record % $scale == 0)     
		$total_page = floor($total_record/$scale);      
	else
		$total_page = floor($total_record/$scale) + 1; 
 
	// 표시할 페이지($page)에 따라 $start 계산  
	$start = ($page - 1) * $scale;      

	$number = $total_record - $start;

   for ($i=$start; $i<$start+$scale && $i < $total_record; $i++)
   {
      mysqli_data_seek($result, $i);
      // 가져올 레코드로 위치(포인터) 이동
      $row = mysqli_fetch_array($result);
      // 하나의 레코드 가져오기
      $idstore = $row["idstore"];
      $name = $row["name"];
      $type = $row["type"];
      $min_price = $row["min_price"];
      $deliveryTip = $row["deliveryTip"];
      $regist = $row["regist"];
    //   if ($row["file_name"])
      	// $file_image = "<img src='./img/file.gif'>";
    //   else
      	// $file_image = " ";
?>
				<li>
					<span class="col1"><?=$idstore?></span>					
					<span class="col2"><a href="food_input.php?idstore=<?=$idstore?>&page=<?=$page?>&name=<?=$name?>"><?=$name?></a></span>
					<span class="col3"><?=$type?></span>
					<span class="col4"><?=$min_price?></span>
					<span class="col5"><?=$deliveryTip?></span>
					<span class="col6"><?=$regist?></span>
				</li>	
<?php
   	   $number--;
   }
   mysqli_close($con);

?>
	    	</ul>
			<ul id="page_num"> 	
<?php
	if ($total_page>=2 && $page >= 2)	
	{
		$new_page = $page-1;
		echo "<li><a href='board_list.php?page=$new_page'>◀ 이전</a> </li>";
	}		
	else 
		echo "<li>&nbsp;</li>";

   	// 게시판 목록 하단에 페이지 링크 번호 출력
   	for ($i=1; $i<=$total_page; $i++)
   	{
		if ($page == $i)     // 현재 페이지 번호 링크 안함
		{
			echo "<li><b> $i </b></li>";
		}
		else
		{
			echo "<li><a href='board_list.php?page=$i'> $i </a><li>";
		}
   	}
   	if ($total_page>=2 && $page != $total_page)		
   	{
		$new_page = $page+1;	
		echo "<li> <a href='board_list.php?page=$new_page'>다음 ▶</a> </li>";
	}
	else 
		echo "<li>&nbsp;</li>";
?>
			</ul> <!-- page -->	    
	</div> <!-- board_box -->
</section> 
<footer>
    <?php include "footer.php";?>
</footer>
</body>
</html>
