<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <title>PHP 프로그래밍 입문</title>
    <link rel="stylesheet" type="text/css" href="./css/common.css">
    <link rel="stylesheet" type="text/css" href="./css/board.css?ver=1">
<link rel="stylesheet" type="text/css" href="./css/member.css?ver=4">
</head>

<body>
    <header>
        <?php include "header.php";
        $idstore = $_GET["idstore"];
        ?>
    </header>
    <style>
    </style>
    <section>
        <div id="main_img_bar">
            <img src="./img/main_img.png">
        </div>

        <div id="board_box">
            <h3 class="title">
                음식 추가하기 > 음식 입력
            </h3>


            <div id="main_content">
                <div id="join_box">
                    <form name="store_form" method="post" action="food_insert.php">
                        <h2>음식 추가하기</h2>
                        <div class="form name">
                            <div class="col1">음식이름</div>
                            <div class="col2">
                                <input type="text" name="name" value="">
                            </div>
                        </div>
                        <div class="clear"></div>

                        <div class="form">
                            <div class="col1">가격</div>
                            <div class="col2">
                                <input type="text" name="price" value="">
                            </div>
                        </div>
                        <div class="clear"></div>
                        <div class="bottom_line"> </div>
                        <input type="hidden" name="idstore" value="<?=$idstore?>" />
                        
                        <div class="buttons">
                            <img style="cursor:pointer" src="./img/button_save.gif" onclick="check_input()">&nbsp;
                            <img id="reset_button" style="cursor:pointer" src="./img/button_reset.gif"
                                onclick="reset_form()">
                        </div>
                    </form>
                </div> <!-- join_box -->
            </div> <!-- main_content -->
        </div>

        <script>
function check_input() {
    if (!document.store_form.name.value) {
        alert("이름을 입력하세요!");
        document.store_form.name.focus();
        return;
    }

    if (!document.store_form.price.value) {
        alert("가격을 입력하세요!");
        document.store_form.price.focus();
        return;
    }

    document.store_form.submit();
}

function reset_form() {
    document.store_form.name.value = "";
    document.store_form.price.value = "";
    document.store_form.name.focus();
    return;
}
</script>



    </section>
    <footer>
        <?php include "footer.php";?>
    </footer>
    
</html>
