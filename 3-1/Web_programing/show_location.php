<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <title>PHP 프로그래밍 입문</title>
    <link rel="stylesheet" type="text/css" href="./css/common.css">
    <link rel="stylesheet" type="text/css" href="./css/main.css">
    <link rel="stylesheet" type="text/css" href="./css/location.css?ver=5">
    <script type="text/javascript" src="https://openapi.map.naver.com/openapi/v3/maps.js?ncpClientId=3x62gkpqxy">
    </script><!-- clientId 숨김 처리 요함 -->

</head>

<body>
    <header>
        <?php include "header.php";
            if (isset($_GET["x"]) && isset($_GET["y"])){
                $x = $_GET["x"];
                $y = $_GET["y"];
            }
            else
            {
                echo("
                            <script>
                            alert('오류!');
                            history.go(-1);
                            </script>
                ");
                        exit;
            }
        ?>
    </header>
    <section>

        <div class="location">

            <div class="map_table">
                <!--네이버지도-->
                <div id="map"> </div>
</div>
 <button class="submit" onclick="location.href='./check_store_list.php'" >이전으로</button> 


                </div>
            </div>

        </div>
    </section>
    <footer>
        <?php include "footer.php";?>
    </footer>
</body>

</html>


<script>
// var $header = $(".input_locationX");
var mapOptions = {
    center: new naver.maps.LatLng('<?=$y?>', '<?=$x?>'),
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
// map.panBy(new naver.maps.Point(10, 10)); // 오른쪽 아래로 10 픽셀 이동
</script>