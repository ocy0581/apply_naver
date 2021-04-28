<!DOCTYPE html>
<html>
<head> 
<meta charset="utf-8">
<title>PHP 프로그래밍 입문</title>
<link rel="stylesheet" type="text/css" href="./css/common.css">
<link rel="stylesheet" type="text/css" href="./css/board.css">   
<script type="text/javascript" src="https://openapi.map.naver.com/openapi/v3/maps.js?ncpClientId=3x62gkpqxy"></script>

<script>
  function check_input() {
      if (!document.board_form.subject.value)
      {
          alert("제목을 입력하세요!");
          document.board_form.subject.focus();
          return;
      }
      if (!document.board_form.content.value)
      {
          alert("내용을 입력하세요!");    
          document.board_form.content.focus();
          return;
      }
      document.board_form.submit();
   }
</script>
</head>
<body> 
<header>
	<?php include "header.php";
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
		setcookie("foodid",$tmpstr);
	}
	else{
		
		echo("
					<script>
					alert('음식 선택 입력오류');
					history.go(-1)
					</script>
		");
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
	// echo count($out);
	?>
</header>  

<section>
	<input type="hidden" name="food">
	<div id="main_img_bar">
        <img src="./img/main_img.png">
    </div>
   	<div id="board_box">
	    <h3 id="board_title">
	    		음식 선택하기 > 게시글 쓰기	
		</h3>
	    <form  name="board_form" method="post" action="board_insert.php" enctype="multipart/form-data">
	    	 <ul id="board_form">
				<li>
					<span class="col1">이름 : </span>
					<span class="col2"><?=$username?></span>
				</li>		
	    		<li>
	    			<span class="col1">제목 : </span>
	    			<span class="col2"><input name="subject" type="text"></span>
	    		</li>	    	
	    		<li id="text_area">	
	    			<span class="col1">내용 : </span>
	    			<span class="col2">
	    				<textarea name="content"></textarea>
	    			</span>
	    		</li>
	    		<li>
			        <span class="col1"> 음식 목록</span>
			        <span class="col2">
					<?php
						$sumprice=0;
						$con = mysqli_connect("localhost", "user1", "12345", "sample");
						$sql = "select * from store where idstore = $idstore";						
						$result = mysqli_query($con, $sql);
						$row = mysqli_fetch_array($result);
						$tip = $row["deliveryTip"];
						$minPrice = $row["min_price"];
						// echo "$tip , $minPrice";

						for ($i=0; $i < count($out); $i++) { 
							$sql = "select * from food where idfood = '$out[$i]'";
							$result = mysqli_query($con, $sql);
							// echo ($result);
							$row = mysqli_fetch_array($result);
							
							$id =$row["idfood"];
							$name = $row["name"];
							$price = $row["price"];

							$sumprice += (int)$price*(int)$foodcount[$i];
							// echo "debug $sumprice <br>debug";
					?>
					<div class="foodwrapper">
						<p class="textfood"><?=$name?><br></p>
						<p class="textfood"><?=$price?>원<br></p>
						<p class="textfood"><?=$foodcount[$i]?>개<br></p>
					</div>
					<?php
						}
						// echo $sql;
						
						mysqli_close($con);   
						
					?>
					</span>
				</li>
				<li>
					<span class="col1">최소 배달 금액 : </span>
					<span class="col2"><?=$minPrice?>원</span>
				</li>	
				<li>
					<span class="col1">배달 팁: </span>
					<span class="col2"><?=$tip ?>원</span>
				</li>	
				<li>
					<span class="col1">현재 주문 가격 : </span>
					<span class="col2"><?=$sumprice?>원</span>
					<input type="hidden" name="sumprice" value="<?=$sumprice?>">
				</li>	
				<li>
					<span class="col1">받을 장소  : </span>
					<span class="col2">
					<div class="map_table">
						<!--네이버지도-->
						<div id="map"> </div>
					</div>
						
					</span>
				</li>	
	    	    </ul>
	    	<ul class="buttons">
				<li><button type="button" onclick="check_input()">완료</button></li>
				<li><button type="button" onclick="location.href='board_list.php'">목록</button></li>
			</ul>
	    </form>
	</div> <!-- board_box -->
</section> 
<footer>
    <?php include "footer.php";?>
</footer>
</body>

<script>
<?php
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
?>
var mapOptions = {
    center: new naver.maps.LatLng(<?=$y?>, <?=$x?>),
    zoom: 17,
    scaleControl: false,
    logoControl: true,
    mapDataControl: true,
    zoomControl: false,

};

// var map = new naver.maps.Map('map', {
//     });

var map = new naver.maps.Map('map', mapOptions);
var marker = new naver.maps.Marker({
    map: map,
    position: mapOptions.center
})

</script>
</html>

