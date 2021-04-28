<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <title>PHP 프로그래밍 입문</title>
    <link rel="stylesheet" type="text/css" href="./css/common.css">
    <link rel="stylesheet" type="text/css" href="./css/main.css">
    <link rel="stylesheet" type="text/css" href="./css/location.css?ver=2">
    <script type="text/javascript" src="https://openapi.map.naver.com/openapi/v3/maps.js?ncpClientId=3x62gkpqxy">
    </script><!-- clientId 숨김 처리 요함 -->

</head>

<body>
    <header>
        <?php include "header.php";?>
    </header>
    <section>

        <div class="location">

            <p class="location_title">받을 장소</p>
            <div class="map_table">
                <!--네이버지도-->
                <div id="map"> </div>
            </div>

            <div id="explain">
                <div class="text_wrapper">
                    <p class="explain_text  ">음식을 받을</p>
                    <p class="explain_text">위치를 정해주세요.</p>                    
                    <p class="explain_text2">지도를 클릭하면</p>
                    <p class="explain_text2">마커가 생기면서 </p>
                    <p class="explain_text2">좌표를 찾아줍니다.</p>
                </div> <div class="input_layer">
                <form  class="form_" action="delivery_type.php" method="GET">
                   
                        <p class="text">현재 위치 X좌표</p>
                            <input id="input_locationX" type="text" name="X" value="" readonly>
                        
                        <p class="text">현재 위치 Y좌표</p>
                            <input id="input_locationY" type="text" name="Y" value="" readonly>
                        
                        <input class="submit" type="submit" value="음식점선택" />

                </form>

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
    center: new naver.maps.LatLng(36.7647, 127.2824),
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
function setMarker(e) {
    marker.setPosition(e.coord);
    var tmp = e.coord;
    // return tmp;
    document.getElementById("input_locationX").value = tmp.x;
    document.getElementById("input_locationY").value = tmp.y;
   

};
naver.maps.Event.addListener(map, 'click',setMarker);

document.getElementById("input_locationX").value = marker.position.x;
document.getElementById("input_locationY").value = marker.position.y;
// map.panBy(new naver.maps.Point(10, 10)); // 오른쪽 아래로 10 픽셀 이동
</script>