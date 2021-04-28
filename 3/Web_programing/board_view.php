<!DOCTYPE html>
<html>
<head> 
<meta charset="utf-8">
<title>PHP 프로그래밍 입문</title>
<link rel="stylesheet" type="text/css" href="./css/common.css">
<link rel="stylesheet" type="text/css" href="./css/board.css">
<script type="text/javascript" src="https://openapi.map.naver.com/openapi/v3/maps.js?ncpClientId=3x62gkpqxy"></script>

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
	    <h3 class="title">
			게시판 > 내용보기
		</h3>
<?php
	$num  = $_GET["num"];
	$page  = $_GET["page"];

	$con = mysqli_connect("localhost", "user1", "12345", "sample");
	$sql = "select * from board where num=$num";
	$result = mysqli_query($con, $sql);

	$row = mysqli_fetch_array($result);
	$id      = $row["id"];
	$name      = $row["name"];
	$regist_day = $row["regist_day"];
	$subject    = $row["subject"];
	$content    = $row["content"];
	$hit          = $row["hit"];
	$x = $row["locationX"];
	$y = $row["locationY"];
	$store = $row["store"];
	$sumprce = $row["price"];
	$food	= $row["food"];
	$food = explode("-",$food);

	$sql = "select * from store where idstore = $store";
	
	$result = mysqli_query($con, $sql);

	$row = mysqli_fetch_array($result);
	$storeName = $row["name"];
	$type = $row["type"];
	$tip = $row["deliveryTip"];
	$minprice = $row["min_price"];
	

	for ($i=0; $i < count($food)-1; $i++) { 
		$tmp = explode("_",$food[$i]);
		$foodid[$i] = $tmp[0];
		$foodcount[$i] = $tmp[1];
		// echo "{$foodid[$i]} {$foodcount[$i]}";
		$sql = "select * from food where idfood = $foodid[$i]";
		$result = mysqli_query($con, $sql);
		$row = mysqli_fetch_array($result);

		$foodname[$i] = $row["name"];
		$foodprice[$i] = $row["price"];

	}

	$content = str_replace(" ", "&nbsp;", $content);
	$content = str_replace("\n", "<br>", $content);

	$new_hit = $hit + 1;
	$sql = "update board set hit=$new_hit where num=$num";   
	mysqli_query($con, $sql);
?>		
	    <ul id="view_content">
			<li id="subject">
				<span class="col1"><b>제목 :</b> <?=$subject?></span>
				<span class="col2"><?=$name?> | <?=$regist_day?></span>
			</li>	
			<li id="setting">
				
				<span class="col1"><b>타입 :</b> <?=$type?></span>
				<!-- <span class="col2"><?=$name?> | <?=$regist_day?></span> -->
			</li>
			<li id="setting">				
				<span class="col1"><b>가게이름 :</b> <?=$storeName?></span>
				<!-- <span class="col2"><?=$name?> | <?=$regist_day?></span> -->
			</li>
			<li id="content">
				<?=$content?>
			</li>	
			<li id="setting">
			<?php
				for ($i=0; $i < count($foodid); $i++) { 
					
				
			?>
				<div class="foodlist">
					<span class="col1"><b>음식이름 :</b> <?=$foodname[$i]?></span>
					<span class="food1"><b>가격 : </b><?=$foodprice	[$i]?>원</span>
					<span class="food1"><b>개수 : </b><?=$foodcount[$i]?>개</span>
				</div>
				
				
			<?php
				}
			?>
			</li>
			<li id="setting">
				<span class="col1"><b>최소 배달금액 :</b> <?=$minprice?>원</span>
				
			</li>
			<li id="setting">
				<span class="col1"><b>배달팁 :</b> <?=$tip?>원</span>
				
			</li>
			<li id="setting">
				<span class="col1"><b>현재 가격 :</b> <?=$sumprce?>원</span>				
			</li>
			<li id="setting">
				<span class="col1"><b>추가 주문금액 :</b> <?=$minprice- $sumprce?>원</span>				
			</li>
			<li id="setting">
				<span class="location"><b>받을장소 :</b></span>
				
					<div id="mapwrapper">

					<div class="map_table">
						<!--네이버지도-->
						<div id="map"> </div>
					</div>
					</div>
			</li>
	    </ul>
	    <ul class="buttons">
				<li><button onclick="location.href='board_list.php?page=<?=$page?>'">목록</button></li>
				<li><button onclick="location.href='board_delete.php?num=<?=$num?>&page=<?=$page?>'">삭제</button></li>
				<li><button onclick="location.href='./delivery_location.php'">글쓰기</button></li>
				<li><button onclick="location.href='./order.php?num=<?=$num?>&page=<?=$page?>&price=<?=$sumprce?>'">추가로 주문하기</button></li>
		</ul>
	</li> <!-- board_box -->
</section> 
<footer>
    <?php include "footer.php";?>
</footer>
</body>
</html>
<script>
	
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
