<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <title>PHP 프로그래밍 입문</title>
    <link rel="stylesheet" type="text/css" href="./css/common.css?ver=1">
    <link rel="stylesheet" type="text/css" href="./css/main.css?ver=1">
    <link rel="stylesheet" type="text/css" href="./css/management.css?ver=3">
    <!-- <link rel="stylesheet" type="text/css" href="./css/type.css?ver=2"> -->
</head>

<body>
    <header>
        <?php include "header.php";?>
    </header>
    <section>
        <div id="main_img_bar">
            <img src="./img/main_img.png">
        </div>
        <div class="container">
            <div class="wrapper">
                <div class="selectBox">
                    <a href="./store_location.php">
                        <div class="image">
                            <img class="select_image" src="./img/store.png" alt="">
                            매장 추가하기
                        </div>
                    </a>
                </div>
                <div class="selectBox">
                    <a href="./store_list.php">
                        <div class="image">
                            <img class="select_image" src="./img/food.png" alt="">
                            음식 추가하기
                        </div>
                    </a>
                </div>
                <div class="selectBox">
                    <a href="./check_store_list.php">
                        <div class="image">
                            <img class="select_image" src="./img/주문서.png" alt="">
                            주문 확인하기
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </section>
    <footer>
        <?php include "footer.php";?>
    </footer>
</body>

</html>