<!DOCTYPE html>
<html>
<head> 
<meta charset="utf-8">
<title>PHP 프로그래밍 입문</title>
<link rel="stylesheet" type="text/css" href="./css/common.css?ver=10">
<link rel="stylesheet" type="text/css" href="./css/main.css">
<link rel="stylesheet" type="text/css" href="./css/type.css?ver=1">
</head>
<body> 
	<header>
    	<?php include "header.php";?>
    <?php 
        $X = $_GET["X"];
        $Y = $_GET["Y"];
        $x_cookey = setcookie("X",$X);            
        $y_cookey = setcookie("Y",$Y);
        // echo "$tmp asdasdasdasdasd";
    ?>
    </header>
	<section>

<div class="type_container">

<div id="main_img_bar">
    <a href="index.php">
        <img src="./img/main_img.png" >
    </a>
</div>
        <div id="main_content">
            
        <div id="tmp">
            <?php
    $typelist[0] = "한식";
    $typelist[1] = "피자";
    $typelist[2] = "중식";
    $typelist[3] = "치킨";
    $typelist[4] = "햄버거";
    $typelist[5] = "도시락";
    $typelist[6] = "족발보쌈";
    $typelist[7] = "야식";
    for ($i=0; $i < 8; $i++) { 
?>

    <div id="type">
        <a href="delivery_store.php?type=<?=$typelist[$i]?>">
        
            <div class="image">
                <img class="type_img" src=<?="./img/".$typelist[$i].".png"?> />
                
            </div>    
        <?= $typelist[$i] ?>
        </a>  
    </div>
<?php
    }
    ?>
            </div>
        </div>
        <div class="footer_magin"></div>
        </div>
	</section> 
	<footer>
    	<?php include "footer.php";?>
    </footer>
</body>
</html>

