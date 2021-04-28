<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <title>PHP 프로그래밍 입문</title>
    <link rel="stylesheet" type="text/css" href="./css/common.css?ver=10">
    <link rel="stylesheet" type="text/css" href="./css/main.css">
    <link rel="stylesheet" type="text/css" href="./css/type.css?ver=2">
    <link rel="stylesheet" type="text/css" href="./css/store.css?ver=23">
</head>

<body>
    <header>
        <?php include "header.php";?>
        <?php 
    // session_start();
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
        if(isset($_GET["type"])){
            $type = $_GET["type"];
            $type_cookey = setcookie("type",$type);
        }
        else if(isset($_COOKIE["type"]))
        {
            $type = $_COOKIE["type"];
        }
        else {
            echo("
					<script>
					alert('타입 장소 좌표 입력오류');
					location.href='./delivery_type.php';
					</script>
		    ");
        }

    ?>
    </header>
    <section>
        <div class="type_container">
            <div id="main_img_bar">
                <img src="./img/main_img.png">
            </div>


            <div id="main_content">

                <div id="tmp">

                    <?php
    
	if (isset($_GET["page"]))
		$page = $_GET["page"];
	else
		$page = 1;

	$con = mysqli_connect("localhost", "user1", "12345", "sample");
    $sql = "select * from store where type = '$type' and left_location_X <= '$x' ";
    $sql .= "and left_location_Y <='$y' and right_location_X >='$x' and right_location_Y >= '$y'";
    // echo $sql;
	$result = mysqli_query($con, $sql);
	$total_record = mysqli_num_rows($result); // 전체 글 수
    // echo $result;
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
    //   echo $row;
      // 하나의 레코드 가져오기
      $picture = $row["picture"];
      $name = $row["name"];
      $type = $row["type"];
      $min_price = $row["min_price"];
      $deliveryTip = $row["deliveryTip"];
      $regist = $row["regist"];
      $idstore = $row["idstore"];
    //   echo "debug<br>$picture<br>debug";
            $file_path = "./data/store/{$type}";
            // echo "$picture";
        
      ?>

                    <div id="store">
                        <a class="astore" href="food_select.php?idstore=<?=$idstore?>">

                            <div class="image">
                                <img class="store_img" src=<?="$file_path/".$picture?> />

                            </div>
                            <p class="pstore"><?php echo "가게이름: {$name}<br>최소배달비용: {$min_price}원<br>배달팁: {$deliveryTip}원"?></p>
                        </a>
                    </div>

                    <?php
    //   if ($row["file_name"])
      	// $file_image = "<img src='./img/file.gif'>";
    //   else
      	// $file_image = " ";

   	   $number--;
   }
   mysqli_close($con);

?>
                </div>
            </div>
            <div class="footer_magin"></div>

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
            </div>
        </div>
    </section>
    <footer>
        <?php include "footer.php";?>
    </footer>
</body>
</html>