<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <title>PHP 프로그래밍 입문</title>
    <link rel="stylesheet" type="text/css" href="./css/common.css">
    <link rel="stylesheet" type="text/css" href="./css/main.css">
    <link rel="stylesheet" type="text/css" href="./css/location.css?ver=2">
    <script type="text/javascript" src="https://openapi.map.naver.com/openapi/v3/maps.js?ncpClientId=3x62gkpqxy"></script><!-- clientId 숨김 처리 요함 -->
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>
         

</head>

<body>
    <header>
        
        <?php include "header.php";
        

            if(isset($_GET["X"]))
            $loX = $_GET["X"];
            else {
                $loX=0;
            }
            if(isset($_GET["Y"]))
            $loY = $_GET["Y"];
            else {
                $loY = 0;
            }
            if(!$loX  || !$loY)
            {
                echo("
                            <script>
                            alert('좌표입력 오류');
                            history.go(-1)
                            </script>
                ");
                        exit;
            }
                
            $lox_cookey = setcookie("loX",$loX);            
            $loy_cookey = setcookie("loY",$loY);
        ?>
    </header>
    <section>

        <div class="location">

            <p class="location_title">배달 범위</p>
            <div class="map_table">
                <!--네이버지도-->
                <div id="map">
                    <div class ="search">
                        <input id="address" type="text" placeholder="검색할 주소" value="불정로 6" />
                        <input id="submit" type="button" value="주소 검색" />
                    </div> 
                </div>
            </div>

            <div id="explain">
                <div class="text_wrapper">
                    <p>가게의 위치를</p>
                    <p class="explain_text">정해주세요.</p>
                    <p class="explain_text">지도를 클릭하면</p>
                    <p class="explain_text">마커가 생기면서 </p>
                    <p class="explain_text">좌표를 찾아줍니다.</p>
                    </div> 
                <div class="input_layer">
                    <button class="markerbutton" onClick='markerselect(1)'>왼쪽 아래범위</button>
                    <button class="markerbutton" onClick='markerselect(2)'>오른쪽 위 범위</button>
              
                    <form  class="form_" action="store_input.php" method="POST">
                        
                        <!-- <p class="text">현재 위치 X좌표</p> -->
                            <input id="input_locationswX" type="hidden" name="swX" value="" readonly>
                        
                        <!-- <p class="text">현재 위치 Y좌표</p> -->
                            <input id="input_locationswY" type="hidden" name="swY" value="" readonly>
                        <!-- <p class="text">현재 위치 X좌표</p> -->
                            <input id="input_locationneX" type="hidden" name="neX" value="" readonly>
                        
                        <!-- <p class="text">현재 위치 Y좌표</p> -->
                            <input id="input_locationneY" type="hidden" name="neY" value="" readonly>
                        
                        <input class="submit" type="submit" value="배달 반경설정" />

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
var mapOptions = {
    center: new naver.maps.LatLng(<?=$loY?>, <?=$loX?>),
    zoom: 17,
    scaleControl: false,
    logoControl: true,
    mapDataControl: true,
    zoomControl: false,

};
var map = new naver.maps.Map('map', mapOptions);
var markerOption = {
    position: mapOptions.center,
    map: map,
    icon:{
        url: './img/marker/marker.png',
        size: new naver.maps.Size(20, 32),
    },
}
var marker1 = new naver.maps.Marker({
    map: map,
    position: mapOptions.center
});
var marker2= new naver.maps.Marker({
    map: map,
    position: mapOptions.center
});
// var marker3= new naver.maps.Marker(markerOption);
var marker = new naver.maps.Marker(markerOption);
var selectMarker = marker1;
bounds = map.bounds;
bounds = new naver.maps.LatLngBounds(marker1.position, marker2.position);

rect = new naver.maps.Rectangle({
    map: map,
    bounds: bounds,
    fillOpacity: 0.2,
    strokeOpacity: 0.2,
    strokeColor: '#00ff00',
    fillColor: '#00ff00',
});


var number = 1;
function markerselect(a){

    if (a === 1) {
        number = 1;
        selectMarker = marker1;
    }
    else if(a === 2)
    {
        number = 2;
        selectMarker = marker2;
    }
};


function setMarker(e,) {
    selectMarker.setPosition(e.coord);
    var tmp = e.coord;
    // marker1.setPosition(e.coord);
    // marker.setPosition(e.coord.X+0.01,e.coord.Y+0.01)    
    // return tmp;
    if(number === 1)
    {
        bounds = new naver.maps.LatLngBounds(selectMarker.position, marker2.position);
        rect.setBounds(bounds) ;  
        document.getElementById("input_locationswX").value = tmp.x;
        document.getElementById("input_locationswY").value = tmp.y;
    }
    else if(number === 2)
    {
        bounds = new naver.maps.LatLngBounds(marker1.position, selectMarker.position);
        rect.setBounds(bounds) ;  
        document.getElementById("input_locationneX").value = tmp.x;
        document.getElementById("input_locationneY").value = tmp.y;
    }
};
naver.maps.Event.addListener(map, 'click',setMarker);

document.getElementById("input_locationX").value = marker.position.x;
document.getElementById("input_locationY").value = marker.position.y;
// map.panBy(new naver.maps.Point(10, 10)); // 오른쪽 아래로 10 픽셀 이동


</script>