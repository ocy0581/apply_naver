<!DOCTYPE html>
<html>
<head> 
<meta charset="utf-8">
<title>PHP 프로그래밍 입문</title>
<link rel="stylesheet" type="text/css" href="./css/common.css">
<link rel="stylesheet" type="text/css" href="./css/board.css?ver=2">
<link rel="stylesheet" type="text/css" href="./css/member.css?ver=2">
<link rel="stylesheet" type="text/css" href="./css/select.css?ver=2">
<script type="text/javascript" src="https://openapi.map.naver.com/openapi/v3/maps.js?ncpClientId=3x62gkpqxy"></script>

</head>
<body> 
<header>
    <?php include "header.php"; ?>
    
</header>  
<script>
</script>
<section>
	<div id="main_img_bar">
        <img src="./img/main_img.png">
    </div>  
   	<div id="board_box">
	    <h3 id="h3">
            주문 확인하기 > 주문 확인
        </h3>
            <!-- <form action="board_form.php" method="get"> -->
	    <ul id="board_list">
				<li>
					<span class="col1">번호</span>
					<span class="col2">음식이름</span>
					<span class="col3">가격</span>
					<span class="col4">개수</span>
					<!-- <span class="col5">배달팁</span> -->
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
    
    if (isset($_GET["idstore"])){
        $idstore = $_GET["idstore"];
        setcookie("idstore",$idstore);
    }
    else
	{
		echo("
					<script>
					alert('음식 추가하기 로그인 후 이용해 주세요!');
					history.go(-1);
					</script>
		");
				exit;
    }

	$con = mysqli_connect("localhost", "user1", "12345", "sample");
	$sql = "select * from order_sheet where store = '$idstore'";
	// echo $sql;
	$result = mysqli_query($con, $sql);
	$total_record = mysqli_num_rows($result); // 전체 글 수
    // echo $total_record;
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
    //    echo $i;
      mysqli_data_seek($result, $i);
      // 가져올 레코드로 위치(포인터) 이동
      $row = mysqli_fetch_array($result);
      // 하나의 레코드 가져오기
      $user = $row["user"];
      $tmpnum = $row["num"];
    //   echo $tmpnum;

      $foodlist = $row["food"];
      $x = $row["locationX"];
      $y = $row["locationY"];
      $regist = $row["regist"];

      $food = explode("-",$foodlist);
      
    //   echo "디버그 ".$food[0];
    $foodid = [];
    $foodcount = [];
    $foodname = [];
    $foodprice= [];
	for ($j=0; $j < count($food)-1; $j++) { 
		$tmp = explode("_",$food[$j]);
		$foodid[$j] = $tmp[0];
		$foodcount[$j] = $tmp[1];
		// echo "{$foodid[$j]} {$foodcount[$j]}";
		$sql = "select * from food where idfood = $foodid[$j]";
		$tmpresult = mysqli_query($con, $sql);
        $tmprow = mysqli_fetch_array($tmpresult);

		$foodname[$j] = $tmprow["name"];
		$foodprice[$j] = $tmprow["price"];

	}

    //   if ($row["file_name"])
      	// $file_image = "<img src='./img/file.gif'>";
    //   else
      	// $file_image = " ";
?>
				<li class="bill">
                    <span class="col1"><?=$user?></span>
                    <div style="width: 240px;">
                    <?php
                        for ($j=0; $j < count($foodid); $j++) { 
                            echo $foodname[$j]."<br>";       
                 
                        }
                    
                    ?>		
                    </div>	
                    <div style="width: 100px; text-align:center;">
                    <?php
                        for ($j=0; $j < count($foodid); $j++) { 
                            echo $foodprice[$j]."<br>"; 
                        }
                    ?>	
                    </div>	
                    <div style="width: 130px;text-align:center;">
                    <?php
                        for ($j=0; $j < count($foodid); $j++) { 
                            echo $foodcount[$j]."<br>"; 
                        }
                    ?>	
                    </div>	
                    <span class="col4"><?=$regist?></span>
                    <span class="col5"><button onclick="location.href='./show_location.php?&x=<?=$x?>&y=<?=$y?>'">장소</button>
                    </span>
				</li>	
<?php
          $number--;
   }

?>
            </ul>
            <input id="foodIdInput" type="hidden" name="foodid" value="">
            <script>
    document.getElementById("foodIdInput").value = str;
                
            </script>
            <div class="submitButton">
            <button class="subButton" onclick="location.href='./index.php'" >완료</button>
            </div>

<!-- </form> -->



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
<script>
    
var currprice =  document.getElementById("curr");

</script>
<footer>
    <?php include "footer.php";?>
</footer>
</body>
</html>
